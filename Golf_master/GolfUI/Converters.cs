using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace GolfUI
{

    public class IsPointConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return false;
            return ((Type) value).BaseType == typeof(GolfApp.Structures.Point);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new Exception("Can't convert back");
        }
    }


    public class PointToScaleConverter : IMultiValueConverter
    {

        #region IValueConverter Members

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var position = (double) values[0];
            var minBound = (double) values[1];
            var maxBound = (double) values[2];
            var windowSize = (double) values[3];

            bool isPoint = false;
            bool isAxisReversed = false;
            if (parameter != null && parameter is string s)
            {
                isAxisReversed = s.Contains("r");
                isPoint = s.Contains("p");
            }

            var margin = (int)(windowSize * 0.1);
            var windowSpace = (int) (windowSize * 0.8);
            var space = maxBound - minBound;
            var ratio = windowSpace / space;
            var relativePosition = (position - minBound) * ratio;

            var absolutePosition = margin + relativePosition;
            if (isAxisReversed)
                absolutePosition = windowSize - absolutePosition;
            if (isPoint)
                absolutePosition -= 2.5;

            return absolutePosition;
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion

      
    }
}
