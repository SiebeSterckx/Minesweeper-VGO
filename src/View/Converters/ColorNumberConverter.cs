using Model.MineSweeper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace View.Converters
{
    internal class ColorNumberConverter : IValueConverter
    {
        public object Nul { get; set; }
        public object Een { get; set; }
        public object Twee { get; set; }
        public object Drie { get; set; }
        public object Vier { get; set; }
        public object Vijf { get; set; }
        public object Zes { get; set; }
        public object Zeven { get; set; }
        public object Acht { get; set; }


        //Colors for different number of adjacent mines
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var amountMines = (int)value;
            switch (amountMines)
            {
                case 0:
                    return Nul;
                case 1:
                    return Een;
                case 2:
                    return Twee;
                case 3:
                    return Drie;
                case 4:
                    return Vier;
                case 5:
                    return Vijf;
                case 6:
                    return Zes;
                case 7:
                    return Zeven;
                case 8:
                    return Acht;
                default:
                    throw new NotImplementedException();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
