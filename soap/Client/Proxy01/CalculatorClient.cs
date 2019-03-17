using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Client.Proxy01
{
    class CalculatorClient : ClientBase<ICalculatorService>
    {
        public CalculatorClient(Binding binding, EndpointAddress remoteAddress) : base(binding, remoteAddress)
        {
        }

        public double Add(double x, double y) => Channel.Add(x, y);

        public double Subtract(double x, double y) => Channel.Subtract(x, y);

        public double Multiply(double x, double y) => Channel.Multiply(x, y);

        public double Divide(double x, double y) => Channel.Divide(x, y);
    }
}