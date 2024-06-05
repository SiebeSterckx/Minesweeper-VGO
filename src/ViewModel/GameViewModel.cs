using Cells;
using Model.Data;
using Model.MineSweeper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using ViewModel.Commands;
using ViewModel.ScreenViewModels;

namespace ViewModel
{

    public class GameViewModel : ScreenViewModel
    {
        public ICell<IGame> Game { get; }
        public GameBoardViewModel Board { get; }
        public ICommand ExitGameCommand { get; }


        public GameViewModel(IGame game, ICell<ScreenViewModel> currentScreen) : base(currentScreen)
        {
            // Create a cell to hold the game state
            Game = Cell.Create(game);
            // Create the game boardViewModel
            Board = new GameBoardViewModel(Game);

            //ExitGameCommand, Create an actionCommand that changes the current screen to the settings screen when executed
            ExitGameCommand = new ActionCommand(() => CurrentScreen.Value = new SettingsScreenViewModel(game, this.CurrentScreen));

        }


    }

}
