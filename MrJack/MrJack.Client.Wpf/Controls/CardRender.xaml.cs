using MrJack.Core.Interfaces.Game;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MrJack.Client.Wpf.Controls
{
    /// <summary>
    /// Interaction logic for CardRender.xaml
    /// </summary>
    public partial class CardRender : UserControl
    {
        public CardRender()
        {
            InitializeComponent();
        }

        public void SetCard(ICard card)
        {
            ImageCard3.Visibility = Visibility.Visible;
            ImageCard4.Visibility = Visibility.Visible;
            Token.Visibility = Visibility.Visible;
                if (card.CardType == Core.Domain.Game.CardType.Jeton)
                {
                    ImageCard3.Visibility = Visibility.Hidden;
                    ImageCard4.Visibility = Visibility.Hidden;

                    // We manage the Token image source :
                    switch (card.Detective)
                    {
                        case Core.Domain.Game.Detectives.Sherlock:
                            Token.Source = new BitmapImage(new Uri("/Images/Detectives/sherlock.png", UriKind.Relative));
                            Token.Visibility = Visibility.Visible;
                            break;
                        case Core.Domain.Game.Detectives.Toby:
                            Token.Source = new BitmapImage(new Uri("/Images/Detectives/toby.png", UriKind.Relative));
                            Token.Visibility = Visibility.Visible;
                            break;
                        case Core.Domain.Game.Detectives.Watson:
                            Token.Source = new BitmapImage(new Uri("/Images/Detectives/watson.png", UriKind.Relative));
                            Token.Visibility = Visibility.Visible;
                            break;
                        default:
                            Token.Visibility = Visibility.Hidden;
                            break;
                    }
                }
                else
                {
                    // We update the ImageCard3 or 4:
                    if (IsCardWith4OpenPoints(card))
                        ImageCard3.Visibility = Visibility.Hidden;
                    else
                    {
                        ImageCard4.Visibility = Visibility.Hidden;
                        // We manage the card turn :
                        if (!card.Left)
                            rotateTransform.Angle = 90;
                        else if (!card.Up)
                            rotateTransform.Angle = 180;
                        if (!card.Right)
                            rotateTransform.Angle = -90;
                    }

                    // We manage the Token image source :
                    switch (card.Killer)
                    {
                        case Core.Domain.Game.Killers.None:
                            Token.Visibility = Visibility.Collapsed;
                            break;
                        case Core.Domain.Game.Killers.Insp_Lestrade:
                            TokenBorder.BorderBrush = System.Windows.Media.Brushes.RoyalBlue;
                            Token.Source = new BitmapImage(new Uri("/Images/killers/token_insplestrade.png", UriKind.Relative));
                            Token.Visibility = Visibility.Visible;
                            break;
                        case Core.Domain.Game.Killers.Jeremy_Bert:
                            TokenBorder.BorderBrush = System.Windows.Media.Brushes.Orange;
                            Token.Source = new BitmapImage(new Uri("/Images/killers/token_jeremybert.png", UriKind.Relative));
                            Token.Visibility = Visibility.Visible;
                            break;
                        case Core.Domain.Game.Killers.John_Pizzer:
                            TokenBorder.BorderBrush = System.Windows.Media.Brushes.WhiteSmoke;
                            Token.Source = new BitmapImage(new Uri("/Images/killers/token_johnpizer.png", UriKind.Relative));
                            Token.Visibility = Visibility.Visible;
                            break;
                        case Core.Domain.Game.Killers.John_Smith:
                            TokenBorder.BorderBrush = System.Windows.Media.Brushes.Yellow;
                            Token.Source = new BitmapImage(new Uri("/Images/killers/token_johnsmith.png", UriKind.Relative));
                            Token.Visibility = Visibility.Visible;
                            break;
                        case Core.Domain.Game.Killers.Joseph_Lane:
                            TokenBorder.BorderBrush = System.Windows.Media.Brushes.DimGray;
                            Token.Source = new BitmapImage(new Uri("/Images/killers/token_josephlane.png", UriKind.Relative));
                            Token.Visibility = Visibility.Visible;
                            break;
                        case Core.Domain.Game.Killers.Madame:
                            TokenBorder.BorderBrush = System.Windows.Media.Brushes.HotPink;
                            Token.Source = new BitmapImage(new Uri("/Images/killers/token_madame.png", UriKind.Relative));
                            Token.Visibility = Visibility.Visible;
                            break;
                        case Core.Domain.Game.Killers.Miss_Stealthy:
                            TokenBorder.BorderBrush = System.Windows.Media.Brushes.DarkSeaGreen;
                            Token.Source = new BitmapImage(new Uri("/Images/killers/token_missstealthy.png", UriKind.Relative));
                            Token.Visibility = Visibility.Visible;
                            break;
                        case Core.Domain.Game.Killers.Sgt_Goodley:
                            TokenBorder.BorderBrush = System.Windows.Media.Brushes.Black;
                            Token.Source = new BitmapImage(new Uri("/Images/killers/token_sgtgoodley.png", UriKind.Relative));
                            Token.Visibility = Visibility.Visible;
                            break;
                        case Core.Domain.Game.Killers.William_Gull:
                            TokenBorder.BorderBrush = System.Windows.Media.Brushes.MediumPurple;
                            Token.Source = new BitmapImage(new Uri("/Images/killers/token_williamgull.png", UriKind.Relative));
                            Token.Visibility = Visibility.Visible;
                            break;
                        // TODO : Add other enumeration cases
                        default:
                            break;
                    }
                }

            TokenBorder.Visibility = Token.Visibility;
        }

        private bool IsCardWith4OpenPoints(ICard card)
        {
            return card.Up && card.Down && card.Left && card.Right;
        }
    }
}
