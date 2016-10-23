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
        public int FatTissue { get; set; }
        //TODO in future cells will be divided into many species with different attributes
        public string Species { get; set; }
        //isAlive boolean checks if cell is alive (surprising, isn't it?)
        public bool IsAlive { get; set; }
        //we have to define if the cell is predator or herbivore
        public bool IsPredator { get; set; }
        public bool IsHerbivore { get; set; }
    }
}
