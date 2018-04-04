using MahApps.Metro.Controls;
using MrJack.Client.Wpf.Controls;
using MrJack.Client.Wpf.Moqs;
using MrJack.Core.Domain.Game;
using MrJack.Core.Interfaces.Game;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MrJack.Client.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        IGame currentGame;
        CardRender[,] cards;

        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            newGameFlyout.IsOpen = true;

            // TODO : Init game object
            currentGame = new Game();

            // Register CardRender table :
            cards = new CardRender[5, 5];
            cards[0, 0] = Card00; // Line 0
            cards[0, 1] = Card01;
            cards[0, 2] = Card02;
            cards[0, 3] = Card03;
            cards[0, 4] = Card04;
            cards[1, 0] = Card10; // Line 1
            cards[1, 1] = Card11;
            cards[1, 2] = Card12;
            cards[1, 3] = Card13;
            cards[1, 4] = Card14;
            cards[2, 0] = Card20; // Line 2
            cards[2, 1] = Card21;
            cards[2, 2] = Card22;
            cards[2, 3] = Card23;
            cards[2, 4] = Card24;
            cards[3, 0] = Card30; // Line 3
            cards[3, 1] = Card31;
            cards[3, 2] = Card32;
            cards[3, 3] = Card33;
            cards[3, 4] = Card34;
            cards[4, 0] = Card40; // Line 4
            cards[4, 1] = Card41;
            cards[4, 2] = Card42;
            cards[4, 3] = Card43;
            cards[4, 4] = Card44;

            Refresh();
        }

        private void ConfigureNewGame_Click(object sender, RoutedEventArgs e)
        {
            newGameFlyout.IsOpen = true;
        }

        private void StartNewGame_Click(object sender, RoutedEventArgs e)
        {
            currentGame.StartNewGame(PlayerType.MrJack, Difficulty.Easy);
            Refresh();
        }

        #region Refresh

        private void Refresh()
        {
            if (currentGame == null)
                return;

            // Start to refresh available actions :
            for (int i = 0; i < 4; i++)
            {
                var action = currentGame.AvailableActions[i];
                var button = GetAvailableActionButton(i+1);
                var image = GetAvailableActionImage(i+1);

                button.IsEnabled = action.Selectable;
            }

            // Killer image type:
            // We manage the Token image source :
            switch (currentGame.Killer)
            {
                case Killers.None:
                    KillerUserImage.Visibility = Visibility.Collapsed;
                    break;
                case Killers.Insp_Lestrade:
                    KillerUserImage.Source = new BitmapImage(new Uri("/Images/killers/insplestrade.png", UriKind.Relative));
                    break;
                case Killers.Jeremy_Bert:
                    KillerUserImage.Source = new BitmapImage(new Uri("/Images/killers/jeremybert.png", UriKind.Relative));
                    break;
                case Killers.John_Pizzer:
                    KillerUserImage.Source = new BitmapImage(new Uri("/Images/killers/johnpizer.png", UriKind.Relative));
                    break;
                case Killers.John_Smith:
                    KillerUserImage.Source = new BitmapImage(new Uri("/Images/killers/johnsmith.png", UriKind.Relative));
                    break;
                case Killers.Joseph_Lane:
                    KillerUserImage.Source = new BitmapImage(new Uri("/Images/killers/josephlane.png", UriKind.Relative));
                    break;
                case Killers.Madame:
                    KillerUserImage.Source = new BitmapImage(new Uri("/Images/killers/madame.png", UriKind.Relative));
                    break;
                case Killers.Miss_Stealthy:
                    KillerUserImage.Source = new BitmapImage(new Uri("/Images/killers/missstealthy.png", UriKind.Relative));
                    break;
                case Killers.Sgt_Goodley:
                    KillerUserImage.Source = new BitmapImage(new Uri("/Images/killers/sgtgoodley.png", UriKind.Relative));
                    break;
                case Killers.William_Gull:
                    KillerUserImage.Source = new BitmapImage(new Uri("/Images/killers/williamgull.png", UriKind.Relative));
                    break;
                // TODO : Add other enumeration cases
                default:
                    break;
            }

            // Points :
            PointSherlock.Text = currentGame.DetectivePoints.ToString();
            PointMrJack.Text = currentGame.KillerPoints.ToString();

            // Board
            for (int i = 0; i < 5; i++)
            {
                for(int j = 0; j< 5; j++)
                {
                    cards[i, j].SetCard(currentGame.GameBoard.Board[i, j]);
                }
            }
        }

        #endregion

        #region UI Helpers

        private Button GetAvailableActionButton(int i)
        {
            switch(i)
            {
                case 1:
                    return AvailableAction1Btn;
                case 2:
                    return AvailableAction2Btn;
                case 3:
                    return AvailableAction3Btn;
                case 4:
                    return AvailableAction4Btn;
                default:
                    return null;
            }
        }

        private Image GetAvailableActionImage(int i)
        {
            switch (i)
            {
                case 1:
                    return AvailableAction1Img;
                case 2:
                    return AvailableAction2Img;
                case 3:
                    return AvailableAction3Img;
                case 4:
                    return AvailableAction4Img;
                default:
                    return null;
            }
        }

        #endregion
    }
}
