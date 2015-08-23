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
            Console.WriteLine("Данна система линейных алгебраических уравнений: \n");           
            gm.matrix.ShowSourceMatrix();            
            Console.WriteLine("\nРешить СЛАУ  методом Гаусса с выбором главного элемента по ряду.");
            Console.WriteLine("\nПрямой ход метода:");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            gm.DirectPass();            
            Console.WriteLine("\n В результате получаем треугольную матрицу \n");
            gm.matrix.ShowTempMatrix();

            Console.WriteLine("\n Обратный ход метода:");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("\n Решаем последнее уравнение. Результат подставляем в предпоследнее ... и так далее...");
            gm.ReversePass();
                     
            
            Console.Write("\n Получаем матрицу: Х {");
            gm.ShowLine(gm.answer);
            Console.Write("}\n");            
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("\n Делаем проверку, подставляя найденные значения в каждую строку системы: \n");   
            gm.Check();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.Write("\n Вектор решения: Х {");
            gm.ShowLine(gm.answer);
            Console.Write("}\n");    
            Console.Write("\n Вектор невязок: Е {");
            gm.ShowLine(gm.E);
            Console.Write("}");

            Console.ReadKey();
        }
    }
}
