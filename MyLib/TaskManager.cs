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
        private BindingList<TaskItem> filteredTasks = new BindingList<TaskItem>();

        public BindingList<TaskItem> Tasks
        {
            get { return tasks; }
        }

        public BindingList<TaskItem> FilteredTasks
        {
            get { return filteredTasks; }
            set { filteredTasks = value; }
        }

        public void AddTask(string description, DateTime dueDate)
        {
            tasks.Add(new TaskItem(description, dueDate));
        }

        public void RemoveTask(TaskItem taskToRemove)
        {
            tasks.Remove(taskToRemove);
            filteredTasks.Remove(taskToRemove);
        }

        public BindingList<TaskItem> GetTasksByDate(DateTime date)
        {
            var filteredTasks = tasks.Where(task => task.dueDate_.Date == date.Date).ToList();

            return new BindingList<TaskItem>(filteredTasks);
        }

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

        public void CompleteTask(TaskItem taskToComplete)
        {
            TaskItem taskToUpdate = tasks.FirstOrDefault(task => task.id_ == taskToComplete.id_);
            taskToUpdate.SetStatus(true);
        }

        public void RemoveCompletedTasks()
        {

            if (FilteredTasks != null && FilteredTasks != Tasks) // Added a check for null
            {
                List<TaskItem> incompleteFilteredTasks = filteredTasks.Where(task => !task.isCompleted_).ToList();
                filteredTasks.Clear();
                foreach (TaskItem task in incompleteFilteredTasks)
                {
                    filteredTasks.Add(task);
                }
                filteredTasks.ResetBindings();
            }

            List<TaskItem> incompleteTasks = tasks.Where(task => !task.isCompleted_).ToList();
            tasks.Clear();
            foreach (TaskItem task in incompleteTasks)
            {
                tasks.Add(task);
            }
            tasks.ResetBindings();
        }
    }
}
