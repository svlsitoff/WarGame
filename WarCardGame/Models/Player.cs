using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarCardGame.Models
{
    class Player
    {
        public Stack<Card> WorkingDeck;
        public Stack<Card> WonCards;
        public String Name { get; }
        public Player(string name)
        {
            WorkingDeck = new Stack<Card>();
            WonCards = new Stack<Card>();
            Name = name;
        }
        int Score { get; set; }
        public int GetScore()
        {
            return Score;
        }
        public void IncrementScore()
        {
            Score++;
        }
    }
}
