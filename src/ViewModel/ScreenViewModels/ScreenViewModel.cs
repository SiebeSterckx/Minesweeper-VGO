using Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.ScreenViewModels
{
    public class ScreenViewModel
    {

            /// Cell containing the current screen
            public ScreenViewModel(ICell<ScreenViewModel> currentScreen)
            {
                this.CurrentScreen = currentScreen;
            }

            public ICell<ScreenViewModel> CurrentScreen { get; }
    }
}
