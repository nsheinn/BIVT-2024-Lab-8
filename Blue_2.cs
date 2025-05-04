using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_2 : Blue
    {
        private string _output;
        private string _toDelete;
        public string Output => _output;
        public Blue_2(string input, string toDelete) : base(input)
        {
            _output = null;
            _toDelete = toDelete;
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(_input) || string.IsNullOrEmpty(_toDelete))
            {
                _output = "";
                return;
            }
            string[] words = _input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string newOutput = "";
            foreach (string word in words)
            {
                if (string.IsNullOrWhiteSpace(word)) continue;
                if (!word.ToLower().Contains(_toDelete.ToLower()))
                    newOutput += (newOutput == "") ? word : " " + word;
                else if (!char.IsLetter(word[0]) || !char.IsLetter(word[^1]) )
                {
                    if (!char.IsLetter(word[0]))
                        newOutput += " ";
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (char.IsLetter(word[i])) 
                            continue;
                        if (i == 0 || i == word.Length - 1) 
                            newOutput += word[i];
                        else if (char.IsLetter(word[i - 1]) && 
                                !char.IsLetter(word[i]) && 
                                !char.IsLetter(word[i + 1])) 
                            newOutput += word[i];
                    }
                }    
            }
            _output = newOutput;
        }
        public override string ToString()
        {
            return string.IsNullOrEmpty(_output) ? "" : _output;
        }

    }
}
