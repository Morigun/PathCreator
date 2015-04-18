using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathCreator
{
    class Program
    {
        static ElementPath[] ep;
        /*Текущий путь*/
        static int iTecPath = 0;
        static int iX = 50, iY = 50;
        /*Поле*/
        static int[,] iPole = new int[iX, iY];
        /*Кол-во тупиков*/
        static int iCountEndPath;
        /*Кол-во поворотов*/
        static int iCountPov;
        /*Длина пути*/
        static int iLengthPath;
        /*Текущее направление*/
        static int iTecDir;
        /*Текущий поворот*/
        static int iTecPov;
        static bool bLuck;
        static Random rndCEP = new Random();
        static Random rndCP = new Random();
        static Random rndLP = new Random();
        static Random rndDir = new Random();
        static Random rndPov = new Random();
        static void Main(string[] args)
        {
            /*Инициализация поля*/
            InicPole();
            /*Вывод поля*/
            VivodPole();
            Console.WriteLine("GENERATE");
            /*Генерация кол-ва тупиков*/
            iCountEndPath = rndCEP.Next(1, 6);
            /*Генерация кол-ва поворотов*/
            iCountPov = rndCP.Next(5, 11);
            /*Генерация длины пути*/
            iLengthPath = rndLP.Next(70, 101);
            /*Инициализируем тупики + основной путь*/
            ep = new ElementPath[iCountEndPath+1];
            /*Инициализация текущего направления на восток или юг*/
            iTecDir = rndDir.Next(1, 3);
            /*Инициализация главного пути*/
            ep[0] = new ElementPath(iLengthPath, 0, 0, iTecDir, 0, 0);
            /*Цикл заполнения поля*/
            for (int p = 0; p < iLengthPath; p++ )
            {
                
                if (p == 0)
                {
                    /*Генерируем направление*/
                    iTecDir = rndDir.Next(1, 3);
                }
                else
                {
                    /*Генерируем направление*/
                    iTecDir = rndDir.Next(0, 4);
                }
                /*Генерируем поворот*/
                iTecPov = rndPov.Next(0, 3);
                /*Устанавливаем направление*/
                //ep[iTecPath].SetDirection(iTecDir);
                /*Устанавливаем поворот*/
                //ep[iTecPath].SetPovorot(iTecPov);
                if (CheckCoord(ep[iTecPath].Cord, iTecDir) == true)
                {
                    /*Установить элемент пути*/
                    ep[iTecPath].SetCoord(SetPosPath(ep[iTecPath].Cord, iTecPath, iTecDir));
                    iLengthPath--;
                    bLuck = true;
                }
                else
                    p--;
                bLuck = false;
            }
            VivodPole();
            Console.ReadLine();
        }

        static void InicPole()
        {
            for (int x = 0; x < iX; x++)
                for (int y = 0; y < iY; y++)
                    iPole[x, y] = 0;
            iPole[0, 0] = 1;
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

        static Coordinats.Coord SetPosPath(Coordinats.Coord c, int iPath, int d)
        {
            int x, y;
            x = c.GetX();
            y = c.GetY();
            switch (d)
            {
                case 0:                    
                    iPole[x - 1, y] = 1;
                    ep[iPath].SetCoord(c);
                    Console.WriteLine("ZN {0} DIR 0 NEW X{1} NEW Y{2} X{3} Y{4}", 1, x - 1, y, x, y);
                    return new Coordinats.Coord(x - 1, y);
                case 1:
                    iPole[x, y + 1] = 2;
                    ep[iPath].SetCoord(c);
                    Console.WriteLine("ZN {0} DIR 1 NEW X{1} NEW Y{2} X{3} Y{4}", 2, x, y + 1, x, y);
                    return new Coordinats.Coord(x, y + 1);
                case 2:
                    iPole[x + 1, y] = 3;
                    ep[iPath].SetCoord(c);
                    Console.WriteLine("ZN {0} DIR 2 NEW X{1} NEW Y{2} X{3} Y{4}", 3, x + 1, y, x, y);
                    return new Coordinats.Coord(x + 1, y);
                case 3:
                    iPole[x, y - 1] = 4;
                    ep[iPath].SetCoord(c);
                    Console.WriteLine("ZN {0} DIR 3 NEW X{1} NEW Y{2} X{3} Y{4}", 4, x, y - 1, x, y);
                    return new Coordinats.Coord(x, y - 1);
            }
            return new Coordinats.Coord(c);
        }

        static bool CheckCoord(Coordinats.Coord c, int d)
        {
            int x, y;
            x = c.GetX();
            y = c.GetY();
            try
            {
                switch (d)
                {
                    case 0: //Nort
                        if (iPole[x - 1, y] != 1 && iPole[x - 1, y] != 2 && iPole[x - 1, y] != 3 && iPole[x - 1, y] != 4)
                        {
                            return true;
                        }
                        else
                            return false;
                    case 1: //East
                        if (iPole[x, y + 1] != 1 && iPole[x, y + 1] != 2 && iPole[x, y + 1] != 3 && iPole[x, y + 1] != 4)
                        {
                            return true;
                        }
                        else
                            return false;
                    case 2: //South
                        if (iPole[x + 1, y] != 1 && iPole[x + 1, y] != 2 && iPole[x + 1, y] != 3 && iPole[x + 1, y] != 4)
                        {
                            return true;
                        }
                        else
                            return false;
                    case 3: //West
                        if (iPole[x, y - 1] != 1 && iPole[x, y - 1] != 2 && iPole[x, y - 1] != 3 && iPole[x, y - 1] != 4)
                        {
                            return true;
                        }
                        else
                            return false;
                }
                return false;
            }
            catch(System.IndexOutOfRangeException ex)
            {
                return false;
            }
        }
    }
}
