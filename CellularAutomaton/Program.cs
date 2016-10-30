﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CellularAutomaton
{
    //main Program class with Main function and program main loop
    //this is the kernel of whole program
    class Program
    {
        static void Main(string[] args)
        {
            //local variables
            CellEnvironment environment = new CellEnvironment();
            UserInterface ui = new UserInterface();

            //setting up array size.
            int arraySize = ui.Initializer();

            Cell[,] cellArray = new Cell[arraySize, arraySize];
            for (int i = 0; i < cellArray.GetLength(0); i++)
            {
                for (int j = 0; j < cellArray.GetLength(1); j++)
                {
                    cellArray[i, j] = new Cell();
                    cellArray[i, j].FatTissue = 0;
                    cellArray[i, j].IsAlive = false;
                    cellArray[i, j].IsHerbivore = false;
                    cellArray[i, j].IsPredator = false;
                    cellArray[i, j].Species = "none";
                }
            }

            //TODO let the user choose which cells should be alive when program starts
            //now we will use random cells
            
            Random random = new Random();
            for (int i = 0; i < 20; i++)
            {
                int x = random.Next(arraySize);
                int y = random.Next(arraySize);
                if(i % 2 == 0)
                {
                    cellArray[x, y].FatTissue = 2;
                    cellArray[x, y].IsAlive = true;
                    cellArray[x, y].IsHerbivore = true;
                }
                else
                {
                    cellArray[x, y].FatTissue = 2;
                    cellArray[x, y].IsAlive = true;
                    cellArray[x, y].IsPredator = true;
                }
            }

            //Generation 0 cellArray print
            Console.WriteLine("Generation 0:");
            ui.CellArrayPrint(cellArray);
            Console.WriteLine("\n");

            //MAIN LOOP -------------------------------------------------------------------
            string nextIteration = "n";
            int loop = 0;
            do
            {
                ui.WaitInfo();
                loop++;
                //we have to count how many herbivores are in the neighborhood
                bool[,] herbivoreArray = new bool[arraySize, arraySize];
                for (int i = 0; i < cellArray.GetLength(0); i++)
                {
                    for (int j = 0; j < cellArray.GetLength(1); j++)
                    {
                        if (cellArray[i, j].IsAlive & cellArray[i, j].IsHerbivore) herbivoreArray[i, j] = true;
                    }
                }

                //we have to count how many predatores are in the neighborhood
                bool[,] predatorArray = new bool[arraySize, arraySize];
                for (int i = 0; i < cellArray.GetLength(0); i++)
                {
                    for (int j = 0; j < cellArray.GetLength(1); j++)
                    {
                        if (cellArray[i, j].IsAlive & cellArray[i, j].IsPredator) predatorArray[i, j] = true;
                    }
                }

                //treating i and j iteration variables as position allow us to chcek in which part of array the cell is. 
                //For example cell from left top corner should have a different type of feeding then a cell from the center of array
                //environment.Feeding changes parameters of the i/j positioned cell in view of the neighborhood taken from herbivore or predator array

                //herbivore loop
                for (int i = 0; i < cellArray.GetLength(0); i++)
                {
                    for (int j = 0; j < cellArray.GetLength(1); j++)
                    {
                        cellArray[i, j] = environment.Feeding(cellArray[i, j], environment.AvailableFoodForHerbivore(herbivoreArray, predatorArray, i, j), false);
                    }
                }
                
                //predator loop
                for (int i = 0; i < cellArray.GetLength(0); i++)
                {
                    for (int j = 0; j < cellArray.GetLength(1); j++)
                    {
                        cellArray[i, j] = environment.Feeding(cellArray[i, j], environment.AvailableFoodForPredator(herbivoreArray, predatorArray, i, j), true);
                    }
                }


                //cellArray print
                ui.ClearLine();
                Console.WriteLine("\nGeneration {0}:", loop);
                ui.CellArrayPrint(cellArray);

                nextIteration = ui.AskNextIteration();
            } while (nextIteration == "Y");
            //END OF MAIN LOOP ---------------------------------------------------------------

            Console.ReadLine();
        }
    }
}
