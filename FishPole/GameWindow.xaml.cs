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
using System.Windows.Shapes;

namespace Fishpole
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private MainWindow window;
        private Game newGame;
        public GameWindow(Game game, MainWindow window)
        {
            InitializeComponent();
            newGame = game;
            this.DataContext = newGame;
            this.window = window;
        }

        private void KnowFalse_Click(object sender, RoutedEventArgs e)
        {
            if ((KnowFalseButton.Content).ToString() == "Koniec")
            {
                newGame.endGame();
                window.Show();
                this.Close();
            }
            else 
                newGame.setWord(); 
        }

        private void KnowTrue_Click(object sender, RoutedEventArgs e)
        {
            if ((KnowTrueButton.Content).ToString() == "Kolejna runda")
                newGame.newGame();
            else {
                if (newGame.changeList() == false)
                    newGame.setWord();
                else
                    this.KnowTrueButton.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void TranslateButton_Click(object sender, RoutedEventArgs e)
        {
            if ((TranslateButton.Content).ToString() == "Zapisz stan gry")
                newGame.saveGame();
            else
                newGame.translate();
        }
    }
}
