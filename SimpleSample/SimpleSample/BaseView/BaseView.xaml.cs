using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleSample.SegmentedControl
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BaseView : ContentPage
    {
        public BaseView()
        {
            InitializeComponent();
        }
    }

    public class BorderColorConverter : IValueConverter
    {
        static double YValue = 0;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var yData = (value as DataModel).YData;
                if (yData >= YValue)
                {
                    //if y value increased
                    YValue = yData;
                    return Color.Green;
                }
                else
                {
                    //if y value decreased
                    YValue = yData;
                    return Color.Red;
                }

            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}