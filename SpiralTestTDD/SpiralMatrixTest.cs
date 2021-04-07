using Moq;
using NUnit.Framework;
using SpiralMatrix.TDDExample;
using System.Collections.Generic;

namespace SpiralMatrixTest.TDDExample
{
    public class SpiralMatrixTest
    {
        ISpiralMatrix matrixObj = null;
        Mock<ISpiralMatrix> mockRepo = null;
        int maxCountToTest = 20;
        int minCountToTest = 5;

        [SetUp]        
        public void Setup()
        {
            matrixObj = new SpiralMatrix.TDDExample.SpiralMatrix();
            mockRepo = new Mock<ISpiralMatrix>();
        }
        //inntilal boundery tests before implementation...
        [Test, Order(1)]
        [Category("BasicTests")]
        public void BounderyTest_with_Default()
        {          
            int[,] matrix = matrixObj.ComputeMatrix();          
            //Check default MatrixSize will give expected value.
            Assert.IsTrue(matrix != null && matrix.GetLength(0) == 0 && matrix.GetLength(1) == 0);
        }
       

        [Test, Order(2)]
        [Category("BasicTests")]
        public void BounderyTest_with_NegativeIntegers()
        {
            matrixObj.MatrixSize = -1;
            int[,] matrix = matrixObj.ComputeMatrix();
            //Check  negative value will give expected value.
            Assert.IsTrue(matrix == null);
        }

        [Test, Order(3)]
        [Category("BasicTests")]

        public void BounderyValueTest_with_N_equals_one()
        {
            matrixObj.MatrixSize = 1;
            int[,] matrix = matrixObj.ComputeMatrix();           
            Assert.IsTrue(matrix.Length == 1 && matrix[0,0] == 1);
        }

        [Test, Order(4)]
        [Category("BasicTests")]
        public void BounderyValueTest_with_N_equals_two()
        {
            matrixObj.MatrixSize = 2;
            int[,] matrix = matrixObj.ComputeMatrix();
            List<string> indxedOnes = ExpectedMockData.ExpectedData.Prepare_Matrix_ValidationData_With_Expected_Indexed_with_Ones(2);
            CompareUtils.CompareResults(matrix, indxedOnes);
        }

        [Test, Order(5)]
        [Category("BasicTests")]
        public void BounderyValueTest_with_min_N_and_max_N()
        {
            for (int i = minCountToTest; i < maxCountToTest; i++)
            {
                matrixObj.MatrixSize = i;
                int[,] matrix = matrixObj.ComputeMatrix();
                List<string> indxedOnes = ExpectedMockData.ExpectedData.Prepare_Matrix_ValidationData_With_Expected_Indexed_with_Ones(i);
                CompareUtils.CompareResults(matrix, indxedOnes);
                
            }
        }

        [Test, Order(6)]
        [Category("BasicTests")]
        public void BounderyValueTest_with_max_N()
        {
            for (int i = 0; i < maxCountToTest; i++)
            {
                matrixObj.MatrixSize = i;
                int[,] matrix = matrixObj.ComputeMatrix();
                List<string> indxedOnes = ExpectedMockData.ExpectedData.Prepare_Matrix_ValidationData_With_Expected_Indexed_with_Ones(i);
                CompareUtils.CompareResults(matrix, indxedOnes);               
            }
        }

        [Test, Order(7)]
        [Category("BasicTests")]
        public void MockData_test_with_sampleData_even_number()
        {           
            //Mock with dependency injection to prepare sample object and operate on it...
            mockRepo.Setup(x => (x.ComputeMatrix())).Returns(ExpectedMockData.ExpectedData.expectedArrayWithEvenNumber);
            int[,] matrix = mockRepo.Object.ComputeMatrix();
            List<string> indxedOnes = ExpectedMockData.ExpectedData.Prepare_Matrix_ValidationData_With_Expected_Indexed_with_Ones(6);
            CompareUtils.CompareResults(matrix, indxedOnes);

        }

        [Test, Order(8)]
        [Category("BasicTests")]
        public void MockData_test_with_sampleData_odd_number()
        {          
            mockRepo.Setup(x => (x.ComputeMatrix())).Returns(ExpectedMockData.ExpectedData.expectedArraWithOddNumber);
            int[,] matrix = mockRepo.Object.ComputeMatrix();
            List<string> indxedOnes = ExpectedMockData.ExpectedData.Prepare_Matrix_ValidationData_With_Expected_Indexed_with_Ones(5);
            CompareUtils.CompareResults(matrix, indxedOnes);

        }

    }

}