﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POEGADE18013130
{
    class DoctorsUnit : Unit
    {
        private new string Name;

        public new string name
        {
            get { return Name; }
            set { Name = value; }
        }

        private int Xpos;

        public int xpos
        {
            get { return Xpos; }
            set { Xpos = value; }
        }

        private int Ypos;

        public int ypos
        {
            get { return Ypos; }
            set { Ypos = value; }
        }

        private int Health;

        public int health
        {
            get { return Health; }
            set { Health = value; }
        }

        private int Speed;

        public int speed
        {
            get { return Speed; }
            set { Speed = value; }
        }

        private int Attack;

        public int attack
        {
            get { return Attack; }
            set { Attack = value; }
        }

        private int InRanged;

        public int inranged
        {
            get { return InRanged; }
            set { InRanged = value; }
        }

        private int Faction;

        public int faction
        {
            get { return Faction; }
            set { Faction = value; }
        }
        private string Symbol;

        public string symbol
        {
            get { return Symbol; }
            set { Symbol = value; }
        }
        public override void Move(Direction d) //tells Doctor unit which direction to move towards.
        {
            switch (d)
            {
                case Direction.North:
                    {
                        Ypos -= Speed;
                        break;
                    }
                case Direction.East:
                    {
                        Xpos += Speed;
                        break;
                    }
                case Direction.West:
                    {
                        Xpos -= Speed;
                        break;
                    }
                case Direction.South:
                    {
                        Ypos += Speed;
                        break;
                    }
            }
        }

        public DoctorsUnit(int x, int y, int speed, int Range, int Health, int Team, string symbol, int attack, string name)//All of Doctor units information.
        {

            Xpos -= x;
            Ypos = y;
            Health = health;
            Speed = speed;
            Range = range;
            Team = team;
            Symbol = symbol;
            Attack = attack;
            Name = name;
        }

        private int DistanceTo(Unit u)// checks Doctor unit distance to the other unirs
        {
            if (u.GetType() == typeof(DoctorsUnit))
            {
                DoctorsUnit n = (DoctorsUnit)u;
                int d = (Xpos - n.xpos) + Math.Abs(Ypos - n.ypos);
                return d;
            }
            else
            {
                return 0;
            }
        }

        public Direction DirectionTo(Unit u)// The Direction inwhich this class will move
        {
            if (u.GetType() == typeof(DoctorsUnit))
            {
                DoctorsUnit n = (DoctorsUnit)u;
                if (n.Xpos < n.Ypos)
                {
                    return Direction.North;
                }
                else if (n.Xpos > Xpos)
                {
                    return Direction.South;
                }
                else if (n.Ypos < Ypos)
                {
                    return Direction.West;
                }
                else
                {
                    return Direction.East;
                }
            }
            else;
            {
                return Direction.North;
            }
        }
        public override void Combat(Unit u)// checks Doctors unit in combat
        {
            if (u.GetType() == typeof(DoctorsUnit))
            {
                health -= ((DoctorsUnit)u).Attack;

            }
            else if (u.GetType() == typeof(MeleeUnit))
            {
                health -= ((MeleeUnit)u).attack;
                health -= ((MeleeUnit)u).attack;

            }
            else if (u.GetType() == typeof(RangedUnit))
            {
                health -= ((RangedUnit)u).attack;
                health -= ((RangedUnit)u).attack;

            }
            else if (u.GetType() == typeof(TwoHandedUnits))
            {
                health -= ((TwoHandedUnits)u).attack;
                health -= ((TwoHandedUnits)u).attack;

            }
            else if (u.GetType() == typeof(ProphetsUnit))
            {
                health -= ((ProphetsUnit)u).attack;
                health -= ((ProphetsUnit)u).attack;

            }
            else if (u.GetType() == typeof(AssasinUnit))
            {
                health -= ((AssasinUnit)u).attack;
                health -= ((AssasinUnit)u).attack;

            }

        }
        public override bool Inranged(Unit u)// checks to see if the other unit for combat
        {
            if (u.GetType() == typeof(DoctorsUnit))
            {
                ProphetsUnit n = (ProphetsUnit)u;
                if (DistanceTo(u) <= range)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public override Unit Closest(Unit[] units)// checks to see which unit the doctor unit is closest to
        {
            Unit closest = this;
            int closestDistance = 50;

            foreach (Unit u in units)
            {
                //if (u.GetType() == typeof(MeleeUnit))
                //{
                if (((DoctorsUnit)u).team == team)
                {
                    if (DistanceTo(u) < closestDistance)
                    {
                        closest = u;
                        closestDistance = DistanceTo((DoctorsUnit)u);
                    }
                }
                //}
                //else if(u.GetType() == typeof(RangedUnit))
                //{
                //    if (DistanceTo(u) < closestDistance)
                //    {
                //        closest = u;
                //        closestDistance = DistanceTo((RangedUnit)u);
                //    }
                //}
            }
            return closest;
        }
        public override bool Isdead()// checks to see if Doctor Unit is dead
        {
            if (health < +0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public override string Tostring()//Displays the information of Doctor Unit to the user
        {
            return "DU" + Xpos + "," + Ypos + "," + health + "," + Name;
        }
    }
}
