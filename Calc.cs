using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorNamespace
{
    public class Calc
    {
        private List<string> _historyList = new List<string>();

        public Calc(string hl = "History:")
        {
            _historyList.Add(hl);
        }

        public List<string> historyList
        {
            get => _historyList;
            set => _historyList = value;
        }

        internal void Head()
        {
            // Välkomnande meddelande
            Console.WriteLine("Hi! Welcome to the best calculator in the world");
            Console.WriteLine("----- [H] : History ----- [exit] : exit -----");
        }
    }
}
