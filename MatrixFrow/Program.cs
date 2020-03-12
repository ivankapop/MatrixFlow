using System;

namespace MatrixFlowNS
{
    class Program
    {
        static void Main(string[] args){

            Console.WriteLine("Hello!");
            MatrixFlow matrixFlow = new MatrixFlow();

            matrixFlow.DisplayMatrix();
            Console.WriteLine();

            Console.WriteLine($"Matrix flow equals = {matrixFlow.FlowSum}");
            Console.ReadLine();
        }
    }
}
