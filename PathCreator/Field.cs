using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathCreator
{
    class Field
    {
        public const char cLUUg = '╔', cCUPer = '╦', cURUg = '╗';
        public const char cLCUg = '╠', cCCPer = '╬', cCRUg = '╣';
        public const char cLDUg = '╚', cCDPer = '╩', cDRUg = '╝';
        public const char cInOutG = '═';
        public const char cInOutV = '║';
        public const char cVoid = '█';

        public struct Symb
        {
            public string sCode;
            public char cSym;

            public Symb(string sC, char cS)
            {
                this.sCode = sC;
                this.cSym = cS;
            }
        }



        char cValue;
        bool bUsed
        {
            get;
            set;
        }
        ElementPath ep;        
        
        public Field()
        {
            SetDef();
        }
        public Field(char cv)
        {
            this.cValue = cv;
        }

        public void SetValue(char cV, ElementPath e)
        {
            this.cValue = cV;
            this.ep = e;
            this.bUsed = true;
        }

        public void SetDef()
        {
            this.cValue = cVoid;
            this.bUsed = false;
        }

        public override string ToString()
        {
            return this.cValue.ToString();
        }

        public char GetVal()
        {
            return this.cValue;
        }

        public char GetEl(char cPr, int iTecDir, int iTecPov, int iNewDir)
        {
            if (iTecPov == 0)
            {
                switch (cPr)
                {
                    /*Верх*/
                    case cLUUg:
                        if (iTecDir == 1)
                            return cInOutG;
                        else if (iTecDir == 2)
                            return cInOutV;
                        break;
                    case cCUPer:
                        if (iTecDir == 1 || iTecDir == 3)
                            return cInOutG;
                        else if (iTecDir == 2)
                            return cInOutV;
                        break;
                    case cURUg:
                        if (iTecDir == 3)
                            return cInOutG;
                        else if (iTecDir == 2)
                            return cInOutV;
                        break;
                    /*Центр*/
                    case cLCUg:
                        if (iTecDir == 1)
                            return cInOutG;
                        else if (iTecDir == 2 || iTecDir == 0)
                            return cInOutV;
                        break;
                    case cCCPer:
                        if (iTecDir == 1 || iTecDir == 3)
                            return cInOutG;
                        else if (iTecDir == 2 || iTecDir == 0)
                            return cInOutV;
                        break;
                    case cCRUg:
                        if (iTecDir == 3)
                            return cInOutG;
                        else if (iTecDir == 2 || iTecDir == 0)
                            return cInOutV;
                        break;
                    /*Низ*/
                    case cLDUg:
                        if (iTecDir == 1)
                            return cInOutG;
                        else if (iTecDir == 0)
                            return cInOutV;
                        break;
                    case cCDPer:
                        if (iTecDir == 3 || iTecDir == 1)
                            return cInOutG;
                        else if (iTecDir == 0)
                            return cInOutV;
                        break;
                    case cDRUg:
                        if (iTecDir == 3)
                            return cInOutG;
                        else if (iTecDir == 0)
                            return cInOutV;
                        break;
                    /*Горизонталь*/
                    case cInOutG:
                        return cInOutG;
                    /*Вертикаль*/
                    case cInOutV:
                        return cInOutV;
                }
            }
            else if (iTecPov == 1)
            {
                switch (cPr)
                {
                    case cLUUg:
                        break;
                }
                return cVoid;
            }
            else if (iTecPov == 2)
            {
                return cVoid;
            }
            return cVoid;
        }
        
    }
}
