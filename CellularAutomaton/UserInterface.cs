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

        //set up cells
        public int WantRandom()
        {
            string answer = " ";
            Console.WriteLine("Do you want random cells('r') or you prefer to set up cells by yourself?");
            Console.WriteLine("write 'r' and <enter> if you want random set up. Otherwise just click <enter>");
            answer = Console.ReadLine().ToUpper();

            if(answer == "R")
            {
                Console.WriteLine("How many random tries do you want?");
                int x = 10;
                try
                {
                    x = Int32.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Wrong number!");
                }
                return x;
            }
            else
            {
                return -1;
            }
        }

        //Ask user if next herbivore/predator should be set up
        public int[] WantNextCell(string cell)
        {
            int[] tab = new int[2];
            Console.WriteLine("Do you want new " + cell + " cell? Write <y> and confirm <enter> if yes, otherwise just click <enter>");
            string answer = Console.ReadLine().ToUpper();

            if (answer == "Y")
            {
                Console.WriteLine("You have to set up coordinates for new cell");
                Console.WriteLine("Set x value: ");
                tab[0] = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Set y value: ");
                tab[1] = Int32.Parse(Console.ReadLine());
                return tab;
            }
            else
            {
                tab[0] = -1;
                tab[1] = -1;
                return tab;
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
