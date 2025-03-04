using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventDriven_Dashboard
{
    internal class ToDoItem
    {
        public bool isChecked = false;
        public string Name { get; set; }
        public string Deadline { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        
        public ToDoItem(string task, string date, string progress, string urgency)
        { 
            Name = task;
            Deadline = date;
            Status = progress;
            Priority = urgency;
        }
    }
}
