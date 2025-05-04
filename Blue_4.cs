using System;

namespace Lab_8
{
    public class Blue_4 : Blue
    {
        private int _output;
        public int Output => _output;

        public Blue_4(string input) : base(input)
        {
            _output = 0;
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(Input))
            {
                _output = 0;
                return;
            }

            bool inNumber = false;
            int currentNumber = 0;

            foreach (char c in Input)
            {
                if (c >= '0' && c <= '9') 
                {
                    if (!inNumber)
                    {
                        inNumber = true;
                        currentNumber = 0;
                    }
                    currentNumber = currentNumber * 10 + (c - '0'); 
                }
                else
                {
                    if (inNumber)
                    {
                        _output += currentNumber;
                        inNumber = false;
                    }
                }
            }

            if (inNumber)
            {
                _output += currentNumber;
            }
        }

        public override string ToString()
        {
            return _output.ToString();
        }
    }
}