using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestKottan
{
    public class GaussMethod
    {
        public Matrix matrix = new Matrix();
        public double[] answer;
        public double[] E ;
        //Прямой ход
        public void DirectPass()
        {
            int row_WSE;

            for (int col = 0, row = 0; col < 4 && row < 4; col++, row++)
            {
                
                row_WSE = matrix.SearchSupportElement(row, col);
                Console.WriteLine("\n Главный(наибольший) элемент " + (col + 1) + "-ого  столбца находится в строке " + (row_WSE + 1) + "\n");
                matrix.ShowTempMatrix();
                Console.WriteLine("\n Меняем местами строки " + (row_WSE + 1) + " и " + (row + 1) + "\n");
                matrix.MoveLineInTempMatrix(row, row_WSE);
                matrix.ShowTempMatrix();
                row_WSE = row;
                Console.WriteLine("\n Исключаем неизвестное Х" + (col + 1) + " в уравнениях, ниже " + (row + 1) + "-ой строки " + "\n");
                for(int j = row + 1; j < 4; j++)
                {
                    if(matrix.tempMatrix[j][col] != 0)
                    matrix.StepToTriangularForm( row_WSE, j, col);
                }
                matrix.ShowTempMatrix();
            }
        }

        //Обратный ход
        public void ReversePass()
        {            
            answer = new double[] { 0, 0, 0, 0 };            
            for(int i = 3; i >= 0; i--)
            {
                answer[i] = (matrix.tempMatrix[i][4] - matrix.tempMatrix[i][3] * answer[3] - matrix.tempMatrix[i][2] * answer[2] - matrix.tempMatrix[i][1] * answer[1]) / matrix.tempMatrix[i][i]; 
            }          
        }
        
        //Показать строку
        public void ShowLine(double[]Line)
        {
            for (int i = 0; i < 4; i++)
            {
                Console.Write("{0,20}", Line[i]);
            }            
        }

        //Проверка
        public void Check()
        {           
            double AX = 0;
            E = new double[4];

            for(int i = 0; i < 4; i++)
            {
                Console.WriteLine(matrix.sourceMatrix[i][0] + "*" + answer[0] + " + " + matrix.sourceMatrix[i][1] + "*" + answer[1] + " + " + matrix.sourceMatrix[i][2] + "*" + answer[2] + " + " + matrix.sourceMatrix[i][3] + "*" + answer[3]);
                AX = matrix.sourceMatrix[i][0] * answer[0] + matrix.sourceMatrix[i][1] * answer[1] + matrix.sourceMatrix[i][2] * answer[2] + matrix.sourceMatrix[i][3] * answer[3];
                Console.WriteLine("\n Сравниваем результат: \n");  
                Console.WriteLine(AX + " = " + matrix.sourceMatrix[i][4] + "\n");
                E[i] = matrix.sourceMatrix[i][4] - AX;               
            }
           
        }
       
    }
}
