using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POEGADE18013130
{
    //other building classes inherit from this class
    public abstract class Building
    {
        protected int xpos;
        protected int ypos;
        protected int attack;
        protected int speed;
        protected int range;
        protected int team;
        protected int health;
        protected string symbol;



        abstract public void Combat(Building b);
        abstract public bool Inranged(Building b);
        abstract public Building Closest(Building[] buildings);
        abstract public bool Isdead();
        abstract public string Tostring();
    }
}
