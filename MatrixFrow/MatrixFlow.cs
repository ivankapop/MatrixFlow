using System;

namespace MatrixFlowNS { 

    public class MatrixFlow{
        public int[,] Matrix { get; private set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int FlowSum { get; private set; }

        public MatrixFlow( string rowStr = null, string columnStr = null) {

            if (rowStr != null)
                SetRows(rowStr);
            else SetRows();

            if (columnStr != null)
                SetColumns(columnStr);
            else SetColumns();

            FillMatrix();
            CountMatrixFlow();
        }

        public MatrixFlow(int[,] customMatrix, int rowInt, int columnInt) {

            Matrix = customMatrix;
            Rows = rowInt;
            Columns = columnInt;

            CountMatrixFlow();
        }

        public void DisplayMatrix() {
            for (var r = 0; r < Rows; r++){
                for (var c = 0; c < Columns; c++){
                    if (r == c){
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write($" {Matrix[r, c].ToString("D2")} ");
                        Console.ResetColor();
                    }
                    else{
                        Console.Write($" {Matrix[r, c].ToString("D2")} ");
                    }
                }
                Console.WriteLine();
            }
        }

        private void FillMatrix(int[,] matrix = null){
            var random = new Random();
            Matrix = new int[Rows, Columns];

            for (var r = 0; r < Rows; r++){
                for (var c = 0; c < Columns; c++){
                    int randomNumber = random.Next(0, 100);
                    Matrix[r, c] = randomNumber;
                }
            }
        }

        private void CountMatrixFlow() {
            if (Matrix == null) 
                return;

            for (var i = 0; i < Math.Min(Rows, Columns); i++) {
                FlowSum += Matrix[i, i];
            }
        }

        private int PromptInt(string message, string valueStr = null){
            int input;
            do {
                Console.WriteLine(message);
                int.TryParse(valueStr ?? Console.ReadLine(), out input);
            } while (input <= 0);
            return input;
        }

        public void SetRows(string value = null){
           Rows = PromptInt("Please enter number of rows for marix (number should be > 0):", value);
        }

        public void SetColumns(string value = null){
            Columns = PromptInt("Please enter number of columns for marix (number should be > 0):", value);
        }
    }
}
