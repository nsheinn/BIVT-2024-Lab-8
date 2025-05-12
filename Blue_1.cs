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
        public string[] Output => (string[])_output?.Clone();
        public Blue_1(string input) : base(input)
        {
            _output = null;
        }
        public override void Review()
        {
            if (string.IsNullOrEmpty(_input)) return;
            string[] words = _input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] allLines = new string[words.Length];
            string currentLine = "";
            int lineCount = 0;
            foreach (string word in words)
            {
                if (currentLine.Length == 0) currentLine = word;
                else if (currentLine.Length + word.Length + 1 <= 50)
                {
                    currentLine += " " + word;
                }
                else
                {
                    allLines[lineCount++] = currentLine;
                    currentLine = word;
                }
            }
            if (currentLine.Length > 0)
            {
                allLines[lineCount++] = currentLine;
            }
            _output = new string[lineCount];
            Array.Copy(allLines, _output, _output.Length);

        }
        public override string ToString()
        {
            if (_output == null || _output.Length == 0) return null;
            return string.Join(Environment.NewLine, _output);
        }
    }
}
