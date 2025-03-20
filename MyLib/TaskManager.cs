using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class TaskManager
    {
        private BindingList<TaskItem> tasks = new BindingList<TaskItem>();

        public BindingList<TaskItem> Tasks
        {
            get { return tasks; }
        }

        public void AddTask(string description, DateTime dueDate)
        {
            tasks.Add(new TaskItem(description, dueDate));
        }

        public void RemoveTask(int index)
        {
            if (index >= 0 && index < tasks.Count)
            {
                tasks.RemoveAt(index);
            }
            else
            {
                throw new Exception("Неверный номер задачи.");
            }
        }

        /*public List<TaskItem> GetTasksByDate(DateTime date)
        {
            return tasks.FindAll(task => task.GetDate().Date == date.Date && !task.GetStatus());
        }*/

        public void SaveToHtml(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("<html><body><h1>Список задач</h1><ul>");
                foreach (var task in tasks)
                {
                    if (!task.GetStatus())
                    {
                        writer.WriteLine($"<li>{task.GetDescription()} - {task.GetDate().ToShortDateString()}</li>");
                    }
                }
                writer.WriteLine("</ul></body></html>");
            }
        }

        public void CompleteTask(int index)
        {
            if (index >= 0 && index < tasks.Count)
            {
                tasks[index].SetStatus(true);
            }
            else
            {
                throw new Exception("Неверный номер задачи.");
            }
        }
    }
}
