using ServiceReference1;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            MathsOperationsClient client = new MathsOperationsClient();
            int addition = client.Add(3, 5);
            int substract = client.Substract(3, 5);
            int multiply = client.Multiply(3, 5);
            float divide = client.Divide(3, 5);

            Console.WriteLine(addition);
            Console.WriteLine(substract);
            Console.WriteLine(multiply);
            Console.WriteLine(divide);

        }
    }
}
