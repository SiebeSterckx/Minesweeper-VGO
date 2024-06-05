using Cells;
using Model.MineSweeper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModel;
using ViewModel.Commands;

namespace ViewModel.ScreenViewModels
{
    public class SettingsScreenViewModel : ScreenViewModel
    {
        //BoardSize
        public int BoardSize { get; set; }
        public int MaxBoardSize { get; set; } = IGame.MaximumBoardSize;
        public int MinBoardSize { get; set; } = IGame.MinimumBoardSize;

        //MineProbability
        public double MineProbability { get; set; }
        public double MaxMineProbability { get; set; } = IGame.MaximumMineProbability*10;
        public double MinMineProbability { get; set; } = IGame.MinimumMineProbability*10;

        //Flooding
        public bool FloodingEnabled { get; set; }

        //Error
        public string Error { get; set; }

        //StartGame command
        public ICommand StartGameCommand { get; }
        //EasyGame command
        public ICommand EasyGameCommand { get; }
        //MediumGame command
        public ICommand MediumGameCommand { get; }
        //HardGame command
        public ICommand HardGameCommand { get; }
        

        public IGame Game;



        public SettingsScreenViewModel(IGame game, ICell<ScreenViewModel> currentScreen) : base(currentScreen)
        {
            //Default values ​​are overwritten
            this.Game = game;
            FloodingEnabled = true;
            BoardSize = game.Board.Height;
            MineProbability = 3;


            //StartGame command
            StartGameCommand = new ActionCommand(() => StartGame(game));

            //EasyGame command
            EasyGameCommand = new ActionCommand(() => StartEasyGame());

            //MediumGame command
            MediumGameCommand = new ActionCommand(() => StartMediumGame());

            //HardGame command
            HardGameCommand = new ActionCommand(() => StartHardGame());

        }



        //Start Game
        private void StartGame(IGame game)
        {
            try
            {
                game = IGame.CreateRandom(BoardSize, MineProbability/10, FloodingEnabled);
                CurrentScreen.Value = new GameViewModel(game, this.CurrentScreen);
            }
            catch (Exception e)
            {
                Error = e.Message;
            }
        }

        //Start Easy Game
        private void StartEasyGame()
        {
            var game = IGame.CreateRandom(6, 0.1, true);
            CurrentScreen.Value = new GameViewModel(game, this.CurrentScreen);
        }

        //Start Medium Game
        private void StartMediumGame()
        {
            var game = IGame.CreateRandom(12, 0.2, true);
            CurrentScreen.Value = new GameViewModel(game, this.CurrentScreen);
        }

        //Start Hard Game
        private void StartHardGame()
        {
            var game = IGame.CreateRandom(20, 0.3, true);
            CurrentScreen.Value = new GameViewModel(game, this.CurrentScreen);
        }
    }
}
