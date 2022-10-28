using System.Data;
using System.Text;

namespace CalculatorNamespace
{
    /// <summary>
    /// Hello this is **Calc** from *CalculatorNamespace*
    /// </summary>
    public class Calc
    {
        private List<string> _historyList = new List<string>();

        /// <summary>
        /// This is a constructor for Calc class
        /// A primary input for HistoryList is added wich fuction as a header. 
        /// </summary>
        public Calc()
        {
            HistorList.Add("History:");
        }

        /// <summary>
        /// A public get/set for _historylist
        /// </summary>
        public List<string> HistorList
        {
            get => _historyList;
            set => _historyList = value;
        }

        /// <summary>
        /// Compute Method takes one input and calculates provided expression with the help from System.Data.Datatable.
        /// The assignment did not exclude usage of imported libraries :) Thereby more time spent on Exception handling and these are logged! See Log()
        /// The result is printed to console together with the initial expression provided.
        /// </summary>
        /// <param name="input">A string containing expression for computation</param>
        /// <exception cref="DivideByZeroException">
        ///     As a part of the assignment, when zero division is found, this exception is thrown. 
        ///     Result from DataTable.Compute equal to "infinity" is checked because no actual zero division exception is thrown by Cumpute.
        /// </exception>
        internal void Compute(string? input)
        {
            DataTable dt = new();
            var v = dt.Compute(input, "2");

            //Checking for zero division by comparing result to infinity symbol, stored as unicode value in infinity.
            string infinity = "\u221E";
            if (v.ToString().Equals(infinity))
            {
                throw new DivideByZeroException();
            }
            //     Add results to the list
            HistorList.Add($"{input} = {v}");
            HistoryLog($"{input} = {v}");
            Console.WriteLine($"{input} = {v}");
        }

        /// <summary>
        /// GetHistory() prints previous calculations, if there are any...
        /// </summary>
        internal void GetHistory()
        {

            foreach (var item in HistorList)
            {
                Console.WriteLine(item);
            }
            if (HistorList.Count < 2)
            {
                Console.WriteLine("Make some calculations to fill the history!");
            }
        }

        /// <summary>
        /// Head() is simply outputting a nice headline for the best calculator :)
        /// </summary>
        internal void Head()
        {
            Console.WriteLine("Hi! Welcome to the best calculator in the world");
            Console.WriteLine("----- [h/H] : History - [fh/FH] : FullHistory - [e/E] : exit -----");
            Console.WriteLine("Valid operators and syntax include: + - / % () ");
        }

        /// <summary>
        /// Log() is writing any exceptions to the BestCalculatorLog.txt file.
        /// Date and time is also provided.
        /// </summary>
        /// <param name="textToLog">A string for logging</param>
        internal void Log(string textToLog)
        {
            string path = @"BestCalculatorLog.txt";
            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to. And a header.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("This is a log for the best calculator in the world: ");
                }
            }

            // This text is always added, making the file longer over time
            // if it is not deleted...
            using (StreamWriter sw = File.AppendText(path))
            {
                string date = DateTime.Now.ToString();
                sw.WriteLine($"--- Logging START {date} ---");
                sw.WriteLine(textToLog);
                sw.WriteLine($"--- Logging END {date} ---");
            }
        }

        /// <summary>
        /// Logging of history by HistoryLog(), in reverse order with current datetime.
        /// </summary>
        /// <param name="textToLog">A string for logging</param>
        internal void HistoryLog(string textToLog)
        {
            string path = @"HistoryLog.txt";

            //Create file in path to avoid exception.
            if (!File.Exists(path))
            {
                StreamWriter sw = File.CreateText(path);
                sw.Close();
            }

            //TODO: Reverse printing to file! DONE!
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                string date = DateTime.Now.ToString();
                StreamReader sr = new StreamReader(fs);
                string old = sr.ReadToEnd();
                textToLog =  date + ": " + textToLog + "\n" + old;
                byte[] byteStream = Encoding.Default.GetBytes(textToLog);
                fs.Seek(0, SeekOrigin.Begin);
                fs.Write(byteStream, 0, byteStream.Length);
                fs.Close();
            }
        }

        /// <summary>
        /// GetHistoryLog() outputs a 20 line long list of historical calcolations to console.
        /// </summary>
        internal void GetHistoryLog()
        {
            string path = @"HistoryLog.txt";
            // This text is opened only if it exists...
            if (File.Exists(path))
            {
                Console.WriteLine("20 of the latest calculations... Latest first. Complete List can be found in HistoryLog.txt");
                using (StreamReader sr = new StreamReader(path))
                {
                    for (int i = 0; i < 20; i++)
                    {
                        string? line = sr.ReadLine();
                        if (line != null)
                        {
                            Console.WriteLine(line);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            else
            {
                //if no historical calculation-file exists... 
                Console.WriteLine("Historical calculations do not exist!");
            }
        }
    }
}
