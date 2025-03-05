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

namespace EventDriven_Dashboard
{
    /// <summary>
    /// Interaction logic for TaskEdit.xaml
    /// </summary>
    public partial class TaskEdit : UserControl
    {
        public TaskDetails selectedTask { get; set; }
        public EditWindow currentWindow { get; set; }

        public int index { get; set; };

        public TaskEdit()
        {
            InitializeComponent();
        }

        private void RetriveData(object sender, RoutedEventArgs e)
        {
            EditTaskName.Text = selectedTask.TaskName.Content.ToString();
            EditPriority.ItemsSource = selectedTask.Priority.Items;
            EditPriority.SelectedIndex = selectedTask.Priority.SelectedIndex;
        }

        private void SaveTaskBTN_Click(object sender, RoutedEventArgs e)
        {
            if (SaveTaskBTN.Content.ToString() == "Save")
            {
                selectedTask.TaskName.Content = EditTaskName.Text;
                selectedTask.Priority.SelectedIndex = EditPriority.SelectedIndex;
            }
            else if (SaveTaskBTN.Content.ToString() == "Add")
            {
                Data.Incomplete.Add(selectedTask);
            }

            currentWindow.Close();
        }

        private void DeleteTaskBTN_Click(object sender, RoutedEventArgs e)
        {
            if (SaveTaskBTN.Content.ToString() == "Delete")
            {
            }

            currentWindow.Close();

        }
    }
}
