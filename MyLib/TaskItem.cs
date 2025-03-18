using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class TaskItem
    {
        private string description_;
        private DateTime dueDate_;
        private bool isCompleted_;

        public TaskItem(string description, DateTime dueDate)
        {
            description_ = description;
            dueDate_ = dueDate;
            isCompleted_ = false;
        }

        public DateTime GetDate()
        {
            return dueDate_;
        }

        public bool GetStatus()
        {
            return isCompleted_;
        }

        public string GetDescription()
        {
            return description_;
        }

        public bool SetStatus(bool status)
        {
            return isCompleted_ = status;
        }
    }
}
