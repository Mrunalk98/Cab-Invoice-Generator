using System;

namespace CabInvoiceGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Cab Invoice Generator!");
            InvoiceGenerator invoice = new InvoiceGenerator(RideType.NORMAL);
            double fare = invoice.CalculateRideFare(2.0, 5);
            Console.WriteLine("Fare : " + fare);
        }
    }
}
