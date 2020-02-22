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
using Model;
using Services;

namespace TrainingProgress
{
    /// <summary>
    /// Interaction logic for AddTask.xaml
    /// </summary>
    public partial class AddTask : Page
    {
        public AddTask()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Source = new Uri("Page1.xaml", UriKind.Relative);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Tasks task = new Tasks();
            task.TaskName = TaskTextBox.Text;
            task.IsPaused = false;
            task.IsPlanned = true;
            task.TaskDate = DateTime.Now.ToString("d");
            task.TotalTimeTaken = "0.0";
            TaskService taskService = new TaskService();
            taskService.AddTask(task);
            TaskTextBox.Text= "";
        }
    }
}
