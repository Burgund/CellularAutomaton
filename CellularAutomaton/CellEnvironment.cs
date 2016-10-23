using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellularAutomaton
{
    //Environment provides food for cells and allows program to check other environmental attributes 
    class CellEnvironment
    {
        //Feeding function returns new cell with changed parameters 
        public Cell Feeding(Cell cell, bool food, bool predatorCheck)
        {
            Cell newCell = cell;

            if (newCell.IsHerbivore)
            {
                //feeding the cell and revive if possible 
                if (food & newCell.FatTissue < 3)
                {
                    newCell.FatTissue++;
                    newCell.IsAlive = true;
                }
                else if (!food & !predatorCheck)
                {
                    newCell.FatTissue--;
                }
                else if (food & predatorCheck)
                {
                    newCell.IsAlive = true;
                    newCell.FatTissue = 1;
                    newCell.IsHerbivore = false;
                    newCell.IsPredator = true;
                    return newCell;
                }

                //if hunger variable reach 0 program should kill the cell
                if (newCell.FatTissue < 1)
                {
                    newCell.IsAlive = false;
                    newCell.FatTissue = 0;
                    newCell.IsHerbivore = false;
                }
                return newCell;
            }

            if (newCell.IsPredator)
            {
                //feeding the cell and revive if possible 
                if (food & newCell.FatTissue < 3)
                {
                    newCell.FatTissue++;
                    newCell.IsAlive = true;
                }
                else if (!food) newCell.FatTissue--;

                //if hunger variable reach 0 program should kill the cell
                if (newCell.FatTissue < 1)
                {
                    newCell.IsAlive = false;
                    newCell.FatTissue = 0;
                    newCell.IsPredator = false;
                }
                return newCell;
            }

            else
            {
                //feeding the cell and revive if possible 
                if (food)
                {
                    newCell.FatTissue++;
                    newCell.IsAlive = true;
                    if (predatorCheck)
                        newCell.IsPredator = true;
                    else
                        newCell.IsHerbivore = true;
                    return newCell;
                }
                else
                {
                    newCell.IsAlive = false;
                    newCell.IsHerbivore = false;
                    newCell.IsPredator = false;
                    newCell.FatTissue = 0;
                    return newCell;
                }
            }
        }

        //TODO unite both AvailableFood... functions

        //function checks how much food is available for the herbivore cell
        public bool AvailableFoodForHerbivore(bool[,] herbivoreArray, bool[,] predatorArray, int x_position, int y_position)
        {
            //how many herbivore neighbors the cell have? 
            int herbivores = 0;

            for (int i = x_position - 1; i <= x_position + 1; i++)
            {
                for (int j = y_position - 1; j <= y_position + 1; j++)
                {
                    try { if (herbivoreArray[i, j]) herbivores++; }
                    catch { continue; }
                }
            }

            //how many predator neighbors the cell have? 
            int predators = 0;

            for (int i = x_position - 1; i <= x_position + 1; i++)
            {
                for (int j = y_position - 1; j <= y_position + 1; j++)
                {
                    try { if (predatorArray[i, j]) predators++; }
                    catch { continue; }
                }
            }

            if (herbivores > 0 & herbivores + predators < 4) return true;
            else return false;
        }

        //function checks how much food is available for the predator cell
        public bool AvailableFoodForPredator(bool[,] herbivoreArray, bool[,] predatorArray, int x_position, int y_position)
        {
            //how many herbivore neighbors the cell have? 
            int herbivores = 0;

            for (int i = x_position - 1; i <= x_position + 1; i++)
            {
                for (int j = y_position - 1; j <= y_position + 1; j++)
                {
                     try { if (herbivoreArray[i, j]) herbivores++; }
                     catch { continue; }
                }
            }

            //how many predator neighbors the cell have? 
            int predators = 0;

            for (int i = x_position - 1; i <= x_position + 1; i++)
            {
                for (int j = y_position - 1; j <= y_position + 1; j++)
                {
                    try { if (predatorArray[i, j]) predators++; }
                    catch { continue; }
                }
            }

            if (predators > 0 & predators + herbivores > 3) return true;
            else return false;
        }
    }
}
