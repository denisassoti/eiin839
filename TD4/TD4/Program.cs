using CalculatorWS;

namespace TD4
{
    class Program
    {
        static async Task Main(string[] args)
        {
            CalculatorSoapClient calculatorSoapClient = new CalculatorSoapClient(CalculatorSoapClient.EndpointConfiguration.CalculatorSoap);


            int addition = await calculatorSoapClient.AddAsync(3, 4);
            int soustraction = await calculatorSoapClient.SubtractAsync(3, 4);
            int multiplication = await calculatorSoapClient.MultiplyAsync(3, 4);
            int division = await calculatorSoapClient.DivideAsync(3, 4);

            Console.WriteLine("Addition of 3 and 4 = "+ addition);
            Console.WriteLine("substraction of 3 and 4 = " + soustraction);
            Console.WriteLine("multiplication of 3 and 4 = " + multiplication);
            Console.WriteLine("division of 3 and 4 = " + division);
        }
    }
}
