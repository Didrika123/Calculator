using System;

namespace Calculator
{
    class Program
    {
        delegate double Calculation(double numA, double numB);
        static void Main(string[] args)
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                ShowMenu();
                string input = AskUserFor("selection");
                int.TryParse(input, out int choice);
                if (input.ToLower() == "exit")
                {
                    keepRunning = false;
                }
                else
                {
                    Calculation calc = null;
                    switch (choice)
                    {
                        case 1:
                            calc = Add;
                            break;
                        case 2:
                            calc = Subtract;
                            break;
                        case 3:
                            calc = Divide;
                            break;
                        case 4:
                            calc = Multiply;
                            break;
                        default:
                            ShowError("Please enter a proper command.");
                            break;
                    }
                    if(calc != null)
                        PresentResult(calc);

                    Console.ReadKey();
                }
            }
        }
        static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Calculator!\n");
            Console.WriteLine("1 - Addition");
            Console.WriteLine("2 - Subtraction");
            Console.WriteLine("3 - Division");
            Console.WriteLine("4 - Multiplication");
            Console.WriteLine("\"Exit\" to leave\n");

        }
        static string AskUserFor(string what)
        {

            Console.Write($"Enter {what}: ");
            string input = Console.ReadLine();
            return input;
        }
        static void ShowError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: " + msg);
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void PresentResult(Calculation calc)
        {
            double numA = AskUserForNumber();
            double numB = AskUserForNumber();
            double result = calc(numA, numB);
            Console.Write("Result: " + Math.Round(result, 4));
        }
        static double AskUserForNumber()
        {
            double num;
            while (!double.TryParse(AskUserFor("number"), out num))
            {
                ShowError("Enter a number.");
            }
            return num;
        }
        static double Add(double numA, double numB)
        {
            return numA + numB;
        }
        static double Subtract(double numA, double numB)
        {
            return numA - numB;
        }
        static double Divide(double numA, double numB)
        {
            return numA / numB;
        }
        static double Multiply(double numA, double numB)
        {
            return numA * numB;
        }
    }
}
