﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestKottan
{
    public class Matrix
    {
      
        public int[][] sourceMatrix = new int[][]
        {
            new int[]{-3,4,1,4,-1},
            new int[]{0,1,3,2,-1},
            new int[]{4,0,-2,-3,4},
            new int[]{1000,3,1,-5,-2}     
        };

        public double[][] tempMatrix = new double[][]
        {
            new double[]{-3,4,1,4,-1},
            new double[]{0,1,3,2,-1},
            new double[]{4,0,-2,-3,4},
            new double[]{1000,3,1,-5,-2}     
        };

       
        public void ShowSourceMatrix()
        {            
            Console.WriteLine("-3x1 + 4x2 + x3 + 4x4 = -1");
            Console.WriteLine("1x2 + 3x3 + 2x4 = -1");
            Console.WriteLine("4x1 - 2x3 - 3x4 = 4");
            Console.WriteLine("1000x1 + 3x2 + x3 - 5x4 = -2");
        }

        public void ShowTempMatrix()
        {            
            for (int z = 0; z < 4; z++)
            {
                int j;
                for (j = 0; j < 4; j++)
                {
                    Console.Write("{0, 15}", tempMatrix[z][j]);
                }
                Console.Write("{0, 15}", tempMatrix[z][j]);
                Console.WriteLine();
            }            
        }
       
        //нахождение опорного элемента в строке 
        public int SearchSupportElement (int fromRow, int inColumn)  
        {
            //in_row - номер строки finalMatrix куда будем перемещать строку с опорным(главным) элементом
            //out-row - номер строки matrix откуда будем брать строку с опорным(главным) элементом
            int out_row = fromRow;
            double max = Math.Abs(tempMatrix[fromRow][inColumn]);

            for (int i = fromRow; i < 4; i++ )
            {
                if (Math.Abs(tempMatrix[i][inColumn]) > max)
                {
                    out_row = i;
                    max = tempMatrix[out_row][inColumn];
                }               
            }            
            return out_row;
        }

        //перестановка строк в матрице
        public void MoveLineInTempMatrix(int toRow, int fromRow)
        {
            double[] tempRow = new double[5];

            for (int colum = 0; colum < 5; colum++)
            {
                tempRow[colum] = tempMatrix[toRow][colum];
                tempMatrix[toRow][colum] = tempMatrix[fromRow][colum];
                tempMatrix[fromRow][colum] = tempRow[colum];
            }            
        }



        public void MultiplyLineByTheNumber(double[] Line, double number)
        {
            for (int i = 0; i < 5; i++)
            {
                Line[i] = Line[i] * number;
            }
        }

        public double[] SubtractRow(int row, double[] Line1, double[] Line2)
        {
            double[] temp = new double[5];
            for(int i = 0; i < 5; i++)
            {
                temp[i] = Line1[i] - Line2[i];
            }
            return temp;
        }

        public void StepToTriangularForm(int row_WSE, int row, int column)
        {
            double[] tempRow = new double[5];
            for(int i = 0; i < 5; i++)
            {
                tempRow[i] = tempMatrix[row_WSE][i];
            }

            double[] insteadRow = new double[5];
            for (int i = 0; i < 5; i++)
            {
                insteadRow[i] = tempMatrix[row][i];
            }
            double multiplier_temp = insteadRow[column];
            double multiplier_instead = tempRow[column];
            MultiplyLineByTheNumber(tempRow, multiplier_temp);
            MultiplyLineByTheNumber(insteadRow, multiplier_instead);
            tempMatrix[row] = SubtractRow(row, tempRow, insteadRow); 
        }
      
    }
}
