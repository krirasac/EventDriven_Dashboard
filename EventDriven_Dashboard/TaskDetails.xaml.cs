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
        public TaskDetails(string name, string date, string priority)
        {
            InitializeComponent();
            AddPriorityItems();

            TaskName.Content = name;
            Deadline.Content = date;
            Priority.SelectedItem = priority;

        }

        private void AddPriorityItems()
        {
            Priority.Items.Add("Low");
            Priority.Items.Add("Medium");
            Priority.Items.Add("High");
        }

        private void Complete_Checked(object sender, RoutedEventArgs e)
        {
            ToDoItem
        }
    }
}
