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

        public TaskEdit()
        {
            InitializeComponent();
        }

        private void RetriveData(object sender, RoutedEventArgs e)
        {
            EditTaskName.Text = selectedTask.TaskName.Content.ToString();
            EditDeadline.Text = selectedTask.Deadline.Content.ToString();
            EditPriority.ItemsSource = selectedTask.Priority.Items;
            EditPriority.SelectedIndex = selectedTask.Priority.SelectedIndex;
        }

        private void SaveTaskBTN_Click(object sender, RoutedEventArgs e)
        {
            if (SaveTaskBTN.Content.ToString() == "Save")
            {
                selectedTask.TaskName.Content = EditTaskName.Text;
                selectedTask.Priority.SelectedIndex = EditPriority.SelectedIndex;
                
                if (Data.todo.Checklist.ItemsSource == Data.Incomplete)
                {
                    Data.Incomplete[Data.Index] = selectedTask;
                }

                else if (Data.todo.Checklist.ItemsSource == Data.Completed)
                {
                    Data.Completed[Data.Index] = selectedTask;
                }

            }
            else if (SaveTaskBTN.Content.ToString() == "Add")
            {
                selectedTask.TaskName.Content = EditTaskName.Text;
                selectedTask.Deadline.Content = EditDeadline.Text;
                selectedTask.Priority.SelectedIndex = EditPriority.SelectedIndex;
                Data.Incomplete.Add(selectedTask);
            }

            currentWindow.Close();
        }

        private void DeleteTaskBTN_Click(object sender, RoutedEventArgs e)
        {
            if (DeleteTaskBTN.Content.ToString() == "Delete")
            {
                if (Data.todo.Checklist.ItemsSource == Data.Incomplete)
                {
                    Data.Incomplete.RemoveAt(Data.Index);
                }

                else if (Data.todo.Checklist.ItemsSource == Data.Completed)
                {
                    Data.Completed.RemoveAt(Data.Index);
                }
            }

            currentWindow.Close();
        }

        private void EditDate(object sender, MouseEventArgs e)
        {
            if (EditDeadline.Text == "YYYY-MM-DD")
            { 
                EditDeadline.Text = string.Empty;
            }
        }

        private void EditName(object sender, MouseEventArgs e)
        {
            if (EditTaskName.Text == "Name")
            {
                EditDeadline.Text = string.Empty;
            }
        }
    }
}
