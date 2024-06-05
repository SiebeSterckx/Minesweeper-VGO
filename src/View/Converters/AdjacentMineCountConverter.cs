using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace View.Converters
{
    internal class AdjacentMineCountConverter : IValueConverter
    {

        //Count of adjacent mines
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int count = (int)value;

            if (count == 0)
            {
                return string.Empty; // Return empty string for zero count
            }

            return count; // Return the count for non-zero values
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
