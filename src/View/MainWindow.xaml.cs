using Cells;
using Model.MineSweeper;
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
using ViewModel;
using ViewModel.ScreenViewModels;

namespace View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Create default game with random settings (will be overwritten in SettingsScreenViewModel)
            IGame game = IGame.CreateRandom(8, 0.1, true);

            // Set the data context to a new instance of MainViewModel, passing in the game
            DataContext = new MainViewModel(game);
        }
    }
}
