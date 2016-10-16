using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellularAutomaton
{
    class Program
    {
        static void Main(string[] args)
        {
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
            cellArray[4, 4].isAlive = true;
            cellArray[4, 5].isAlive = true;
            cellArray[3, 4].isAlive = true;
            cellArray[5, 4].isAlive = true;

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


            Console.ReadLine();
        }
    }
}
