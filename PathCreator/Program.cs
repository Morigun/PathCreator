using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathCreator
{
    class Program
    {
        ElementPath[] ep;
        static int[,] iPole = new int[50, 50];
        static int iCountEndPath;
        static int iCountPov;
        static int iLengthPath;
        static int iTecDir;
        static Random rndCEP = new Random();
        static Random rndCP = new Random();
        static Random rndLP = new Random();
        static Random rndDir = new Random();
        static void Main(string[] args)
        {
            InicPole();
            VivodPole();
            iCountEndPath = rndCEP.Next(1, 5);
            iCountPov = rndCP.Next(5, 10);
            iLengthPath = rndLP.Next(10, 20);
            Console.WriteLine("{0},{1},{2}",iCountEndPath, iCountPov, iLengthPath);
            iTecDir = rndDir.Next(0, 3);

            Console.ReadLine();
        }

        static void InicPole()
        {
            for (int x = 0; x < 50; x++)
                for (int y = 0; y < 50; y++)
                    iPole[x, y] = 1;
        }

        static void VivodPole()
        {
            for (int x = 0; x < 50; x++)
            {
                for (int y = 0; y < 50; y++)
                {
                    Console.Write(iPole[x, y]);
                }
                Console.WriteLine();
            }
        }
    }
}
