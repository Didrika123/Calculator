using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                ShowMenu();
                string input = AskUserFor("selection");

                if (input.ToLower() != "exit")
                {
                    int.TryParse(input, out int choice);
                    switch (choice)
                    {
                        case 1:
                            LetUserCalculate('+');
                            break;
                        case 2:
                            LetUserCalculate('-');
                            break;
                        case 3:
                            LetUserCalculate('/');
                            break;
                        case 4:
                            LetUserCalculate('*');
                            break;
                        case 5:
                            IntervalBeeps();
                            break;
                        default:
                            ShowError("Please enter a proper command.");
                            break;
                    }
                    Console.ReadKey();
                }
                else keepRunning = false;
            }
        }
        static void IntervalBeeps()
        {
            Console.Clear();
            Console.WriteLine("Number of intervals");
            int numIntervals = (int)AskUserForNumber();
            Console.WriteLine("Number of seconds per interval");
            int intervalSeconds = (int) AskUserForNumber();
            Console.WriteLine("Commencing Interval-beeping...");
            DateTime start = DateTime.Now;
            double numSec = 0;
            for (int i = 0; i < numIntervals; i++)
            {
                while (numSec < intervalSeconds * (1+i))
                {
                    numSec = DateTime.Now.Subtract(start).TotalSeconds;
                }
                Console.Beep();
                Console.WriteLine("Beep!  (" + numSec + " sec)");
            }
            Console.WriteLine("Interval-beeping completed after " + numSec + " seconds.");
        }
        static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Calculator!\n");
            Console.WriteLine("\t1 - Addition       (+)");
            Console.WriteLine("\t2 - Subtraction    (-)");
            Console.WriteLine("\t3 - Division       (/)");
            Console.WriteLine("\t4 - Multiplication (*)");
            Console.WriteLine("\t5 - Interval-Beeps");
            Console.WriteLine("\tExit to leave\n");

        }
        static void ShowError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: " + msg);
            Console.ForegroundColor = ConsoleColor.White;
        }
        static string AskUserFor(string what)
        {
            Console.Write($"Enter {what}: ");
            string input = Console.ReadLine();
            return input;
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
        static double Calculate(char operation, double numA, double numB)
        {
            double result = 0;
            switch (operation)
            {
                case '+':
                    result = Add(numA, numB);
                    break;
                case '-':
                    result = Subtract(numA, numB);
                    break;
                case '/':
                    if (numB == 0)
                        ShowError("Division by Zero.");
                    result = Divide(numA, numB);
                    break;
                case '*':
                    result = Multiply(numA, numB);
                    break;
                default:
                    ShowError($"Unsupported operator ({operation}).");
                    break;
            }
            return result;
        }
        static void LetUserCalculate(char operation)
        {
            Console.Clear();
            Console.WriteLine("Operation: " + operation + "\n");
            double numA = AskUserForNumber();
            double numB = AskUserForNumber();
            double result = Calculate(operation, numA, numB);

            //present result
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nResult: {numA} {operation} {numB} = {Math.Round(result, 4)}");
            Console.ForegroundColor = ConsoleColor.White;
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
