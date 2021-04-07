using System;
using System.Collections.Generic;
using System.Text;

namespace SpiralMatrixTest.ExpectedMockData
{
    public static class ExpectedData
    {

        public static int[,] expectedArrayWithEvenNumber = new int[6, 6]{
                                {1 ,  1 ,  1 ,  1 ,  1 ,  1},
                                {0 ,  0 ,  0  , 0 ,  0 ,  1},
                                {1 ,  1  , 1 ,  1 ,  0 ,  1},
                                {1  , 0 ,  0  , 1,   0 ,  1},
                                {1 ,  0  , 0 ,  0 ,  0 ,  1},
                                {1 ,  1  , 1 ,  1 ,  1 ,  1}
                            };

        public static int[,] expectedArraWithOddNumber = new int[5, 5]{
                                {1 ,  1 ,  1  , 1 ,  1},
                                {0  , 0 ,  0 ,  0 ,  1},
                                {1 ,  1  , 1 ,  0  , 1},
                                {1 ,  0 ,  0  , 0  , 1},
                                {1 ,  1  , 1  , 1 ,  1}                                
                            };

        public static List<string> Prepare_Matrix_ValidationData_With_Expected_Indexed_with_Ones(int size)
        {
            List<string> indexes = new List<string>();
            int n = size;
            int[,] matrix = new int[n, n];
            if (n >= 0)
            {
                int top = 0, bottom = n - 1;
                int left = 0, right = n - 1;
                while (true)
                {
                    if (left > right)
                    {
                        break;
                    }
                    int updatedColCount = 0;
                    for (int i = left; i <= right; i++)
                    {
                        if ((right >= i + 1 && matrix[top, i + 1] == 0) || i == n - 1)
                        {
                            {
                                matrix[top, i] = 1;
                                indexes.Add("[" + top + "," + i + "]");
                            }
                            updatedColCount = i;
                        }
                    }
                    top++;

                    if (top > bottom)
                    {
                        if (top <= n - 1 && matrix[top, updatedColCount] == 1 && updatedColCount != 0)
                        {
                            if (matrix[top - 1, updatedColCount] != 0)
                            {
                                var itemToRemove = indexes.FindIndex(r => r == "[" + (top - 1) + "," + updatedColCount + "]");
                                indexes.RemoveAt(itemToRemove);                               
                            }
                        }
                        break;
                    }
                    right = updatedColCount;
                    int updatedCRowCount = 0;
                    for (int i = top; i <= bottom; i++)
                    {
                        if ((bottom >= i + 1 && matrix[i + 1, right] == 0) || i == n - 1)
                        {
                            matrix[i, right] = 1;
                            indexes.Add("[" + i + "," + right + "]");
                            updatedCRowCount = i;
                        }
                    }
                    right = right - 1;
                    if (left > right)
                    {
                        if (left <= n - 1 && matrix[left, updatedCRowCount] == 1 && updatedCRowCount != 0)
                        {
                            if (matrix[updatedCRowCount, right + 1] != 0)
                            {
                                //indexes.Remove("[" + updatedCRowCount + "," + (right + 1) + "]");
                                var itemToRemove = indexes.FindIndex(r => r == "[" + updatedCRowCount + "," + (right + 1) + "]");
                                indexes.RemoveAt(itemToRemove);

                            }
                        }
                        break;
                    }
                    bottom = updatedCRowCount;
                    int updatedCUpCount = 0;
                    for (int i = right; i >= left; i--)
                    {
                        if ((left <= i - 1 && matrix[bottom, i - 1] == 0) || bottom == n - 1)
                        {
                            matrix[bottom, i] = 1;
                            indexes.Add("[" + bottom + "," + i + "]");
                            updatedCUpCount = i;
                        }
                    }
                    bottom--;

                    if (top > bottom)
                    {
                        if (top <= n - 1 && matrix[top, updatedCUpCount] == 1 && updatedCUpCount != 0)
                        {
                            if (matrix[bottom + 1, updatedCUpCount] != 0)
                            {
                                //indexes.Remove("[" + (bottom + 1) + "," + updatedCUpCount + "]");
                                var itemToRemove = indexes.FindIndex(r => r == "[" + (bottom + 1) + "," + updatedCUpCount + "]");
                                indexes.RemoveAt(itemToRemove);

                            }
                        }
                        break;
                    }
                    left = updatedCUpCount;

                    int rowWhenItEnded = 0;

                    for (int i = bottom; i >= top; i--)
                    {
                        if ((top <= i - 1 && matrix[i - 1, left] == 0))
                        {
                            matrix[i, left] = 1;
                            indexes.Add("[" + i + "," + left + "]");
                            rowWhenItEnded = i;
                        }
                    }
                    left++;

                    if (left > right)
                    {
                        if (left <= n - 1 && matrix[left, rowWhenItEnded] == 1 && rowWhenItEnded != 0)
                        {
                            if (matrix[rowWhenItEnded, left - 1] != 0)
                            {
                                //indexes.Remove("[" + rowWhenItEnded + "," + (left - 1) + "]");
                                var itemToRemove = indexes.FindIndex(r => r == "[" + rowWhenItEnded + "," + (left - 1) + "]");
                                indexes.RemoveAt(itemToRemove);
                            }
                        }
                    }
                    top += 1;
                }
            }
            else
            {
                // return true;
            }
            return indexes;

        }

    }
}
