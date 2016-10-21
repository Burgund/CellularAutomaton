using System;
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
            int loop = 0;

            //setting up array size
            Console.WriteLine("Choose the array size. Write an integer between 8 and 80 and push <enter>.");
            Console.WriteLine("If you want default size (10) just push<enter>.\nNote: You may want to set up your console window size.");
            int arraySize = 0;
            arraySize = Int32.Parse(Console.ReadLine());

            if (arraySize < 8 || arraySize > 80) arraySize = 10;

            Cell[,] cellArray = new Cell[arraySize, arraySize];
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

            //Generation 0 cellArray print
            Console.WriteLine("Generation 0:");
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
            string nextIteration = "n";
            do
            {
                loop++;
                //deep cloning our array of cells
                bool[,] auxiliaryArray = new bool[arraySize, arraySize];
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
                Console.WriteLine("\nGeneration {0}:", loop);
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

                Console.WriteLine("\nDo you want next generation? If yes, press <Y> and <Enter>. Otherwise click any key and <Enter>");
                nextIteration = Console.ReadLine();
                nextIteration = nextIteration.ToUpper();
            } while (nextIteration == "Y");
            //END OF MAIN LOOP ---------------------------------------------------------------

            Console.ReadLine();
        }
    }
}
