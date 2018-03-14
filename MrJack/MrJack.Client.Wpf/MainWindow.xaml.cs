﻿using MahApps.Metro.Controls;
using MrJack.Core.Interfaces;
using MrJack.Core.Interfaces.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MrJack.Client.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        IGame currentGame;

        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            newGameFlyout.IsOpen = true;
        }

        private void ConfigureNewGame_Click(object sender, RoutedEventArgs e)
        {
            newGameFlyout.IsOpen = true;
        }

        private void StartNewGame_Click(object sender, RoutedEventArgs e)
        {
            currentGame.StartNewGame(Core.Domain.Game.PlayerType.MrJack, Core.Domain.Game.Difficulty.Easy);
        }
    }
}
