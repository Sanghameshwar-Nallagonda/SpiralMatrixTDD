using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpiralMatrixTest
{
    public static class CompareUtils
    {
        public static void CompareResults(int[,] matrix, List<string> indxedOnes)
        {
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                for (int k = 0; k < matrix.GetLength(1); k++)
                {
                    if (matrix[j, k] == 1)
                    {
                        if (indxedOnes.Contains("[" + j + "," + k + "]"))
                        {
                            continue;
                        }
                        else
                        {
                            Assert.Fail("Validation Failed at Index [" + j + ", " + k + "] Unexpected value at this position is 1 . MatrixSize :"+ matrix.GetLength(0));
                        }
                    }
                    else if (matrix[j, k] == 0)
                    {
                        if (indxedOnes.Contains("[" + j + "," + k + "]"))
                        {
                            Assert.Fail("Validation Failed at Index [" + j + ", " + k + "] Unexpected value at this position is 0. MatrixSize :" + matrix.GetLength(0));
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        Assert.Fail("Validation Failed at Index [" + j + ", " + k + "] Unexpected value at this position is " + matrix[j, k] + " MatrixSize :" + matrix.GetLength(0));
                    }
                }
            }
        }
    }
}
