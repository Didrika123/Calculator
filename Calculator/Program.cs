using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Calculator!");
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Write("\nEnter a mathematical expression or \"exit\" to leave. \nInput> ");
                string input = Console.ReadLine();
                if (input.ToLower() == "exit")
                {
                    keepRunning = false;
                }
                else
                {
                    double result = DoCalculation(input);
                    Console.WriteLine("Result: " + result);

                    int choice;
                    int.TryParse(input, out choice);
                    switch (choice)
                    {
                        case 1:
                            PresentResult(Add(AskUserForNumber(), AskUserForNumber()));
                            break;
                        case 2:
                            PresentResult(Subtract(AskUserForNumber(), AskUserForNumber()));
                            break;
                        case 3:
                            PresentResult(Divide(AskUserForNumber(), AskUserForNumber()));
                            break;
                        case 4:
                            PresentResult(Multiply(AskUserForNumber(), AskUserForNumber()));
                            break;
                        default:
                            Console.WriteLine("Enter a menu choice! ");
                            break;
                    }
                }
            }
        }
        static void PresentResult(double result)
        {
            Console.WriteLine("Enter number: ");
        }
        static double AskUserForNumber()
        {
            double num;
            string input;
            do
            {
                Console.Write("Enter number: ");
                input = Console.ReadLine();

            } while (!double.TryParse(input, out num));
            return num;
        }
        static double DoCalculation(string expression)
        {
            double result = 0;
            expression = expression.Replace(" ", "");
            var acceptableOperators = new char[] { '+', '-', '/', '*' };
            int firstOperatorIndex = expression.IndexOfAny(acceptableOperators);
            if (firstOperatorIndex > 0) 
            { 
                char opera = expression[firstOperatorIndex];
                result = int.Parse(expression.Substring(0, firstOperatorIndex));
                string remaining = expression.Substring(firstOperatorIndex + 1);
                switch (opera)
                {
                    case '+':
                        result = Add(result, DoCalculation(remaining));
                        break;
                    case '-':
                        break;
                    case '/':
                        break;
                    case '*':
                        int index = remaining.IndexOfAny(acceptableOperators);
                        if (index < 0)
                            index = remaining.Length;
                        string nextNumber = remaining.Substring(0, index);
                        result = Multiply(result, DoCalculation(nextNumber));
                        result = DoCalculation(result + remaining.Substring(index));
                        break;
                }
            }
            else result = int.Parse(expression);
            return result;
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
