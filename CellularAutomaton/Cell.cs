using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellularAutomaton
{
    //this class define the objects of program main array
    //objects of Cell class (cells) are our main entities
    class Cell
    {
        //hunger variable determines when the cell will die
        private int hunger = 0;
        //TODO in future cells will be divided into many species with different attributes
        private string species = "none";
        //isAlive boolean checks if cell is alive (surprising, isn't it?)
        private bool isAlive = false;

        //variables properties
        public int Hunger
        {
            get { return hunger; }
            set { hunger = value; }
        }

        public string Species
        {
            get { return species; }
            set { species = value; }
        }

        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }
    }
}
