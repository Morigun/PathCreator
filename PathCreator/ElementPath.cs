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
        public List<Coordinats.Coord> Cord;

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
            this.ePovArr = new List<ePovorot>();
            SetPovorot(1);
            this.eDirArr = new List<eDirection>();
            SetDirection(1);
            this.Cord = new List<Coordinats.Coord>();
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
            this.Cord = new List<Coordinats.Coord>();
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

        public int GetPrevDirInt()
        {
            int iMin;
            if (this.eDirArr.Count > 1)            
                iMin = 2;
            else
                iMin = 1;            
            switch (this.eDirArr[this.eDirArr.Count - iMin])
            {
                case eDirection.east:
                    return 1;
                case eDirection.north:
                    return 0;
                case eDirection.south:
                    return 2;
                case eDirection.west:
                    return 3;
            }
            return 0;
        }

        public int GetTecDirInt()
        {            
             switch (this.eDirArr[this.eDirArr.Count - 1])
             {
                 case eDirection.east:
                     return 1;
                 case eDirection.north:
                     return 0;
                 case eDirection.south:
                     return 2;
                 case eDirection.west:
                     return 3;
             }
             return 0;
        }

        public eDirection GetTecDir()
        {            
            return this.eDirArr[this.eDirArr.Count - 1];
        }

        public ePovorot GetPrevPov()
        {
            if (this.ePovArr.Count > 1)
                return this.ePovArr[this.ePovArr.Count - 2];
            else
                return this.ePovArr[this.ePovArr.Count - 1];
        }

        public int GetPrevPovInt()
        {
            int iMin;
            if (this.ePovArr.Count > 1)
                iMin = 2;
            else
                iMin = 1; 
            switch (this.ePovArr[this.ePovArr.Count - iMin])
            {
                case ePovorot.Simple:
                    return 0;
                case ePovorot.Two:
                    return 1;
                case ePovorot.Triple:
                    return 2;
            }
            return 0;
        }

        public int GetTecPovInt()
        {
            switch (this.ePovArr[this.ePovArr.Count - 1])
            {
                case ePovorot.Simple:
                    return 0;
                case ePovorot.Two:
                    return 1;
                case ePovorot.Triple:
                    return 2;
            }
            return 0;
        }

        public ePovorot GetTecPov()
        {
            return this.ePovArr[this.ePovArr.Count - 1];
        }

        public void SetCoord(int x, int y)
        {
            this.Cord.Add(new Coordinats.Coord(x, y));
        }

        public void SetCoord(Coordinats.Coord c)
        {
            this.Cord.Add(c);
        }

        public void SetLength()
        {
            this.iLength--;
        }

        public static int CheckDir(int i)
        {
            if (i < 25)
            {
                return 0;
            }
            else if (i >= 25 && i < 50)
            {
                return 1;
            }
            else if (i >= 50 && i < 75)
            {
                return 2;
            }
            else 
                return 3;
        }

        public static int CheckPov(int i)
        {
            if (i < 33)
            {
                return 0;
            }
            else if (i >= 33 && i < 66)
            {
                return 1;
            }
            else 
                return 2;
        }
    }
}
