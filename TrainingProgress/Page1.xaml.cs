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

namespace TrainingProgress
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void AddTask_MouseEnter(object sender, MouseEventArgs e)
        {
                Button CurrentButton = (Button)e.Source;
                var converter = new System.Windows.Media.BrushConverter();
                var brush = (Brush)converter.ConvertFromString("#FF1DB8B8");
                if (CurrentButton.Background == Brushes.SeaGreen)
                CurrentButton.Background = brush;
                else
                CurrentButton.Background = Brushes.SeaGreen;
            
        }

        public void AddTask_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Source = new Uri("AddTask.xaml", UriKind.Relative);
        }
    }
}
