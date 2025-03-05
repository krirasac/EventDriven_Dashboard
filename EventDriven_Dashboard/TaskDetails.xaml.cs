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
        public TaskDetails(string name, string date, string progress, string priority)
        {
            InitializeComponent();
            AddStatusItems();
            AddPriorityItems();

            TaskName.Content = name;
            Deadline.Content = date;
            Status.SelectedItem = progress;
            Priority.SelectedItem = priority;

        }

        private void AddStatusItems()
        {
            Status.Items.Add("Not Yet Started");
            Status.Items.Add("Ongoing");
            Status.Items.Add("Complete");
        }

        private void AddPriorityItems()
        {
            Priority.Items.Add("Low");
            Priority.Items.Add("Medium");
            Priority.Items.Add("High");
        }
    }
}
