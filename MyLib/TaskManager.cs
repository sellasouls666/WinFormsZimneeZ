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
            set { tasks = value; }
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

        public void CompleteTask(TaskItem taskToComplete)
        {
            TaskItem taskToUpdate = tasks.FirstOrDefault(task => task.id_ == taskToComplete.id_);
            taskToUpdate.SetStatus(true);
            TaskItem taskToUpdateFromFiltered = filteredTasks.FirstOrDefault(task => task.id_ == taskToComplete.id_);
            taskToUpdateFromFiltered.SetStatus(true);
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

        public int GenerateNextId()
        {
            if (tasks.Count == 0)
            {
                return 0;
            }
            else
            {
                return tasks.Max(task => task.id_) + 1;
            }
        }

        public List<TaskItem> GetTasksForReminder()
        {
            DateTime now = DateTime.Now;
            DateTime tenSecondsAgo = now.AddSeconds(-10); 

            List<TaskItem> tasks = Tasks.Where(t =>
                t.dueDate_ >= tenSecondsAgo && 
                t.dueDate_ <= now &&  
                !t.IsNotified
            ).ToList();

            return tasks;
        }
    }
}
