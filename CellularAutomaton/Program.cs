﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CellularAutomaton
{
    class Program
    {
        static void Main(string[] args)
        {
            CellEnvironment environment = new CellEnvironment();

            //TODO let the user choose the array size
            //initialize cellArray
            Cell[,] cellArray = new Cell[10, 10];
            for (int i = 0; i < cellArray.GetLength(0); i++)
            {
                for (int j = 0; j < cellArray.GetLength(1); j++)
                {
                    cellArray[i, j] = new Cell();
                }
            }

            //TODO let the user choose which cells should be alive when program starts
            cellArray[4, 3].isAlive = true;
            cellArray[4, 3].hunger = 1;

            cellArray[4, 4].isAlive = true;
            cellArray[4, 4].hunger = 1;

            cellArray[4, 5].isAlive = true;
            cellArray[4, 5].hunger = 1;

            cellArray[3, 4].isAlive = true;
            cellArray[3, 4].hunger = 1;

            cellArray[5, 4].isAlive = true;
            cellArray[5, 4].hunger = 1;

            //TEST - cellArray print
            for (int i = 0; i < cellArray.GetLength(0); i++)
            {
                for (int j = 0; j < cellArray.GetLength(1); j++)
                {
                    if (cellArray[i,j].isAlive)
                    {
                        Console.Write("+ ");
                    }
                    else
                    {
                        Console.Write("= ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            //MAIN LOOP -------------------------------------------------------------------
            do
            {
                //deep cloning our array of cells
                bool[,] auxiliaryArray = new bool[10, 10];
                for (int i = 0; i < cellArray.GetLength(0); i++)
                {
                    for (int j = 0; j < cellArray.GetLength(1); j++)
                    {
                        auxiliaryArray[i, j] = cellArray[i, j].isAlive;
                    }
                }

                //treating i and j iteration variables as position allow us to chcek in which part of array the cell is. 
                //For example cell from left top corner should have a different type of feeding then a cell from the center of array
                for (int i = 0; i < cellArray.GetLength(0); i++)
                {
                    for (int j = 0; j < cellArray.GetLength(1); j++)
                    {
                        //environment.Feeding changes parameters of the i/j positioned cell in view of the neighborhood taken from auxiliary array
                        bool b = environment.AvailableFood(auxiliaryArray, i, j);
                        cellArray[i, j] = environment.Feeding(cellArray[i, j], b);
                    }
                }

                //cellArray print
                for (int i = 0; i < cellArray.GetLength(0); i++)
                {
                    for (int j = 0; j < cellArray.GetLength(1); j++)
                    {
                        if (cellArray[i, j].isAlive)
                        {
                            Console.Write("+ ");
                        }
                        else
                        {
                            Console.Write("= ");
                        }
                    }
                    Console.WriteLine();
                }
            } while (false);
            //END OF MAIN LOOP ---------------------------------------------------------------

            Console.ReadLine();
        }
    }
}
