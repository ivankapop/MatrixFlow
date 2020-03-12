using Microsoft.VisualStudio.TestTools.UnitTesting;
using MatrixFlowNS;
using System.IO;
using System;

namespace MatrixTest {

    [TestClass]
    public class MatrixFlowTest{

        [TestMethod]
        public void Correctness_Of_MatrixFlowSum(){

            //Arrangement and Act
            const int rows = 3;
            const int columns = 4;

            var matrixFlow = new MatrixFlow(
                new int[rows, columns] {
                    { 1, 2, 3, 4 },
                    { 5, 6, 7, 8 },
                    { 9, 10, 11, 12 } },
                rows,
                columns);

            int expected = 18;

            //Assertion
            int actual = matrixFlow.FlowSum;
            Assert.AreEqual(expected, actual, "Flow calculated not correctly");
        }

        [TestMethod]
        public void SetRowsAndColumns_WithNotValidValue(){

            //Arrangement
            const string value = "-2\n4\n0\nstr\n5";
            string path = "Desktop";
            bool expected = true;

            //Act
            using (var writer = new StreamWriter(path)){
                writer.WriteLine(value, true, System.Text.Encoding.Default);
            }

            using (var reader = new StreamReader(path)){

                Console.SetIn(reader);
                var matrixFlow = new MatrixFlow();

                //Assertion
                bool actual = matrixFlow.Rows == 4 && matrixFlow.Columns == 5;
                Assert.AreEqual(expected, actual, "Rows value is not set correct");
            }
        }
    }
}
