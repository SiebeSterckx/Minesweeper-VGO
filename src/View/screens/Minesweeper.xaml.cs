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
using System.Windows.Threading;
using System.Xml.Linq;
using ViewModel;

namespace View.screens
{
    public partial class Minesweeper : UserControl
    {
        private DispatcherTimer timer;
        private TimeSpan elapsed;

        public Minesweeper()
        {
            InitializeComponent();

            // Initialize and start the timer
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        // Event handler for the timer tick event
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Get the game view model from the data context
            GameViewModel gameViewModel = (GameViewModel)DataContext;

            // Stop the timer if the game status is lost
            if (gameViewModel != null && gameViewModel.Game.Value.Status == GameStatus.Lost)
            {
                timer.Stop();
            }

            // Increment the elapsed time by 1 second
            elapsed += TimeSpan.FromSeconds(1);

            // Update the time display text block with the elapsed time in standard format (hh:mm:ss), standard format specifier=c
            TimeTextBlock.Text = elapsed.ToString("c");
        }
    }
}
