using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarCardGame.Models
{
    class Card
    {
        public int Value { get; }
        public string Name { get; }
        public Card(string suit, string valueStr)
        {
            Name = valueStr + " " + suit;
            Value = SetValue(valueStr);
        }

        int SetValue(string val)
        {
            int[] values = { 11, 12, 13, 14 };
            string[] names = { "jack", "queen", "king", "ace" };
            int value = 0;
            bool correct = Int32.TryParse(val, out value);
            if (correct)
            {                
                return value;
            }
            else
            {
                for(int i = 0; i < names.Length; i++)
                {
                    if (names[i] == val)
                    {
                        value = values[i];
                        return value;
                    }
                   
                }
            }
            return value;
        }


    }
}
