using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarCardGame.Models
{
    class Deck
    {
        string[] values = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "queen", "king", "ace" };
        string[] suits = { "clubs", "hearts", "spades", "diamonds" };
        public Stack<Card> Cards;
        public Deck()
        {
            Cards = new Stack<Card>();
            List<Card> CardList = new List<Card>();
            for(int i = 0; i < suits.Length; i++)
            {
                for(int j =0; j < values.Length; j++)
                {
                    CardList.Add(new Card(suits[i],values[j]));
                }
            }
            Random random = new Random();
            List<Card> ShuffleCads = CardList.Select(x => new { value = x, order = random.Next() })
            .OrderBy(x => x.order).Select(x => x.value).ToList();

            foreach(Card card in ShuffleCads)
            {
                Cards.Push(card);
            }
        }
       
    }
}
