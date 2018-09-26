using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POEGADE18013130
{
    [Serializable]
    class Map
    {
        Random r = new Random();
        private Unit[] units;

        public Unit[] Units
        {
            get { return units; }
            set { units = value; }
        }

        public Map(int maxX, int maxY, int numUnits)
        {
            units = new Unit[numUnits];
            for (int i = 0; i < numUnits; i++)
            {
                if (i % 2 == 0)
                {
                    MeleeUnit u= new MeleeUnit(r.Next(0, maxY), r.Next(0, maxX), r.Next(5, 10) * 10, r.Next(5, 20), 1, 1, "M", i % 2,"Knight");

                    Units[i] = u;
                }

            }
        }
    }
}
