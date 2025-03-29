using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class SaveToHtml
    {
        private TaskManager taskManager;

        public SaveToHtml(TaskManager taskManager)
        {
            this.taskManager = taskManager;
        }
        public void Save(string filePath)
        {
            string status = "";
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("<html><body><h1>Список задач</h1><ul>");
                foreach (var task in taskManager.FilteredTasks)
                {
                    if(task.isCompleted_)
                    {
                        status = "Выполнено";
                    }
                    if (!task.isCompleted_)
                    {
                        status = "Не выполнено";
                    }
                    writer.WriteLine($"<li>{task.GetDescription()} - {task.GetDate().ToShortDateString()} - {status}</li>");
                }
                writer.WriteLine("</ul></body></html>");
            }
        }
    }
}
