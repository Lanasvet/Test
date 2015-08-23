using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestKottan
{
    public static class MathHelper
    {

        //нахождение наибольшего общего делителя (Алгоритм Евклида)
        public static int FindingGCD(int a, int b)
        {
            int GCD, max, min;
            
            if (Math.Abs(a) == Math.Abs(b))
            {
                GCD = Math.Abs(a);
                return GCD;
            }
            else if (Math.Abs(a) < Math.Abs(b))
            {                
                max = Math.Abs(b);
                min = Math.Abs(a);
            }
            else
            {
                max = Math.Abs(a);
                min = Math.Abs(b);
            }
            
            if(min == 0)
            {
                GCD = max;
                return GCD;
            }           

            do{

                int temp = max % min;
                if (temp == 0)
                {
                    GCD = min;
                    return GCD;
                }
                else
                {
                    max = min;
                    min = temp;
                }
            } while (true);
        }

        //Нахождение наименьшего общего кратного
        public static int FindingLCM(int a, int b)
        {
            int LCM = Math.Abs(a * b) / FindingGCD(a, b);
            return LCM;
        }

        //нахождение коэфициента для умножения рада  --a--
        public static int FindingСoefficient(int a, int b)
        {
            int LCM = FindingLCM(a, b);

            if (LCM == 0)
                return 1;
            else
                return LCM / a;
        } 
   
    }
}
