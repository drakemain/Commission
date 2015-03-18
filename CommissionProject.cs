using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continueProgram = true;

            while (continueProgram)
            {
                Console.Clear();

                float baseSalary = readInput("Base Salary?:");
                float weeklySales = computeWeeklySales();
                float commissionRate = computeCommissionRate(weeklySales);
                float commission = computeCommission(commissionRate, weeklySales);
                float weeklyWage = computeWage(commission, baseSalary);
                writeOutput(baseSalary, weeklySales, commissionRate, commission, weeklyWage);

                continueProgram = endPrompt();
            }
        }
        public static int readInput(string message) //Method to display a message and return user input.
        {
            Console.WriteLine(message);
            return int.Parse(Console.ReadLine());
        }
        public static void writeOutput(float baseSalary, float sales, float commissionRate, float commission, float wage)
        {
            Console.Clear();
            Console.WriteLine("Base Salary: " + baseSalary.ToString("C") + "\n");
            Console.WriteLine("Weekly Sales: " + sales.ToString("C"));
            Console.WriteLine("Commission Rate: " + commissionRate.ToString("P"));
            Console.WriteLine("Weekly Commission: " + commission.ToString("C") + "\n");
            Console.WriteLine("Weekly Wage: " + wage.ToString("C"));
        }
        public static bool endPrompt()
        {
            while (true)
            {
                Console.Write("\n" + "Find new salary? (y/n):");

                switch (Console.ReadLine().ToString())
                {
                    case "y":
                        return true;
                    case "n":
                        return false;
                    default:
                        Console.WriteLine("Invalid selection.");
                        break;
                }
            }
        }
        public static float computeWeeklySales()
        {
            float salesRunningTotal = 0;
            float itemValue;
            int productNumber;
            string menu = @"
1. Item 1 @ $15.50
2. Item 2 @ $25.00
3. Item 3 @ $75.00
4. Item 4 @ $250.00
5. Item 5 @ $100.00
";
            while(true)
            {
                Console.Clear();
                Console.WriteLine("Running Sales Total: " + salesRunningTotal.ToString("C"));
                Console.WriteLine(menu);
                productNumber = readInput("Enter product number or 0 to calculate salary:");
                switch(productNumber)   //Determine item value and multiplies it by number sold. This value is added to the running total.
                {
                    case 0:
                        return salesRunningTotal;                           //returns the value for the running sales total
                    case 1:
                        itemValue = 15.5f;
                        salesRunningTotal = (float)(readInput("Quantity @ " + itemValue.ToString("C") + " each?") * itemValue + salesRunningTotal);
                        break;
                    case 2:
                        itemValue = 25;
                        salesRunningTotal = (float)(readInput("Quantity @ " + itemValue.ToString("C") + " each?") * itemValue + salesRunningTotal);
                        break;
                    case 3:
                        itemValue = 75;
                        salesRunningTotal = (float)(readInput("Quantity @ " + itemValue.ToString("C") + " each?") * itemValue + salesRunningTotal);
                        break;
                    case 4:
                        itemValue = 250;
                        salesRunningTotal = (float)(readInput("Quantity @ " + itemValue.ToString("C") + " each?") * itemValue + salesRunningTotal);
                        break;
                    case 5:
                        itemValue = 100;
                        salesRunningTotal = (float)(readInput("Quantity @ " + itemValue.ToString("C") + " each?") * itemValue + salesRunningTotal);
                        break;
                    default:
                        Console.WriteLine("Invalid product number. Try again!");
                        Console.ReadKey(false);
                        break;
                }
            }
        }
        public static float computeCommissionRate(float weeklySales)
        {
            if (weeklySales < 500)
            {
                return .03f;
            }
            else if (weeklySales < 1000)
            {
                return .05f;
            }
            else if (weeklySales < 2500)
            {
                return .075f;
            }
            else
            {
                return .1f;
            }
        }
        public static float computeCommission(float rate, float sales)
        {
            return (rate * sales);
        }
        public static float computeWage(float commission, float baseSalary)
        {
            return (commission + baseSalary);
        }
    }
}
