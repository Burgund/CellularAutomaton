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

            //position variables allow us to chcek in which part of array the cell is. 
            //For example cell from left top corner should have a different type of feeding then a cell from the center of array
            int x_position = 0;
            int y_position = 0;
            //TODO feeding loop here

            Console.ReadLine();
        }

        //function checks how much food is available for the cell
        static void Feeding(Cell[,] feedingArray, int x_position, int y_position)
        {
            //how much food is available for the cell?
            int food = 0;
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
                            if (feedingArray[i, j].isAlive) neighbors++;
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }
            }
        }
    }
}
