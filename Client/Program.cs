using System;
using System.ServiceModel;
using Client.Proxy01;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create random inputs
            var numGen = new Random();
            var x = (int) (numGen.NextDouble() * 100);
            var y = (int) (numGen.NextDouble() * 100);

            const string serviceAddress = "http://localhost:5000/calculator.svc";

            var client = new CalculatorClient(new BasicHttpBinding(), new EndpointAddress(serviceAddress));

            Console.WriteLine($"{x} + {y} == {client.Add(x, y)}");
            Console.WriteLine($"{x} - {y} == {client.Subtract(x, y)}");
            Console.WriteLine($"{x} * {y} == {client.Multiply(x, y)}");
            Console.WriteLine($"{x} / {y} == {client.Divide(x, y)}");
        }
    }
}
