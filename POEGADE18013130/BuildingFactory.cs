using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace POEGADE18013130
{
   

    class BuildingFactory : Building
    {
        private int UnitProduce;

        public int unitproduce
        {
            get { return UnitProduce; }
            set { UnitProduce = value; }
        }

        private int GameTickPerProduct;

        public int GTPP
        {
            get { return GameTickPerProduct; }
            set { GameTickPerProduct = value; }
        }

        private int Spawnpostion;

        public int spawnpostion
        {
            get { return Spawnpostion; }
            set { Spawnpostion = value; }
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

        public void Spawn()// spawns building to other users
        {
            if(spawnpostion == unitproduce)
            {
                spawnpostion = spawnpostion + 1;
            }
            else if(spawnpostion < unitproduce)
            {
                spawnpostion = spawnpostion + 50;
            }
        }
        public override void Combat(Building b)// checks building in combat
        {
            if (b.GetType() == typeof(BuildingResources))
            {
                health -= ((BuildingResources)b).attack;

            }
            else if (b.GetType() == typeof(BuildingFactory))
            {
                health -= ((BuildingFactory)b).attack;
            }

        }
        private int DistanceTo(BuildingFactory f)//checks the distance to other buildings
        {
            if (f.GetType() == typeof(BuildingFactory))
            {
                BuildingFactory b = (BuildingFactory)f;
                int d = (Xpos - f.Xpos) + Math.Abs(Ypos - f.Ypos);
                return d;
            }
            else
            {
                return 0;
            }
        }
        public override bool Inranged(Building b)//checks to see if buildings are in range of other units
        {
            if (b.GetType() == typeof(BuildingResources))
            {
                Building u = (BuildingResources)b;
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

        private int DistanceTo(Building b)
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
        public override string Tostring()
        {
            return "BR" + Xpos + "," + Ypos + "," + health;
        }

    }
}


