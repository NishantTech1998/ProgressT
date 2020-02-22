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
using Model;
using Services;
using System.Windows.Shapes;

namespace TrainingProgress
{
    /// <summary>
    /// Interaction logic for Tracking.xaml
    /// </summary>
    public partial class Tracking : Page
    {
        public Tracking()
        {
            InitializeComponent();
            ComboBox.Visibility = Visibility.Hidden;
            NewTask.Visibility= Visibility.Hidden; 
            Start.Visibility= Visibility.Hidden;
            Pause.Visibility= Visibility.Hidden; 
            Stop.Visibility= Visibility.Hidden;
        }

        private void SelectFromPlannedTask_Click(object sender, RoutedEventArgs e)
        {
            ComboBox.Items.Clear();
            Start.Visibility = Visibility.Hidden;
            NewTask.Visibility = Visibility.Hidden;
            TaskService taskService = new TaskService();
            ComboBox.Visibility = Visibility.Visible;
            foreach(string taskName in taskService.GetPlannedTask())
            {
                ComboBox.Items.Add(taskName);
            }
        }

        private void CreateNewTask_Click(object sender, RoutedEventArgs e)
        {
            Start.Visibility = Visibility.Hidden;
            ComboBox.Visibility = Visibility.Hidden;
            NewTask.Visibility = Visibility.Visible;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox.SelectedItem != null)
                Start.Visibility = Visibility.Visible;
            else
                Start.Visibility = Visibility.Hidden;
        }
        string CurrentTask;
        private void NewTask_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(NewTask.Text==null||NewTask.Text=="")
                Start.Visibility = Visibility.Hidden;
            else
                Start.Visibility = Visibility.Visible;
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Start.Visibility = Visibility.Hidden;
            Pause.Visibility = Visibility.Visible;
            Stop.Visibility = Visibility.Visible;
            CreateNewTask.Visibility = Visibility.Hidden;
            SelectFromPlannedTask.Visibility = Visibility.Hidden;
            TaskService taskService = new TaskService();
            if (!ComboBox.IsVisible)
            {
                Tasks task = new Tasks();
                task.TaskName = NewTask.Text;
                task.IsPaused = true;
                task.IsPlanned = false;
                task.TaskDate = DateTime.Now.ToString("d");
                taskService.AddTask(task);
                CurrentTask = NewTask.Text;
                taskService.StartTask(task.TaskName);
            }
            else
            {
                CurrentTask = ComboBox.Text;
                taskService.StartTask(ComboBox.Text);
            }
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            TaskService taskService = new TaskService();
            Start.Visibility = Visibility.Visible;
            Pause.Visibility = Visibility.Hidden;
            CreateNewTask.Visibility = Visibility.Visible;
            SelectFromPlannedTask.Visibility = Visibility.Visible;
            taskService.PauseTask(CurrentTask);
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            TaskService taskService = new TaskService();

            Start.Visibility = Visibility.Visible;
            Pause.Visibility = Visibility.Hidden;
            Stop.Visibility = Visibility.Hidden;
            CreateNewTask.Visibility = Visibility.Visible;
            SelectFromPlannedTask.Visibility = Visibility.Visible;
            taskService.StopTask(CurrentTask);
        }
    }
}
