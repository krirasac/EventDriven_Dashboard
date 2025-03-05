using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for To_Do.xaml
    /// </summary>
    public partial class To_Do : Page
    {
        public To_Do()
        {
            InitializeComponent();
        }

        private void RetrieveData(object sender, RoutedEventArgs e)
        {
            Checklist.ItemsSource = Data.Incomplete;
        }

        private void ShowHide(object sender, RoutedEventArgs e)
        {
            if (CompletedList.Content.ToString() == "Show Completed")
            {
                CompletedList.Content = "Hide Completed";
                Checklist.ItemsSource = Data.Completed;
            }
            else if (CompletedList.Content.ToString() == "Hide Completed")
            {
                CompletedList.Content = "Show Completed";
                Checklist.ItemsSource = Data.Incomplete;
            }
        }

        private void TaskAddBTN_Click(object sender, RoutedEventArgs e)
        {
            EditWindow addTask = new EditWindow();
            TaskEdit addDetails = new TaskEdit();

            addTask.Title = "Add Task";
            addDetails.selectedTask = new TaskDetails();
            addDetails.currentWindow = addTask;
            addDetails.SaveTaskBTN.Content = "Add";
            addDetails.DeleteTaskBTN.Content = "Cancel";
            addTask.Show();
            addTask.EditGrid.Children.Add(addDetails);

        }
    }
}
