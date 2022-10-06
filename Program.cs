using CalculatorNamespace;
using System;
using System.Collections;
using System.Data;
using System.Runtime.CompilerServices;

namespace CalculatorNamespace;
/// <summary>
/// 
/// </summary>
internal class Program
{
    private static void Main(string[] args)
    {
        bool exit = false;
        Calc Calculator = new Calc();

        Calculator.Head();
        string input = Console.ReadLine();

        do
        {
            if (input.ToLower() == "exit")
            {
                break;
            }
            Console.Clear();
            Calculator.Head();
            if (input.ToLower() == "h")
            {
                Console.Clear();
                Calculator.Head();
                foreach (var item in Calculator.historyList)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                try
                {
                    if (input != "")
                    {
                        DataTable dt = new DataTable();
                        var v = dt.Compute(input, "2");
                        Calculator.historyList.Add($"{input} = {v}");
                        Console.WriteLine($"{input} = {v}");
                    }
                }
                catch (EvaluateException)
                {
                    Console.WriteLine("You can't do that! Use numbers and operators or allowed text for navigation.");
                }
                catch (OverflowException ex) { Console.WriteLine("Too large number!"); }

            }
            input = Console.ReadLine();
            continue;
        } while (!exit);
    }
}


// En lista för att spara historik för räkningar
// Användaren matar in tal och matematiska operation
//OBS! Användaren måsta mata in ett tal för att kunna ta sig vidare i programmet!
// Ifall användaren skulle dela 0 med 0 visa Ogiltig inmatning!
// Lägga resultat till listan
//Visa resultat
//Fråga användaren om den vill visa tidigare resultat.
//Visa tidigare resultat
//Fråga användaren om den vill avsluta eller fortsätta.

