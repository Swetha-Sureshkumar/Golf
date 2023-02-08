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

namespace GolfUI
{
    /// <summary>
    /// Interaction logic for editPoints.xaml
    /// </summary>
    public partial class editPoints : Window
    {
        private State State { get; } = new State();
        public double NewPointX { get; set; }
        public double NewPointY { get; set; }
       
        public editPoints(double x, double y)
        {
            InitializeComponent();
            DataContext =  this;
            NewPointX = x;
            NewPointY = y;

        }
        
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {

            double value;
            
            if (!double.TryParse(TextBoxX.Text, out value) || !double.TryParse(TextBoxY.Text, out value))
            {
                MessageBox.Show("Invalid point coordinates ! (Should be double or integer)");
                return;
            }

            NewPointX = double.Parse(TextBoxX.Text);
            NewPointY = double.Parse(TextBoxY.Text);
          
            DialogResult = true;
            Close();
             

        }
    }
}
