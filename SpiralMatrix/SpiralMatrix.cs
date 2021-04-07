using System;
using System.Collections.Generic;

namespace SpiralMatrix.TDDExample
{
    public interface ISpiralMatrix
    {
        int MatrixSize { get; set; }
		int[,] ComputeMatrix();
    }

    public class SpiralMatrix : ISpiralMatrix
    {
        public int MatrixSize { get; set; }

        public int[,] ComputeMatrix()
        {
            int n = MatrixSize;       
            if (n >= 0)
            {
                int[,] matrix = new int[n, n];
                int top = 0, bottom = n - 1;
                int left = 0, right = n - 1;               

                while (true)
                {
                    if (left > right)
                    {
                        break;
                    }
                    // Moving right.................
                    int updatedColCount = 0;
                    for (int i = left; i <= right; i++)
                    {
                        if ((right >= i + 1 && matrix[top, i + 1] == 0) || i == n - 1)
                        {
                            Console.Write("[" + top + "," + i + "]  ");
                            matrix[top, i] = 1;
                            updatedColCount = i;
                        }
                        
                    }
                    top++;

                    if (top > bottom)
                    {
                        if (top <= n - 1 && matrix[top, updatedColCount] == 1 && updatedColCount != 0)
                        {
                            matrix[top - 1, updatedColCount] = 0;
                            Console.WriteLine("Now setting zero on right move...");
                            Console.Write("[" + (top - 1) + "," + updatedColCount + "]  ");
                        }
                        break;
                    }
                    Console.WriteLine("We are done with the right..");
                    right = updatedColCount;




                    // Moving down.................
                    int updatedCRowCount = 0;
                    for (int i = top; i <= bottom; i++)
                    {

                        if ((bottom >= i + 1 && matrix[i + 1, right] == 0) || i == n - 1)
                        {
                            Console.Write("[" + i + "," + right + "]  ");
                            matrix[i, right] = 1;
                            updatedCRowCount = i;
                        }
                    }
                    right = right - 1;
                    if (left > right)
                    {
                        if (left <= n - 1 && matrix[left, updatedCRowCount] == 1 && updatedCRowCount != 0)
                        {
                            Console.WriteLine("Now setting zero on bottom move...");
                            Console.Write("[" + updatedCRowCount + "," + right + 1 + "]  ");
                            matrix[updatedCRowCount, right + 1] = 0;
                        }
                        break;
                    }
                    Console.WriteLine("We are done with the bottom..");
                    bottom = updatedCRowCount;
                    int updatedCUpCount = 0;


                    // Moving left.................
                    for (int i = right; i >= left; i--)
                    {
                        if ((left <= i - 1 && matrix[bottom, i - 1] == 0) || bottom == n - 1)
                        {
                            Console.Write("[" + bottom + "," + i + "]  ");
                            matrix[bottom, i] = 1;//count++;
                            updatedCUpCount = i;
                        }
                    }
                    bottom--;
                    if (top > bottom)
                    {
                        //if (!(bottom + 1 == 0 && updatedCUpCount == 0))
                        if (top <= n - 1 && matrix[top, updatedCUpCount] == 1 && updatedCUpCount != 0)
                        {
                            Console.WriteLine("Now setting zero on left move...");
                            Console.Write("[" + (bottom + 1) + "," + updatedCUpCount + "]  ");
                            matrix[bottom + 1, updatedCUpCount] = 0;
                        }
                        break;
                    }
                    Console.WriteLine("We are done with the left..");
                    left = updatedCUpCount;



                    // Moving Up.................
                    int rowWhenItEnded = 0;

                    for (int i = bottom; i >= top; i--)
                    {
                        if ((top <= i - 1 && matrix[i - 1, left] == 0))
                        {
                            Console.Write("[" + i + "," + left + "]  ");
                            matrix[i, left] = 1;//count++;
                            rowWhenItEnded = i;
                        }
                    }
                    left++;

                    if (left > right)
                    {
                        if (left <= n - 1 && matrix[left, rowWhenItEnded] == 1 && rowWhenItEnded != 0)
                        {
                            Console.WriteLine("Now setting zero on top move...");
                            Console.Write("[" + rowWhenItEnded + "," + (left - 1) + "]  ");
                            matrix[rowWhenItEnded, left - 1] = 0;
                        }
                        // break;
                    }
                    Console.WriteLine("We are done with the top move..");
                    top += 1;


                }
                Console.WriteLine("");
                for (int r = 0; r < n; r++)
                {
                    for (int c = 0; c < n; c++)
                    {
                        Console.Write("{0, 4}", matrix[r, c]);
                    }
                    Console.WriteLine();
                }
                return matrix;
            }
            else
            {
                return null;
            }

        }
    }
}
