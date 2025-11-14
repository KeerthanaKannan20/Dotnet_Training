using System;

namespace Online_Utility_Bill_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------Online Utility Billing System ------");

            Console.Write("Enter number of customers: ");
            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"\nEnter details for Customer #{i}");
                Customer customer = new Customer();

                Console.Write("Customer ID: ");
                customer.CustomerID = Convert.ToInt32(Console.ReadLine());

                Console.Write("Customer Name: ");
                customer.CustomerName = Console.ReadLine();

                Console.Write("Enter monthly usage readings (in units): ");
                string[] input = Console.ReadLine().Split(' ');
                int[] readings = new int[input.Length];

                for (int j = 0; j < input.Length; j++)
                {
                    readings[j] = int.Parse(input[j]);
                }

                double total, tax, netPayable;
                customer.CalculateBill(out total, out tax, out netPayable, readings);

                Console.WriteLine("\n------ Utility Bill ------");
                Console.WriteLine($"Customer ID   : {customer.CustomerID}");
                Console.WriteLine($"Customer Name : {customer.CustomerName}");
                Console.WriteLine($"Service Charge: {Customer.GetServiceCharge()}");
                Console.WriteLine($"Total Usage   : {total}");
                Console.WriteLine($"Tax Applied   : {tax}");
                Console.WriteLine($"Net Payable   : {netPayable}");
                Console.WriteLine("------------------------------");
            }
        }
    }
}

