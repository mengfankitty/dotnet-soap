using System;
using System.ServiceModel;
using Client.Proxy01;
using Client.Proxy02;

namespace Client
{
    static class Program
    {
        static void Main(string[] args)
        {
            // Create random inputs
            var numGen = new Random();
            var x = (int) (numGen.NextDouble() * 100);
            var y = (int) (numGen.NextDouble() * 100);

            const string endpointAddress = "http://localhost:5000/calculator.svc";

            RunProxy01(endpointAddress, x, y);
            RunProxy02(endpointAddress, x, y);
        }

        static void RunProxy01(string endpointAddress, int x, int y)
        {
            Console.WriteLine("Run Proxy01 {");

            var client = new CalculatorClient(new BasicHttpBinding(), new EndpointAddress(endpointAddress));

            Console.WriteLine($"  {x} + {y} == {client.Add(x, y)}");
            Console.WriteLine($"  {x} - {y} == {client.Subtract(x, y)}");
            Console.WriteLine($"  {x} * {y} == {client.Multiply(x, y)}");
            Console.WriteLine($"  {x} / {y} == {client.Divide(x, y)}");
            Console.WriteLine("}");
        }

        static void RunProxy02(string endpointAddress, int x, int y)
        {
            Console.WriteLine("Run Proxy02 {");

            var client = new CalculatorServiceClient(CalculatorServiceClient.EndpointConfiguration.BasicHttpBinding_ICalculatorService, endpointAddress);

            Console.WriteLine($"  {x} + {y} == {client.AddAsync(x, y).Result}");
            Console.WriteLine($"  {x} - {y} == {client.SubtractAsync(x, y).Result}");
            Console.WriteLine($"  {x} * {y} == {client.MultiplyAsync(x, y).Result}");
            Console.WriteLine($"  {x} / {y} == {client.DivideAsync(x, y).Result}");
            Console.WriteLine("}");
        }
    }
}
