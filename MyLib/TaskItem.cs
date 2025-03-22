using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class TaskItem
    {
        private static int nextId = 0;
        public int id_;
        [DisplayName("Описание")]
        public string description_ { get; set; }
        [DisplayName("Дата выполнения")]
        public DateTime dueDate_ { get; set; }
        [DisplayName("Выполнено")]
        public bool isCompleted_ { get; set; }

        public TaskItem(string description, DateTime dueDate)
        {
            id_ = nextId++;
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

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            TaskItem other = (TaskItem)obj;
            return description_ == other.description_ &&
                   dueDate_.Date == other.dueDate_.Date && 
                   isCompleted_ == other.isCompleted_;
        }
    }
}
