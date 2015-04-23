using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PathCreator
{
    class Program
    {
        static ElementPath[,] ep;
        /*Текущий путь*/
        static int iTecPath = 0;
        static int iX = 50, iY = 50;
        /*Поле*/
        static int[,] iPole = new int[iX, iY];
        /*Поле класс*/
        static Field[,] fPole = new Field[iX, iY];
        /*Кол-во тупиков*/
        static int iCountEndPath;
        /*Кол-во поворотов*/
        static int iCountPov;
        /*Длина главного пути*/
        static int iLengthPath;
        /*Текущее направление*/
        static int iTecDir;
        /*Кол-во использованных путей*/
        static int iCountEPEnded = 1;
        /*Длина доп пути*/
        static int iLengthDopPath;
        /*Текущий поворот*/
        static int iTecPov;
        static bool bLuck;
        static Random rndCEP = new Random();
        static Random rndCP = new Random();
        static Random rndLP = new Random();
        static Random rndDir = new Random();
        static Random rndPov = new Random();


        public static Field.Symb[] sTab = new Field.Symb[17];

        static void Main(string[] args)
        {
            /*Инициализация поля*/
            //InicPole();


            InicFPole();
            VivodfPole();
            InicSTab();
            /*Вывод поля*/
            //VivodPole();
            Console.WriteLine("GENERATE");
            /*Генерация кол-ва тупиков*/
            iCountEndPath = rndCEP.Next(20, 30);
            /*Генерация длины пути*/
            iLengthPath = GenSymplePath(0, 25, 25);
            /*Инициализируем тупики + основной путь*/
            ep = new ElementPath[iLengthPath, iCountEndPath + 1];
            /*Генерация кол-ва поворотов*/
            iCountPov = rndCP.Next(5, 11); 
            /*Цикл заполнения поля*/
            //GenForPath(iLengthPath, 0);
            GenForFPath(iLengthPath, 0);
            //VivodPole();

            VivodfPole();
            Console.ReadLine();
        }

        static void InicPole()
        {
            for (int x = 0; x < iX; x++)
                for (int y = 0; y < iY; y++)
                    iPole[x, y] = 0;
            iPole[25, 25] = 9;
        }

        static void InicFPole()
        {
            for (int x = 0; x < iX; x++)
                for (int y = 0; y < iY; y++)
                    fPole[x, y] = new Field();
            fPole[0, 0] = new Field((char)'╔');
        }

        static void VivodPole()
        {
            for (int x = 0; x < iX; x++)
            {
                for (int y = 0; y < iY; y++)
                {
                    Console.Write("{0}",iPole[x, y],x,y);
                }
                Console.WriteLine();
            }
        }

        static void VivodfPole()
        {
            for (int x = 0; x < iX; x++)
            {
                for (int y = 0; y < iY; y++)
                {
                    Console.Write("{0}", fPole[x, y].ToString(), x, y);
                }
                Console.WriteLine();
            }
        }

        static Coordinats.Coord SetPosPath(Coordinats.Coord c, int iPath, int d)
        {
            int x, y;
            x = c.GetX();
            y = c.GetY();
            switch (d)
            {
                case 0:                    
                    //iPole[x - 1, y] = 1;
                    iPole[x, y] = 1;
                    ep[iPath].SetCoord(c);
                    Console.WriteLine("ZN {0} DIR 0 NEW X{1} NEW Y{2} X{3} Y{4}", 1, x - 1, y, x, y);
                    return new Coordinats.Coord(x - 1, y);
                case 1:
                    //iPole[x, y + 1] = 2;
                    iPole[x, y] = 2;
                    ep[iPath].SetCoord(c);
                    Console.WriteLine("ZN {0} DIR 1 NEW X{1} NEW Y{2} X{3} Y{4}", 2, x, y + 1, x, y);
                    return new Coordinats.Coord(x, y + 1);
                case 2:
                    //iPole[x + 1, y] = 3;
                    iPole[x, y] = 3;
                    ep[iPath].SetCoord(c);
                    Console.WriteLine("ZN {0} DIR 2 NEW X{1} NEW Y{2} X{3} Y{4}", 3, x + 1, y, x, y);
                    return new Coordinats.Coord(x + 1, y);
                case 3:
                    //iPole[x, y - 1] = 4;
                    iPole[x, y] = 4;
                    ep[iPath].SetCoord(c);
                    Console.WriteLine("ZN {0} DIR 3 NEW X{1} NEW Y{2} X{3} Y{4}", 4, x, y - 1, x, y);
                    return new Coordinats.Coord(x, y - 1);
            }
            return new Coordinats.Coord(c);
        }

        //static bool CheckCoord(Coordinats.Coord c, int d)
        //{
        //    int x, y;
        //    x = c.GetX();
        //    y = c.GetY();
        //    try
        //    {
        //        switch (d)
        //        {
        //            case 0: //Nort
        //                if (iPole[x - 1, y] != 1 && iPole[x - 1, y] != 2 && iPole[x - 1, y] != 3 && iPole[x - 1, y] != 4 && iPole[x, y - 1] != 9)
        //                {
        //                    return true;
        //                }
        //                else
        //                    return false;
        //            case 1: //East
        //                if (iPole[x, y + 1] != 1 && iPole[x, y + 1] != 2 && iPole[x, y + 1] != 3 && iPole[x, y + 1] != 4 && iPole[x, y - 1] != 9)
        //                {
        //                    return true;
        //                }
        //                else
        //                    return false;
        //            case 2: //South
        //                if (iPole[x + 1, y] != 1 && iPole[x + 1, y] != 2 && iPole[x + 1, y] != 3 && iPole[x + 1, y] != 4 && iPole[x, y - 1] != 9)
        //                {
        //                    return true;
        //                }
        //                else
        //                    return false;
        //            case 3: //West
        //                if (iPole[x, y - 1] != 1 && iPole[x, y - 1] != 2 && iPole[x, y - 1] != 3 && iPole[x, y - 1] != 4 && iPole[x, y - 1] != 9)
        //                {
        //                    return true;
        //                }
        //                else
        //                    return false;
        //        }
        //        return false;
        //    }
        //    catch(System.IndexOutOfRangeException ex)
        //    {
        //        return false;
        //    }
        //}

        static bool CheckFCoord(Coordinats.Coord c, int d)
        {
            int x, y;
            x = c.GetX();
            y = c.GetY();
            try
            {
                switch (d)
                {
                    case 0: //Nort
                        if (fPole[x - 1, y].GetVal() == Field.cVoid)
                        {
                            return true;
                        }
                        else
                            return false;
                    case 1: //East
                        if (fPole[x, y + 1].GetVal() == Field.cVoid)
                        {
                            return true;
                        }
                        else
                            return false;
                    case 2: //South
                        if (fPole[x + 1, y].GetVal() == Field.cVoid)
                        {
                            return true;
                        }
                        else
                            return false;
                    case 3: //West
                        if (fPole[x, y - 1].GetVal() == Field.cVoid)
                        {
                            return true;
                        }
                        else
                            return false;
                }
            }
            catch (System.Exception ex)
            {
                return false;
            }
            return false;
        }

        public static void InicSTab()
        {
            sTab[0] = new Field.Symb("01300", '╔');
            sTab[1] = new Field.Symb("02230", '╦');
            sTab[2] = new Field.Symb("01200", '╗');
            sTab[3] = new Field.Symb("02120", '╠');
            sTab[4] = new Field.Symb("03123", '╬');
            sTab[5] = new Field.Symb("02130", '╣');
            sTab[6] = new Field.Symb("01100", '╚');
            sTab[7] = new Field.Symb("42120", '╩');
            sTab[8] = new Field.Symb("41100", '╝');
            sTab[9] = new Field.Symb("41200", '═');
            sTab[10] = new Field.Symb("11300", '║');
            sTab[11] = new Field.Symb("31000", '╔');
            sTab[12] = new Field.Symb("12000", '╠');
            sTab[13] = new Field.Symb("11000", '╚');
            sTab[14] = new Field.Symb("11400", '╝');
            sTab[15] = new Field.Symb("21400", '═');
            sTab[16] = new Field.Symb("11300", '║');
            /*sTab[17] = new Field.Symb("00000", '█');
            sTab[18] = new Field.Symb("00000", '█');
            sTab[19] = new Field.Symb("00000", '█');
            sTab[20] = new Field.Symb("00000", '█');
            sTab[21] = new Field.Symb("00000", '█');
            sTab[22] = new Field.Symb("00000", '█');*/
        }

        //static void GenForPath(int iPathLen, int iCoun)
        //{
        //    int iFTecDir, iFTecPov, iFTecPath = 0;
        //    iFTecPath = iFTecPath + iCoun;
        //    for (int p = 0; p < iPathLen; p++ )
        //    {
        //        using (System.IO.StreamWriter file = new System.IO.StreamWriter(Environment.CurrentDirectory + @"\log.txt", true))
        //        {
        //            file.WriteLine("TEST {0} {1} {2}", p, iCountPov, iCountEndPath);
        //        }
        //        iFTecDir = ElementPath.CheckDir(rndDir.Next(0, 101));
        //        iFTecPov = ElementPath.CheckPov(rndPov.Next(0,101));
        //        /*Устанавливаем направление*/
        //        ep[iFTecPath].SetDirection(iFTecDir);
        //        /*Устанавливаем поворот*/
        //        ep[iFTecPath].SetPovorot(iFTecPov);
        //        if (iFTecPov == 0)
        //        {
        //            if (CheckCoord(ep[iFTecPath].Cord, iFTecDir) == true)
        //            {
        //                /*Установить элемент пути*/
        //                ep[iFTecPath].SetCoord(SetPosPath(ep[iFTecPath].Cord, iFTecPath, iFTecDir));
        //                iPathLen--;
        //                bLuck = true;
        //            }
        //            else
        //            {
        //                p--;
        //                bLuck = false;
        //            }
        //        }
        //        else
        //        {
        //            if (iCountPov != 0)
        //            {
        //                if (iCountEndPath > iFTecPath)
        //                {
        //                    for (int p2 = 0; p2 < iFTecPov; p2++)
        //                    {
        //                        GenForPath(GenSymplePath(iFTecPath + 1, ep[iFTecPath].Cord.GetX(), ep[iFTecPath].Cord.GetY()), iFTecPath+1);
        //                    }
        //                    iCountEndPath--;
        //                }
        //                iCountPov--;
        //            }
        //        }
        //    }
        //}

        static Coordinats.Coord SetPosFPath(Coordinats.Coord c, int iPath, int d, int p)
        {
            int x, y;
            x = c.GetX();
            y = c.GetY();
            switch (d)
            {
                case 0:
                    //iPole[x - 1, y] = 1;
                    fPole[x, y].SetValue(/*Field.cCUPer*/GetNextEl(ep[iPath].GetPrevDirInt(),p,d), ep[iPath]); //= 1;
                    ep[iPath].SetCoord(c);
                    Console.WriteLine("ZN {0} DIR 0 NEW X{1} NEW Y{2} X{3} Y{4}", 1, x - 1, y, x, y);
                    return new Coordinats.Coord(x - 1, y);
                case 1:
                    //iPole[x, y + 1] = 2;
                    fPole[x, y].SetValue(GetNextEl(ep[iPath].GetPrevDirInt(), p, d), ep[iPath]); 
                    ep[iPath].SetCoord(c);
                    Console.WriteLine("ZN {0} DIR 1 NEW X{1} NEW Y{2} X{3} Y{4}", 2, x, y + 1, x, y);
                    return new Coordinats.Coord(x, y + 1);
                case 2:
                    //iPole[x + 1, y] = 3;
                    fPole[x, y].SetValue(GetNextEl(ep[iPath].GetPrevDirInt(), p, d), ep[iPath]); 
                    ep[iPath].SetCoord(c);
                    Console.WriteLine("ZN {0} DIR 2 NEW X{1} NEW Y{2} X{3} Y{4}", 3, x + 1, y, x, y);
                    return new Coordinats.Coord(x + 1, y);
                case 3:
                    //iPole[x, y - 1] = 4;
                    fPole[x, y].SetValue(GetNextEl(ep[iPath].GetPrevDirInt(), p, d), ep[iPath]); 
                    ep[iPath].SetCoord(c);
                    Console.WriteLine("ZN {0} DIR 3 NEW X{1} NEW Y{2} X{3} Y{4}", 4, x, y - 1, x, y);
                    return new Coordinats.Coord(x, y - 1);
            }
            return new Coordinats.Coord(c);
        }

        static void GenForFPath(int iPathLen, int iCoun, int iFTP = 0)
        {
            int iFTecDir, iFTecPov, iFTecPath = 0;
            iFTecPath = iFTecPath + iCoun;
            for (int p = 0; p < iPathLen; p++)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(Environment.CurrentDirectory + @"\log.txt", true))
                {
                    file.WriteLine("TEST {0} {1} {2}", p, iCountPov, iCountEndPath);
                }
                iFTecDir = ElementPath.CheckDir(rndDir.Next(0, 101));
                iFTecPov = ElementPath.CheckPov(rndPov.Next(0, 101));
                /*Устанавливаем направление*/
                ep[iFTecPath].SetDirection(iFTecDir);
                /*Устанавливаем поворот*/
                ep[iFTecPath].SetPovorot(iFTecPov);
                if (iFTecPov == 0)
                {
                    if (CheckFCoord(ep[iFTecPath].Cord[ep[iFTecPath].Cord.Count-1], iFTecDir) == true)
                    {
                        /*Установить элемент пути*/
                        ep[iFTecPath].SetCoord(SetPosFPath(ep[iFTecPath].Cord[ep[iFTecPath].Cord.Count - 1], iFTecPath, iFTecDir, iFTP));
                        iPathLen--;
                        bLuck = true;
                    }
                    else
                    {
                        p--;
                        bLuck = false;
                    }
                }
                /*Доп путь*/
                else
                {
                    if (iCountPov != 0)
                    {
                        if (iCountEndPath > iFTecPath)
                        {
                            for (int p2 = 0; p2 < iFTecPov; p2++)
                            {
                                GenForFPath(GenSymplePath(iFTecPath + 1, ep[iFTecPath].Cord[ep[iFTecPath].Cord.Count - 1].GetX(), ep[iFTecPath].Cord[ep[iFTecPath].Cord.Count - 1].GetY()), iFTecPath + 1, iFTecPov);
                            }
                            iCountEndPath--;
                        }
                        iCountPov--;
                    }
                }
            }
        }

        static char GetNextEl(int iIn, int iCountIn, int iDir)
        {
            string sCode = String.Format("{0}{1}{2}{3}{4}",iIn,iCountIn,iDir,0,0);
            foreach (Field.Symb c in sTab)
            {
                Console.WriteLine("{0}{1}{2}{3}{4} {5} {6}", iIn, iCountIn, iDir, 0, 0, sCode, c.sCode);
                if (c.sCode == sCode)
                    return c.cSym;
            }
            return Field.cVoid;
        }

        static int GenSymplePath(int iPathNum, int iX, int iY)
        {
            int iTempPath;
            /*Генерация длины пути*/
            iTempPath = rndLP.Next(500, 1000);
            /*Инициализация текущего направления на восток или юг*/
            iTecDir = rndDir.Next(0, 4);
            /*Инициализация главного пути*/
            ep[iPathNum] = new ElementPath(iTempPath, 0, 0, iTecDir, iX, iY);
            return iTempPath;
        }    
    
        /*static int GetStartPath(int i)
        {
            if (ep[i].Cord[ep[i].Cord.Count-1] == ep[i].Cord[ep[i].Cord.Count-2])

        }*/
    }
}
