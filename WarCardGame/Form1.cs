using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WarCardGame.Models;
using WarCardGame.Properties;

namespace WarCardGame
{
    public partial class Form1 : Form
    {
        Deck Deck;
        Player player1, player2;
        Stack<Card> Player1Round, Player2Round;
        bool war = false;
        int countCards = 1;

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (player1.WonCards.Count > 0)
            {
                string info = "";
                Stack<Card> temp = new Stack<Card>();
                int countCards = player1.WonCards.Count;
                for (int i = 0; i < countCards; i++)
                {
                    Card card = player1.WonCards.Pop();
                    info += card.Name+"\n";
                    temp.Push(card);
                    
                }

                int countTempCards = temp.Count;
                for (int i = 0; i < countTempCards; i++)
                {
                    Card card = temp.Pop();
                    player1.WonCards.Push(card);
                }
                MessageBox.Show(info);

            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (player2.WonCards.Count > 0)
            {
                string info = "";
                Stack<Card> temp = new Stack<Card>();
                int countCards = player2.WonCards.Count;
                for (int i = 0; i < countCards; i++)
                {
                    Card card = player2.WonCards.Pop();
                    info += card.Name + "\n";
                    temp.Push(card);

                }

                int countTempCards = temp.Count;
                for (int i = 0; i < countTempCards; i++)
                {
                    Card card = temp.Pop();
                    player2.WonCards.Push(card);
                }
                MessageBox.Show(info);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (player1.WorkingDeck.Count > 0 && player2.WorkingDeck.Count > 0)
            {
                Card cardpl1;
                Card cardpl2;
                if (war == false)
                {

                    cardpl1 = player1.WorkingDeck.Pop();
                    cardpl2 = player2.WorkingDeck.Pop();
                    Object o1 = Resources.ResourceManager.GetObject(cardpl1.Name);
                    Object o2 = Resources.ResourceManager.GetObject(cardpl2.Name);
                    pictureBox3.BackgroundImage = (Image)o1;
                    pictureBox4.BackgroundImage = (Image)o2;
                    if (cardpl1.Value > cardpl2.Value)
                     {
                        player1.WonCards.Push(cardpl1);
                        player1.WonCards.Push(cardpl2);
                        string name = "card back";

                        Object obj = Resources.ResourceManager.GetObject(name);

                        pictureBox5.BackgroundImage = (Image)obj;
                    }
                    if (cardpl1.Value < cardpl2.Value) 
                    {
                        player2.WonCards.Push(cardpl1);
                        player2.WonCards.Push(cardpl2);

                        string name = "card back";

                        Object obj = Resources.ResourceManager.GetObject(name);
                        pictureBox6.BackgroundImage = (Image)obj;
                    }
                    if (cardpl1.Value == cardpl2.Value)
                    {
                        MessageBox.Show("War!");
                        war = true;
                        Player1Round.Push(cardpl1);
                        Player2Round.Push(cardpl2);
                        return;

                    }
                }
                if(war==true)
                {
                    label3.Text = "The card is laid down : " + countCards;

                    string name = "card back";

                    Object obj = Resources.ResourceManager.GetObject(name);

                    if (countCards <= 3)
                    { 
                        cardpl1 = player1.WorkingDeck.Pop();

                        cardpl2 = player2.WorkingDeck.Pop();

                       
                   
                        pictureBox3.BackgroundImage = (Image)obj;

                        pictureBox4.BackgroundImage = (Image)obj;                   

                        Player1Round.Push(cardpl1);

                        Player2Round.Push(cardpl2);
                        countCards++;
                    }
                    else
                    {
                        label3.Text = "We are watching the fourth card !";
                        cardpl1 = player1.WorkingDeck.Pop();

                        cardpl2 = player2.WorkingDeck.Pop();

                        Player1Round.Push(cardpl1);

                        Player2Round.Push(cardpl2);

                        Object obj1 = Resources.ResourceManager.GetObject(cardpl1.Name);
                        Object obj2 = Resources.ResourceManager.GetObject(cardpl2.Name);

                        pictureBox3.BackgroundImage = (Image)obj1;

                        pictureBox4.BackgroundImage = (Image)obj2;

                        if (cardpl1.Value >= cardpl2.Value)
                        {
                            MessageBox.Show(player1.Name + " won in the war!");

                            int count = Player1Round.Count;

                            for (int i = 0; i < count; i++)
                            {
                                Card temp = Player1Round.Pop();
                                player1.WonCards.Push(temp);
                            }
                            count = Player2Round.Count;
                            for (int i = 0; i < count; i++)
                            {
                                Card temp = Player2Round.Pop();
                                player1.WonCards.Push(temp);
                            }
                            if (pictureBox5.BackgroundImage == null) pictureBox5.BackgroundImage = (Image)obj;

                        }
                        else
                        {
                            MessageBox.Show(player2.Name+" won in the war!");

                            int count = Player1Round.Count;
                            for (int i = 0; i < count; i++)
                            {
                                Card temp = Player1Round.Pop();
                                player2.WonCards.Push(temp);
                            }
                            count = Player2Round.Count;
                            for (int i = 0; i < count; i++)
                            {
                                Card temp = Player2Round.Pop();
                                player2.WonCards.Push(temp);
                            }
                            if (pictureBox6.BackgroundImage == null) pictureBox6.BackgroundImage = (Image)obj;
                        }
                        label3.Text = "";
                       

                        pictureBox3.BackgroundImage = (Image)obj;

                        pictureBox4.BackgroundImage = (Image)obj;
                        countCards = 1;
                        war = false;
                        
                    }

                }

            }
            else
            {
                if (player1.WorkingDeck.Count == 0)
                {
                    if (player1.WonCards.Count == 0)
                    {
                        MessageBox.Show(player2.Name + "Won in the Game");
                        return;
                    }
                    player2.IncrementScore();
                    label2.Text = "Pc Score : " + player2.GetScore();
                    player1.WorkingDeck = Shuffle(player1.WonCards);
                    player1.WonCards.Clear();
                    MessageBox.Show("The " + player1.Name +  " is out of cards");
                    pictureBox5.BackgroundImage = null;
                }
                if (player2.WorkingDeck.Count == 0)
                {
                    if (player2.WonCards.Count == 0)
                    {
                        MessageBox.Show(player1.Name + "Won in the Game");
                        return;
                    }
                    player1.IncrementScore();
                    label1.Text = "Player Score : " + player1.GetScore();
                    player2.WorkingDeck = Shuffle(player2.WonCards);
                    player2.WonCards.Clear();
                    MessageBox.Show("The " + player2.Name + " is out of cards");
                    pictureBox6.BackgroundImage = null;
                }

            }
        }

        public Form1()
        {
            InitializeComponent();
            player1 = new Player("Player");
            player2 = new Player("PC");
            Player1Round = new Stack<Card>();
            Player2Round = new Stack<Card>();
            Deck = new Deck();        
            for (int i = 0; i < 26; i++)
            {
                player1.WorkingDeck.Push( Deck.Cards.Pop());
                
            }
            for (int i = 0; i < 26; i++)
            {
                player2.WorkingDeck.Push(Deck.Cards.Pop());
            }

            string name = "card back";
            Object obj = Resources.ResourceManager.GetObject(name);

            pictureBox1.BackgroundImage = (Image)obj;

            pictureBox2.BackgroundImage = (Image)obj;
        




        }
         Stack<Card> Shuffle(Stack<Card> InputCards)
            {
                List<Card> Cardlist = new List<Card>();
                int count = InputCards.Count;
                for (int i = 0; i < count; i++)
                {
                    Cardlist.Add(InputCards.Pop());
                }
                Stack<Card> cards = new Stack<Card>();

                Random random = new Random();
                List<Card> ShuffleCads = Cardlist.Select(x => new { value = x, order = random.Next() })
                .OrderBy(x => x.order).Select(x => x.value).ToList();

                foreach (Card card in ShuffleCads)
                {
                    cards.Push(card);
                }
                return cards;
            }


    }
}
