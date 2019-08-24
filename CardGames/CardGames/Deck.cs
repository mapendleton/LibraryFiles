using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CardGames
{

    public class Deck
    {
        public Deck()
        {
            Cards = new List<Card>();
            CardImages = new List<Bitmap>();
            //creates bitmap objects for each bmp image in folder
            //Check for different way to access the images as the path
            //won't be the same if the images are embedded into the dll file.
            //for (int i = 0; i < 52; i++)
            //{
            //    int cardNum = i + 1;
            //    if (i < 10)
            //    {
            //        CardImages.Add(new Bitmap("C:\\Users\\Matthew Pendleton\\Documents\\Visual Studio 2015\\Projects\\LibraryFiles\\LibraryFiles\\CardGames\\CardGames\\Images\\cards_0"+cardNum+"_clubs.bmp"));
            //    }
            //    CardImages.Add(new Bitmap("C:\\Users\\Matthew Pendleton\\Documents\\Visual Studio 2015\\Projects\\LibraryFiles\\LibraryFiles\\CardGames\\CardGames\\Images\\cards_"+cardNum+"_clubs.bmp"));
            //}
            MyAssembly = Assembly.GetExecutingAssembly();
            string assemblyStream = " ";
            try
            {
                for (int i = 0; i < 52; i++)
                {
                    int cardNum = i + 1;
                    if (i < 9)
                    {
                        assemblyStream = "CardGames.Images.cards_0" + cardNum + "_clubs.bmp";
                    }
                    else if (i >= 9 && i < 13)
                    {
                        assemblyStream = "CardGames.Images.cards_" + cardNum + "_clubs.bmp";
                    }
                    else if (i >= 13 && i < 26)
                    {
                        assemblyStream = "CardGames.Images.cards_" + cardNum + "_diamonds.bmp";
                    }
                    else if (i >= 26 && i < 39)
                    {
                        assemblyStream = "CardGames.Images.cards_" + cardNum + "_hearts.bmp";
                    }
                    else if (i >= 39)
                    {
                        assemblyStream = "CardGames.Images.cards_" + cardNum + "_spades.bmp";
                    }

                    Stream myStream = MyAssembly.GetManifestResourceStream(assemblyStream);
                    if (myStream != null && assemblyStream != " ")
                    {
                        CardImages.Add(new Bitmap(myStream));
                    }
                    else
                    {
                        throw new Exception("Invalid Stream");
                    }
                }

                for (int i = 0; i < 13; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Card card = new Card();
                        card.Face = (Face)i;
                        card.Suit = (Suit)j;
                        //selects out of the list of card pictures first all suits of the Ace
                        //then all suits of the 2 etc...
                        switch (j)
                        {
                            case 0:
                                card.CardImage = CardImages[i];
                                break;
                            case 1:
                                card.CardImage = CardImages[i + 13];
                                break;
                            case 2:
                                card.CardImage = CardImages[i + 26];
                                break;
                            case 3:
                                card.CardImage = CardImages[i + 39];
                                break;
                            default:
                                throw new Exception("something went wrong with switch statement");
                        }
                        Cards.Add(card);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
        }

        public List<Card> Cards { get; set; }
        public List<Bitmap> CardImages { get; set; }
        public Assembly MyAssembly { get; set; }

        public void Shuffle(int times = 1)
        {
            for (int i = 0; i < times; i++)
            {
                List<Card> tempList = new List<Card>();
                Random rand = new Random();

                while(this.Cards.Count > 0)
                {
                    int randomIndex = rand.Next(0, this.Cards.Count);
                    tempList.Add(this.Cards[randomIndex]);
                    this.Cards.RemoveAt(randomIndex);
                }
                this.Cards = tempList;
            }
        }
    }
}
