using System;
using System.Collections.Generic;
using System.Text;

namespace SpiralMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            SpiralMatrix.TDDExample.SpiralMatrix test = new SpiralMatrix.TDDExample.SpiralMatrix();
            test.MatrixSize = 5;
            for (int i = 5; i <= 10; i++)
            {
                test.MatrixSize = i;
                int[,] matrix = test.ComputeMatrix();
                Console.WriteLine("------------------------------------------------------");
            }
        }
    }
}
