using MahApps.Metro.Controls;
using MrJack.Client.Wpf.Controls;
using MrJack.Client.Wpf.Moqs;
using MrJack.Core.Domain.Game;
using MrJack.Core.Interfaces.Game;
using System;
using System.Collections.Generic;
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
        List<CardRender> SelectedCard = new List<CardRender>();
        IAction currentSelectedAction;
        int selectedActionIndex = -1;

        PlayerType WhoAmI { get; set; }

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
            cards[0, 1] = Card10;
            cards[0, 2] = Card20;
            cards[0, 3] = Card30;
            cards[0, 4] = Card40;
            cards[1, 0] = Card01; // Line 1
            cards[1, 1] = Card11;
            cards[1, 2] = Card21;
            cards[1, 3] = Card31;
            cards[1, 4] = Card41;
            cards[2, 0] = Card02; // Line 2
            cards[2, 1] = Card12;
            cards[2, 2] = Card22;
            cards[2, 3] = Card32;
            cards[2, 4] = Card42;
            cards[3, 0] = Card03; // Line 3
            cards[3, 1] = Card13;
            cards[3, 2] = Card23;
            cards[3, 3] = Card33;
            cards[3, 4] = Card43;
            cards[4, 0] = Card04; // Line 4
            cards[4, 1] = Card14;
            cards[4, 2] = Card24;
            cards[4, 3] = Card34;
            cards[4, 4] = Card44;
        }

        private void ConfigureNewGame_Click(object sender, RoutedEventArgs e)
        {
            newGameFlyout.IsOpen = true;
        }

        private void StartNewGame_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selectedItem = comboPlayerType.SelectedItem as ComboBoxItem;
            switch ((string)selectedItem.Content)
            {
                case "Sherlock Holmes":
                    WhoAmI = PlayerType.Sherlock;
                    break;
                case "Mr Jack":
                    WhoAmI = PlayerType.MrJack;
                    break;
            }
            selectedItem = comboDifficulty.SelectedItem as ComboBoxItem;
            Difficulty difficulty = Difficulty.Easy;
            switch ((string)selectedItem.Content)
            {
                case "Medium":
                    difficulty = Difficulty.Medium;
                    break;
                case "Difficile":
                    difficulty = Difficulty.Hard;
                    break;
            }
            currentGame.StartNewGame(WhoAmI, difficulty);
            
            Refresh();
        }

        #region Refresh

        private void Refresh()
        {
            if (currentGame == null)
                return;

            foreach (var card in SelectedCard)
                card.Select(false);
            SelectedCard.Clear();

            moveSelectionPanel.Visibility = Visibility.Collapsed;
            selectJokerActionPanel.Visibility = Visibility.Collapsed;
            changeCardsActionPanel.Visibility = Visibility.Collapsed;

            // Start to refresh available actions :
            for (int i = 0; i < 4; i++)
            {
                var action = currentGame.AvailableActions[i];
                var button = GetAvailableActionButton(i+1);
                var image = GetAvailableActionImage(i+1);

                button.IsEnabled = action.Selectable;
                image.Source = new BitmapImage(new Uri("/Images/Actions/" + action.ActionType.ToString() + ".png", UriKind.Relative));
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

        #region Cards selection

        private void Card_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var cardRender = sender as CardRender;
            if (CanSelectCard(cardRender))
            {
                if(currentSelectedAction.ActionType == ActionType.Turn) // 1 item selectable :
                {
                    if (SelectedCard.Count == 1)
                        SelectedCard[0].Select(false);
                    SelectedCard.Clear();

                    cardRender.Select(!cardRender.IsSelected);

                    if (cardRender.IsSelected)
                        SelectedCard.Add(cardRender);
                }
                else if (currentSelectedAction.ActionType == ActionType.Move) // 2 items selectable :
                {
                    if (SelectedCard.Count > 1)
                    {
                        SelectedCard[0].Select(false);
                        SelectedCard.RemoveAt(0);
                    }
                    cardRender.Select(!cardRender.IsSelected);
                    if (cardRender.IsSelected)
                        SelectedCard.Add(cardRender);
                }
            }
        }

        /// <summary>
        /// Define if we can select the card
        /// </summary>
        /// <param name="cardRender"></param>
        /// <returns></returns>
        private bool CanSelectCard(CardRender cardRender)
        {
            if (currentSelectedAction == null)
                return false;
            
            switch (currentSelectedAction.ActionType)
            {
                case ActionType.Joker:
                    return cardRender.Card.CardType == CardType.Jeton && cardRender.Card.Detective != Detectives.None;
                case ActionType.Turn:
                case ActionType.Move:
                    return cardRender.Card.CardType == CardType.Card;
            }

            return false;
        }

        #endregion

        #region Available actions click

        private void AvailableAction1Btn_Click(object sender, RoutedEventArgs e)
        {
            currentSelectedAction = null;
            if (currentGame.AvailableActions[0].Selectable)
            {
                selectedActionIndex = 0;
                currentSelectedAction = currentGame.AvailableActions[0];
            }
            ManageSelectedAction();
        }

        private void AvailableAction2Btn_Click(object sender, RoutedEventArgs e)
        {
            currentSelectedAction = null;
            if (currentGame.AvailableActions[1].Selectable)
            {
                selectedActionIndex = 1;
                currentSelectedAction = currentGame.AvailableActions[1];
            }
            ManageSelectedAction();
        }

        private void AvailableAction3Btn_Click(object sender, RoutedEventArgs e)
        {
            currentSelectedAction = null;
            if (currentGame.AvailableActions[2].Selectable)
            {
                selectedActionIndex = 2;
                currentSelectedAction = currentGame.AvailableActions[2];
            }
            ManageSelectedAction();
        }

        private void AvailableAction4Btn_Click(object sender, RoutedEventArgs e)
        {
            currentSelectedAction = null;
            if (currentGame.AvailableActions[3].Selectable)
            {
                selectedActionIndex = 3;
                currentSelectedAction = currentGame.AvailableActions[3];
            }
            ManageSelectedAction();
        }

        private void ManageSelectedAction()
        {
            foreach (var card in SelectedCard)
                card.Select(false);
            SelectedCard.Clear();

            if (currentSelectedAction != null)
            {
                moveSelectionPanel.Visibility = Visibility.Collapsed;
                selectJokerActionPanel.Visibility = Visibility.Collapsed;
                changeCardsActionPanel.Visibility = Visibility.Collapsed;

                switch (currentSelectedAction.ActionType)
                {
                    case ActionType.Draw:
                        currentGame.Draw(selectedActionIndex);
                        Refresh();
                        break;
                    case ActionType.Move:
                        changeCardsActionPanel.Visibility = Visibility.Visible;
                        break;
                    case ActionType.Toby:
                    case ActionType.Watson:
                    case ActionType.Sherlock:
                    case ActionType.Turn:
                        moveSelectionPanel.Visibility = Visibility.Visible;
                        // Now we need to wait the user to select the number of moves
                        break;
                    case ActionType.Joker:
                        if(WhoAmI == PlayerType.Sherlock) // Detective
                            moveSelectionPanel.Visibility = Visibility.Visible;
                        else // Killer
                            selectJokerActionPanel.Visibility = Visibility.Visible;
                        break;
                }
            }
        }

        #endregion

        private void changeCard_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedCard.Count == 2)
            {
                currentGame.MoveCard(selectedActionIndex, SelectedCard[0].IndexX, SelectedCard[0].IndexY, SelectedCard[1].IndexX, SelectedCard[1].IndexY);
                Refresh();
            }
            else
                customMessage.Text = "Veuillez sélectionner 2 cartes.";
        }

        private CardRender FindDetective(Detectives dectective)
        {
            for (int i = 0; i < 5; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    if (currentGame.GameBoard.Board[i, j].Detective == dectective)
                        return cards[i, j];
                }
            }
            return null;
        }

        private void ValidateNbTurns_Click(object sender, RoutedEventArgs e)
        {
            int nbturns = 0;
            CardRender card = null;
            switch(currentSelectedAction.ActionType)
            {
                case ActionType.Turn:
                    if (SelectedCard.Count == 1)
                    {
                        if (int.TryParse(nbMovesForselectedItems.Text, out nbturns))
                        {
                            currentGame.TurnCard(selectedActionIndex, SelectedCard[0].IndexX, SelectedCard[0].IndexY, int.Parse(nbMovesForselectedItems.Text));
                            Refresh();
                        }
                        else
                            customMessage.Text = "Nombre de tours invalide";
                    }
                    break;
                case ActionType.Toby:
                    card = FindDetective(Detectives.Toby);
                    if (int.TryParse(nbMovesForselectedItems.Text, out nbturns))
                    {
                        currentGame.MoveDetective(selectedActionIndex, card.IndexX, card.IndexY, int.Parse(nbMovesForselectedItems.Text));
                        Refresh();
                    }
                    else
                        customMessage.Text = "Nombre de tours invalide";
                    break;
                case ActionType.Sherlock:
                    card = FindDetective(Detectives.Sherlock);
                    if (int.TryParse(nbMovesForselectedItems.Text, out nbturns))
                    {
                        currentGame.MoveDetective(selectedActionIndex, card.IndexX, card.IndexY, int.Parse(nbMovesForselectedItems.Text));
                        Refresh();
                    }
                    else
                        customMessage.Text = "Nombre de tours invalide";
                    break;
                case ActionType.Watson:
                    card = FindDetective(Detectives.Watson);
                    if (int.TryParse(nbMovesForselectedItems.Text, out nbturns))
                    {
                        currentGame.MoveDetective(selectedActionIndex, card.IndexX, card.IndexY, int.Parse(nbMovesForselectedItems.Text));
                        Refresh();
                    }
                    else
                        customMessage.Text = "Nombre de tours invalide";
                    break;
            }
        }

        private void DoNothing_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
