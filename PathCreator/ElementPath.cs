using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathCreator
{
    class ElementPath
    {
        public enum ePovorot { Simple = 0, Two = 1, Triple = 2 };
        public enum eDirection { north = 0, west = 1, east = 2, south = 3 };
        public int iLength
        {
            get;
            set;
        }

        public ePovorot pov
        {
            get;
            set;
        }

        public eDirection dir
        {
            get;
            set;
        }
        bool bGlav
        {
            get;
            set;
        }
        bool bEnd
        {
            get;
            set;
        }
        public Coordinats.Coord Cord = new Coordinats.Coord(0, 0);

        int ID
        {
            get;
            set;
        }
        
        public ElementPath()
        {
            this.ID = 0;
            this.iLength = 0;
            this.bGlav = true;
            this.bEnd = false;
            SetPovorot(1);
            SetDirection(1);
            this.Cord = new Coordinats.Coord(0, 0);
        }
        public ElementPath(int iLen, int i, int p, int d, int x, int y)
        {
            this.ID = i;
            this.iLength = iLen;
            if (i == 0)
                this.bGlav = true;
            else
                this.bGlav = false;
            this.bEnd = false;
            SetPovorot(p);
            SetDirection(d);
            this.Cord = new Coordinats.Coord(x, y);
        }

        public void SetEnd()
        {
            this.bEnd = true;
        }

        public void SetPovorot(int p)
        {
            switch(p)
            {
                case 0:
                    this.pov = ePovorot.Simple;
                    break;
                case 1:
                    this.pov = ePovorot.Two;
                    break;
                case 2:
                    this.pov = ePovorot.Triple;
                    break;
            }            
        }

        public void SetDirection(int d)
        {
            switch (d)
            {
                case 0:
                    this.dir = eDirection.north;
                    break;
                case 1:
                    this.dir = eDirection.east;
                    break;
                case 2:
                    this.dir = eDirection.south;
                    break;
                case 3:
                    this.dir = eDirection.west;
                    break;
            } 
        }
    }
}
