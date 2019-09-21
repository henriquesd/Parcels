using System;

namespace Parcels
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Parcels Handler. Please type something to handler the packages.");
            Console.ReadKey();
            Console.WriteLine("");

            ParcelsHandler.Handler();
        }
    }
}
