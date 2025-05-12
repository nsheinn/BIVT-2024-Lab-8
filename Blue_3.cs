using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_3 : Blue
    {
        private (char, double)[] _output;

        public (char, double)[] Output => ((char, double)[])_output?.Clone();
        public Blue_3(string input) : base(input)
        {
            _output = null;
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(_input))
            {
                _output = null;
                return;
            }
            char[] separators = { ' ', '.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/' };

            string[] words = _input.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            int totalWords = 0;
            (char letter, int count)[] letterCounts = [];

            foreach (string word in words)
            {
                char firstChar = word[0];

                if (!char.IsLetter(firstChar)) continue;
                
                firstChar = char.ToLower(firstChar);
                totalWords++;

                bool found = false;
                for (int i = 0; i < letterCounts.Length; i++)
                {
                    if (letterCounts[i].letter == firstChar)
                    {
                        letterCounts[i].count++;
                        found = true;
                        break;
                    }
                }

                if (found) continue;
                Array.Resize(ref letterCounts, letterCounts.Length + 1);
                letterCounts[^1] = (firstChar, 1);

            }
            _output = letterCounts
                .Select(x => (x.letter, x.count * 100.0 / totalWords))
                .OrderByDescending(x => x.Item2)
                .ThenBy(x => x.Item1)
                .ToArray();
            

        }
        public override string ToString()
        {
            if (_output == null) return null;
            string answer = "";
            for (int i = 0; i < _output.Length; i++)
            {
                answer += $"{_output[i].Item1} - {_output[i].Item2:f4}";
                if (i != _output.Length - 1) answer += Environment.NewLine;
            }
            return answer;
        }
    }
}
