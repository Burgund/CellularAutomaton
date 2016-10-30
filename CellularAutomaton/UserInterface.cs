using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellularAutomaton
{
    class UserInterface
    {
        //funcion "hello". 
        public int Initializer()
        {
            //setting up array size. Try-catch used for prevent FormatException
            Console.WriteLine("Choose the array size. Write an integer between 8 and 80 and push <enter>.");
            Console.WriteLine("If you want default size (10) just push<enter>.\nNote: You may want to set up your console window size.");
            int arraySize = 0;
            try { arraySize = Int32.Parse(Console.ReadLine()); }
            catch (FormatException) { }
            catch { Console.WriteLine("Ops! Something went wrong!"); }

            if (arraySize < 8 || arraySize > 80) arraySize = 10;

            return arraySize;
        }

        //When program need a while to print next generation, we should calm dawn the user
        public void WaitInfo()
        {
            ClearLine();
            ClearLine();
            Console.WriteLine("\nLoading...");
            Console.Write("Please wait.");
        }

        //ask user if he/she want next generation
        public string AskNextIteration()
        {
            Console.WriteLine("\nDo you want next generation? If yes, press <Y> and <Enter>. Otherwise just click <Enter>");
            return Console.ReadLine().ToUpper();
        }

        //cellArray print
        public void CellArrayPrint(Cell[,] cellArray)
        {
            for (int i = 0; i < cellArray.GetLength(0); i++)
            {
                for (int j = 0; j < cellArray.GetLength(1); j++)
                {
                    if (cellArray[i, j].IsAlive & cellArray[i, j].IsPredator)
                        Console.Write("P ");
                    else if (cellArray[i, j].IsAlive & cellArray[i, j].IsHerbivore)
                        Console.Write("H ");
                    else
                        Console.Write("- ");
                }
                Console.WriteLine();
            }
        }

        public void ClearLine()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }
    }
}
