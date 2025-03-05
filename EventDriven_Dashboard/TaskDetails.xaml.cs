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
    /// Interaction logic for TaskDetails.xaml
    /// </summary>
    public partial class TaskDetails : UserControl
    {
        public TaskDetails(string name, string date, string urgency)
        {
            InitializeComponent();
            AddPriorityItems();
            TaskName.Content = name; Deadline.Content = date;
            Priority.SelectedItem = urgency;
        }
        
        public TaskDetails()
        {
            InitializeComponent();
            AddPriorityItems();
            Priority.SelectedIndex = 0;
        }
        private void AddPriorityItems()
        {
            Priority.Items.Add("-Select Priority-");
            Priority.Items.Add("Low");
            Priority.Items.Add("Medium");
            Priority.Items.Add("High");
        }
        private void EditBTN_Click(object sender, RoutedEventArgs e)
        {
            EditWindow editTask = new EditWindow();
            TaskEdit edit = new TaskEdit();
            
            editTask.Title = "Edit Task";
            edit.currentWindow = editTask;
            edit.selectedTask = this;
            editTask.Show();
            editTask.EditGrid.Children.Add(edit);
        }

        private void ReturnINC(object sender, RoutedEventArgs e)
        {
            Data.Incomplete.Add(this);
            Data.Completed.Remove(this);
        }

        private void ReturnComplete(object sender, RoutedEventArgs e)
        {
            if (Complete.IsChecked == true)
            {
                Data.Completed.Add(this);
                Data.Incomplete.Remove(this);
            }
        }
    }
}
