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

        public void AddTask(int id, string description, DateTime dueDate)
        {
            tasks.Add(new TaskItem(id, description, dueDate));
            filteredTasks.Add(new TaskItem(id, description, dueDate));
        }

        public void RemoveTask(TaskItem taskToRemove)
        {
            tasks.Remove(taskToRemove);
            filteredTasks.Remove(taskToRemove);
        }

        public void FilterByDate(DateTime date)
        {
            List<TaskItem> filteredList = Tasks.Where(task => task.dueDate_.Date == date.Date).ToList();
            FilteredTasks.Clear();
            foreach (TaskItem task in filteredList)
            {
                FilteredTasks.Add(task);
            }
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

            if (FilteredTasks != null && FilteredTasks != Tasks)
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

        public void ReturnAllTasks()
        {
            FilteredTasks.Clear();
            foreach (TaskItem task in Tasks)
            {
                FilteredTasks.Add(task);
            }
        }
    }
}
