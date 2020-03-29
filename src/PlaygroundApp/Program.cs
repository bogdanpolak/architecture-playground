using System;

namespace Design.Deoms
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("##  Design Playground  ##");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Simple factory: ");
            Playground.Factories.IPizza _pizza = new Playground.Factories.PizzaFactory().PreparePizza();
            Console.WriteLine("  * Pizza: {0}", _pizza.ToString());
            Console.WriteLine("--------------------------------------------");
            Console.ReadKey();
        }
    }
}
