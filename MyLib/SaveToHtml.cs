using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
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

        public delegate void ErrorHandler(string errorMessage);

        // Объявляем событие, которое будет вызываться при возникновении ошибки
        public event ErrorHandler OnError;

        public void Save(string filePath)
        {
            string status = "";

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("<html><body><h1>Список задач</h1><ul>");
                    foreach (var task in taskManager.FilteredTasks)
                    {
                        if (task.isCompleted_)
                        {
                            status = "Выполнено";
                        }
                        else
                        {
                            status = "Не выполнено";
                        }
                        writer.WriteLine($"<li>{task.GetDescription()} - {task.GetDate().ToShortDateString()} - {status}</li>");
                    }
                    writer.WriteLine("</ul></body></html>");
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                string errorMessage = $"Ошибка: Директория не найдена: {ex.Message}";
                OnError?.Invoke(errorMessage);
            }
            catch (UnauthorizedAccessException ex)
            {
                // Обработка ошибки, если нет доступа к файлу
                string errorMessage = $"Ошибка: Нет доступа к файлу: {ex.Message}";
                OnError?.Invoke(errorMessage);
            }
            catch (IOException ex)
            {
                // Обработка общих ошибок ввода-вывода
                string errorMessage = $"Ошибка ввода-вывода: {ex.Message}";
                OnError?.Invoke(errorMessage);
            }
            catch (Exception ex)
            {
                // Обработка любых других ошибок
                string errorMessage = $"Непредвиденная ошибка: {ex.Message}";
                OnError?.Invoke(errorMessage);
            }
        }
    }
    
}
