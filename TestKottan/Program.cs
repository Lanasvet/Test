using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestKottan
{
    class Program
    {
        static void Main(string[] args)
        {
            GaussMethod gm = new GaussMethod();
           
            gm.matrix.ShowSourceMatrix();
            gm.DirectPass();

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            gm.matrix.ShowTempMatrix();

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            gm.ReversePass();
            gm.ShowAnswer();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            gm.Check();
            Console.ReadKey();
        }
    }
}
