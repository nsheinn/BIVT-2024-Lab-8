using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_1 : Blue
    {
        private string[] _output;
        public string[] Output => _output;
        public Blue_1(string input) : base(input)
        {
            _output = null;
        }
        public override void Review()
        {
            if (string.IsNullOrEmpty(_input)) return;
            string[] words = _input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] allLines = new string[words.Length];
            string newLine = "";
            int countLines = 0;
            foreach (string word in words)
            {
                if (newLine == "") newLine = word;
                else if (newLine.Length + word.Length + 1 <= 50)
                {
                    newLine += " " + word;
                }
                else
                {
                    allLines[countLines++] = newLine;
                    newLine = word;
                }
            }
            if (newLine != "")
            {
                allLines[countLines++] = newLine;
            }
            _output = new string[countLines];
            Array.Copy(allLines, _output, _output.Length);
        }
        public override string ToString()
        {
            if (_output == null || _output.Length == 0) return null;
            return string.Join(Environment.NewLine, _output);
        }
    }
}
