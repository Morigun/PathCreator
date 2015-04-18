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

        public List<eDirection> eDirArr
        {
            get;
            set;
        }

        public List<ePovorot> ePovArr
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
            this.ePovArr = new List<ePovorot>();
            SetDirection(1);
            this.eDirArr = new List<eDirection>();
            SetCoord(0, 0);
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
            this.ePovArr = new List<ePovorot>();
            SetPovorot(p);
            this.eDirArr = new List<eDirection>();
            SetDirection(d);
            SetCoord(x, y);
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
                    this.ePovArr.Add(ePovorot.Simple);
                    break;
                case 1:
                    this.pov = ePovorot.Two;
                    this.ePovArr.Add(ePovorot.Two);
                    break;
                case 2:
                    this.pov = ePovorot.Triple;
                    this.ePovArr.Add(ePovorot.Triple);
                    break;
            }            
        }

        public void SetDirection(int d)
        {
            switch (d)
            {
                case 0:
                    this.dir = eDirection.north;
                    this.eDirArr.Add(eDirection.north);
                    break;
                case 1:
                    this.dir = eDirection.east;
                    this.eDirArr.Add(eDirection.east);
                    break;
                case 2:
                    this.dir = eDirection.south;
                    this.eDirArr.Add(eDirection.south);
                    break;
                case 3:
                    this.dir = eDirection.west;
                    this.eDirArr.Add(eDirection.west);
                    break;
            } 
        }

        public eDirection GetPrevDir()
        {
            if (this.eDirArr.Count > 1)
                return this.eDirArr[this.eDirArr.Count - 2];
            else
                return this.eDirArr[this.eDirArr.Count - 1];
        }

        public ePovorot GetPrevPov()
        {
            if (this.ePovArr.Count > 1)
                return this.ePovArr[this.ePovArr.Count - 2];
            else
                return this.ePovArr[this.ePovArr.Count - 1];
        }

        public void SetCoord(int x, int y)
        {
            this.Cord = new Coordinats.Coord(x, y);
        }

        public void SetCoord(Coordinats.Coord c)
        {
            this.Cord = c;
        }

        public void SetLength()
        {
            this.iLength--;
        }
    }
}
