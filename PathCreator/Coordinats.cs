using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathCreator
{
    class Coordinats
    {
        public struct Coord
        {
            public int x
            {
                get;
                set;
            }
            public int y
            {
                get;
                set;
            }

            public Coord (int iX, int iY) : this()
            {
                Console.WriteLine("X {0} Y {1}", iX, iY);
                x = iX;
                y = iY;
            }
            
            public Coord (Coord c) : this()
            {
                x = c.x;
                y = c.y;
            }

            public int GetX()
            {
                return this.x;
            }

            public int GetY()
            {
                return this.y;
            }
        }
    }
}
