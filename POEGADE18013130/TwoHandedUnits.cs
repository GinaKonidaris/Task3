using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POEGADE18013130
{
    class TwoHandedUnits :Unit
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
        public override void Move(Direction d) //tells Two Handed unit which direction to move towards.
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

        public TwoHandedUnits(int x, int y, int speed, int Range, int Health, int Team, string symbol, int attack, string name)//All of ranged units information.
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

        private int DistanceTo(Unit u)// checks ranged unit distance to the other unirs
        {
            if (u.GetType() == typeof(TwoHandedUnits))
            {
                TwoHandedUnits n = (TwoHandedUnits)u;
                int d = (Xpos - n.xpos) + Math.Abs(Ypos - n.ypos);
                return d;
            }
            else
            {
                return 0;
            }
        }

        public Direction DirectionTo(Unit u)
        {
            if (u.GetType() == typeof(TwoHandedUnits))
            {
                TwoHandedUnits n = (TwoHandedUnits)u;
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
        public override void Combat(Unit u)// checks Two Handed unit in combat
        {
            if (u.GetType() == typeof(TwoHandedUnits))
            {
                health -= ((TwoHandedUnits)u).Attack;

            }
            else if (u.GetType() == typeof(MeleeUnit))
            {
                health -= ((MeleeUnit)u).attack;
                health -= ((MeleeUnit)u).attack;

            }
            else if(u.GetType()== typeof(RangedUnit))
            {
                health -= ((RangedUnit)u).attack;
                health -= ((RangedUnit)u).attack;

            }
            else if (u.GetType() == typeof(ProphetsUnit))
            {
                health -= ((ProphetsUnit)u).attack;
                health -= ((ProphetsUnit)u).attack;

            }
            else if (u.GetType() == typeof(DoctorsUnit))
            {
                health -= ((DoctorsUnit)u).attack;
                health -= ((DoctorsUnit)u).attack;

            }
            else if (u.GetType() == typeof(AssasinUnit))
            {
                health -= ((AssasinUnit)u).attack;
                health -= ((AssasinUnit)u).attack;

            }

        }
        public override bool Inranged(Unit u)// checks to see if the other unit is inrange for combat
        {
            if (u.GetType() == typeof(TwoHandedUnits))
            {
                TwoHandedUnits n = (TwoHandedUnits)u;
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
        public override Unit Closest(Unit[] units)// checks to see which unit the Two handed unit is closest to
        {
            Unit closest = this;
            int closestDistance = 50;

            foreach (Unit u in units)
            {
                //if (u.GetType() == typeof(MeleeUnit))
                //{
                if (((TwoHandedUnits)u).team == team)
                {
                    if (DistanceTo(u) < closestDistance)
                    {
                        closest = u;
                        closestDistance = DistanceTo((TwoHandedUnits)u);
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
        public override bool Isdead()// checks to see if Two Handed Unit is dead
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
        public override string Tostring()//Displays the information of Two handed Unit to the user
        {
            return "THU" + Xpos + "," + Ypos + "," + health + "," + Name;
        }

    }
}
