using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POEGADE18013130
{
    
    class BuildingResources : Building
    {
        private string ResourceType;

        public string RT
        {
            get { return ResourceType; }
            set { ResourceType = value; }
        }

        private int ResourcePerGameTick;

        public int RPGT
        {
            get { return ResourcePerGameTick; }
            set { ResourcePerGameTick = value; }
        }
        private int ResourceRemaing;

        public int resourceremaing
        {
            get { return ResourceRemaing; }
            set { ResourceRemaing = value; }
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
        private int Ranged;

        public int range
        {
            get { return Ranged; }
            set { Ranged = value; }
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
        private string Symbol;

        public string symbol
        {
            get { return Symbol; }
            set { Symbol = value; }
        }

        private string Team;
                
        public string team
        {
            get { return Team; }
            set { Team = value; }
        }


        public override void Combat(Building b)// checks building resources in combat
        {
            if (b.GetType() == typeof(BuildingFactory))
            {
                health -= ((BuildingFactory)b).attack;

            }
            else if (b.GetType() == typeof(BuildingResources))
            {
                health -= ((BuildingResources)b).attack;
            }

        }
        private int DistanceTo(BuildingResources r)
        {
            if (r.GetType() == typeof(BuildingResources))
            {
                BuildingResources  n = (BuildingResources)r;
                int d = (Xpos - n.Xpos) + Math.Abs(Ypos - n.Ypos);
                return d;
            }
            else
            {
                return 0;
            }
        }
        public override bool Inranged(Building b) //  checks to see if units are in range
        {
            if (b.GetType() == typeof(BuildingFactory))
            {
                Building u = (BuildingFactory)b;
                if (DistanceTo(b) <= Ranged)
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

        private int DistanceTo(Building b) // building respurces distance
        {
            throw new NotImplementedException();
        }

        public override Building Closest(Building[] Building)
        {
            Building closest = this;
            int closestDistance = 50;

            foreach (Building b in Building)
            {
                //if (b.GetType() == typeof(BuildingFactory))
                //{
                if (((BuildingFactory)b).team == team)
                {
                    if (DistanceTo(b) < closestDistance)
                    {
                        closest = b;
                        closestDistance = DistanceTo((BuildingFactory)b);
                    }
                }
                //}
                //else if(b.GetType() == typeof(BuidlingFactory))
                //{
                //    if (DistanceTo(b) < closestDistance)
                //    {
                //        closest = b;
                //        closestDistance = DistanceTo((BuildingFactory)b);
                //    }
                //}
            }
            return closest;
        }

        private int DistanceTo(BuildingFactory b)
        {
            throw new NotImplementedException();
        }

        public override bool Isdead()
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
        public void Resources() //brings resources to the map
        {
            if(resourceremaing < RPGT)
            {
                resourceremaing= resourceremaing + 50;
            }
            else if(resourceremaing > ResourcePerGameTick)
            {
                resourceremaing = resourceremaing - 50;
            }           
        }
        public override string Tostring()//displays nuilding resources
        {
            return "BR" + Xpos + "," + Ypos + "," + health;
        }
    }
}
