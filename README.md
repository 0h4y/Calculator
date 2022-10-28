# Calculator
/// This program is a console based calculator wich is the final exam of my "programming basics" course.
/// The Pseudo code for the assignment are as follows: (also provided in code... see program.cs and calc.cs)
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
