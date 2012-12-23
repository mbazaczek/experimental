using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cszarp_test
{
    class Program
    {
        static void Main(string[] args)
        {
            int i=10;
            Bobek bobek1 = new Bobek();

            for (i=0;i<10;i++)
            {
                if (i % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else 
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine( bobek1.sraj(i) );
                Console.ReadLine();
            }
      
        }
    }
}
