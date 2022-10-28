using System.Data;

namespace CalculatorNamespace;
/// <summary>
/// This program is a console based calculator wich is the final exam of my "programming basics" course.
/// The Pseudo code for the assignment are as follows: (also provided in code for easy nav.)
/// 
///     Welcome message
///     A list to save history of calculations
///     The user inputs number and math operation
///     NOTE! The user must enter a number in order to move forward in the program!
///     If the user were to divide 0 by 0 display Invalid input!
///     Add results to the list
///     Show result
///     Ask user if it wants to show previous results.
///     Display previous results
///     Ask the user whether to exit or continue.
///
/// As extra features:
/// -XML comments are used, this makes it easy to provide a online code/API doc in the future. See: https://dotnet.github.io/docfx/
/// -Logging of exceptions to BestCalculatorLog.txt in bin folder
/// -Logging of all calculations to HistoryLog.txt in bin folder.
/// -A Calculator class is used to keep the code cleaner. incuding theese methods:
///     Calculator.HistorList()
///     Calculator.Compute()
///     Calculator.Log()
///     Calculator.HistoryLog()
///     Calculator.GetHistoryLog()
///     And more... see calc.cs for full documentation.
/// 
/// Further development includes:
/// TODO: A nicer presentation, including alignment of text
/// TODO: Implement a more graphical menu, like this sweet one: https://github.com/lorenarms/Personal_CSharp_Utilities/tree/master/MenuBuilder
/// 
/// </summary>
internal class Program
{
    private static void Main(string[] args)
    {

        bool exit = false;
        var Calculator = new Calc();

        //     Welcome message
        //     Ask user if it wants to show previous results. "h" or "hl"
        //     Ask the user whether to exit or continue. "e"
        Calculator.Head();

        //     The user inputs number and math operation
        string? input = Console.ReadLine();

        do
        {
            /*
             For easy to read purpose, a switch case approch is used. previous versions was made up by if-else statments.
             A do-while loop is used to keep the calculator going. Aslong as an "e" is not provided.
             */

            //A clean console is the way to go! 
            Console.Clear();
            //New header is printed
            Calculator.Head();

            switch (input?.ToLower())
            {
                //     Ask the user whether to exit or continue.
                case "e":
                    Environment.Exit(0);
                    break;
                //     Display previous results, see h and hl.
                case "h":
                    Console.Clear();
                    Calculator.Head();
                    Calculator.GetHistory();
                    break;
                case "hl":
                    Calculator.GetHistoryLog();
                    break;


                //     NOTE! The user must enter a number in order to move forward in the program! This is checked inside the try-catch...
                default:
                    try
                    {
                        if (input != "")
                        {

                            //     A list to save history of calculations is created within compute()
                            //     If the user were to divide 0 by 0 display Invalid input!
                            //     Show result
                            //     see inside Compute() for more info.
                            Calculator.Compute(input);
                        }
                    }
                    catch (EvaluateException ex)
                    {
                        Console.WriteLine("You can't do that! Use numbers and mathoperators or allowed text for navigation.");
                        Console.WriteLine("Try again:");
                        Calculator.Log(ex.ToString());
                    }
                    catch (OverflowException ex)
                    {
                        Console.WriteLine("Too large number!");
                        Console.WriteLine("Try again:");
                        Calculator.Log(ex.ToString());
                    }
                    catch (SyntaxErrorException ex)
                    {
                        Console.WriteLine("Missing operand after operator.");
                        Console.WriteLine("Try again:");
                        Calculator.Log(ex.ToString());
                    }
                    catch (DivideByZeroException ex)
                    {
                        Console.WriteLine("Invalid input! You´re getting close to infinity, be careful!");
                        Calculator.Log(ex.ToString());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        Console.WriteLine("Try again:");
                        Calculator.Log(ex.ToString());
                    }
                    break;
            }

            //     The user inputs number and math operation... this input acts like a pause before while is looping agian.
            input = Console.ReadLine();

        } while (!exit);
    }
}