using Cells;
using Model.MineSweeper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.ScreenViewModels
{
    public class MainViewModel
    {
        public MainViewModel(IGame game)
        {
            //Create empty cell
            CurrentScreen = Cell.Create<ScreenViewModel>(null);

            //Create settings screen
            var firstScreen = new SettingsScreenViewModel(game, this.CurrentScreen);

            //Put first screen in CurrentScreen cell -> settings screen=first screen
            CurrentScreen.Value = firstScreen;
        }

        public ICell<ScreenViewModel> CurrentScreen { get; }
    }
}
