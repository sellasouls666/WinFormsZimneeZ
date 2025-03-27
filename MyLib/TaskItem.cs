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
        public int id_;
        [DisplayName("Описание"), ReadOnly(true)]
        public string description_ { get; set; }
        [DisplayName("Дата выполнения"), ReadOnly(true)]
        public DateTime dueDate_ { get; set; }
        [DisplayName("Выполнено"), ReadOnly(false)]
        public bool isCompleted_ { get; set; }

        public TaskItem(int id, string description, DateTime dueDate)
        {
            id_ = id;
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
            return id_ == other.id_ &&
                   description_ == other.description_ &&
                   dueDate_.Date == other.dueDate_.Date && 
                   isCompleted_ == other.isCompleted_;
        }
    }
}
