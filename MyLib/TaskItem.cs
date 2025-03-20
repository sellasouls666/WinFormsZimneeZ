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
        [DisplayName("Описание")]
        public string description_ { get; set; }
        [DisplayName("Дата выполнения")]
        public DateTime dueDate_ { get; set; }
        [DisplayName("Выполнено")]
        public bool isCompleted_ { get; set; }

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
