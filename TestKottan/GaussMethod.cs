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


        public void DirectPass()
        {
            int row_WSE;

            for (int col = 0, row = 0; col < 4 && row < 4; col++, row++)
            {
                row_WSE = matrix.SearchSupportElement(row, col);
                matrix.MoveLineInTempMatrix(row, row_WSE);                
                row_WSE = row;
                for(int j = row + 1; j < 4; j++)
                {
                    if(matrix.tempMatrix[j][col] != 0)
                    matrix.StepToTriangularForm( row_WSE, j, col);
                }                        
               
            }
        }

        public void ReversePass()
        {
            double x3 = matrix.tempMatrix[3][4] / matrix.tempMatrix[3][3];
            double x2 = (matrix.tempMatrix[2][4] - matrix.tempMatrix[2][3] * x3) / matrix.tempMatrix[2][2];
            double x1 = (matrix.tempMatrix[1][4] - matrix.tempMatrix[1][3] * x3 - matrix.tempMatrix[1][2] * x2) / matrix.tempMatrix[1][1];
            double x0 = (matrix.tempMatrix[0][4] - matrix.tempMatrix[0][3] * x3 - matrix.tempMatrix[0][2] * x2 - matrix.tempMatrix[0][1] * x1) / matrix.tempMatrix[0][0];
            answer = new double[] { x0, x1, x2, x3 };
        }

        public void ShowAnswer()
        {
            for (int i = 0; i < 4; i++)
            {
                Console.Write(answer[i] + "\t ");
            }
            Console.WriteLine("-----------------------");
        }

        public void Check()
        {
            double[] ans = answer;
                /*new double[]{
                -0.01367,
                1.2136,
                0.2936,
                -1.5473
            };*/

            double a = 0;
            for(int i = 0; i < 4; i++)
            {
                a = matrix.sourceMatrix[i][0] * ans[0] + matrix.sourceMatrix[i][1] * ans[1] + matrix.sourceMatrix[i][2] * ans[2] + matrix.sourceMatrix[i][3] * ans[3];                  
               
                Console.WriteLine(a + " ~~~ " + matrix.sourceMatrix[i][4]);
            }
        }
       
    }
}
