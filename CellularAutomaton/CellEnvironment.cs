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
        //function checks how much food is available for the cell
        public bool AvailableFood(bool[,] feedingArray, int x_position, int y_position)
        {
            //how many neighbors the cell have? 
            int neighbors = 0;

            for (int i = x_position - 1; i <= x_position + 1; i++)
            {
                for (int j = y_position - 1; j <= y_position + 1; j++)
                {
                    if (i != x_position || j != y_position)
                    {
                        try
                        {
                            if (feedingArray[i, j]) neighbors++;
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }
            }

            if (neighbors == 3) return true;
            else return false;
        }

        //Feeding function returns new cell with changed parameters 
        public Cell Feeding(Cell cell, bool food)
        {
            Cell newCell = cell;

            //feeding the cell and revive if possible 
            if (food && newCell.hunger < 2)
            {
                newCell.hunger++;
                newCell.isAlive = true;
            }
            else if (!food) newCell.hunger--;

            //if hunger variable reach 0 program should kill the cell
            if(newCell.hunger < 1)
            {
                newCell.isAlive = false;
                newCell.hunger = 0;
            }

            return newCell;
        }
    }
}
