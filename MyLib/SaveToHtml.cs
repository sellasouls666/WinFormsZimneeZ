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
                    writer.WriteLine("<!DOCTYPE html>");
                    writer.WriteLine("<html>");
                    writer.WriteLine("<head>");
                    writer.WriteLine("<title>Список задач</title>");
                    writer.WriteLine("<style>");
                    writer.WriteLine("table { border-collapse: collapse; width: 100%; }");
                    writer.WriteLine("th, td { border: 1px solid black; padding: 8px; text-align: left; }");
                    writer.WriteLine("th { background-color: #f2f2f2; }");
                    writer.WriteLine(".completed { background-color: #ccffcc; }");
                    writer.WriteLine("</style>");
                    writer.WriteLine("</head>");
                    writer.WriteLine("<body>");
                    writer.WriteLine("<h1>Список задач</h1>");
                    writer.WriteLine("<table>");
                    writer.WriteLine("<thead><tr><th>Описание</th><th>Дата</th><th>Статус</th></tr></thead>");
                    writer.WriteLine("<tbody>");

                    foreach (var task in taskManager.FilteredTasks)
                    {
                        string rowClass = task.isCompleted_ ? "completed" : "";
                        if (task.isCompleted_)
                        {
                            status = "Выполнено";
                        }
                        else
                        {
                            status = "Не выполнено";
                        }
                        writer.WriteLine($"<tr class=\"{rowClass}\"><td>{task.GetDescription()}</td><td>{task.GetDate().ToShortDateString()}</td><td>{status}</td></tr>");
                    }

                    writer.WriteLine("</tbody>");
                    writer.WriteLine("</table>");
                    writer.WriteLine("</body>");
                    writer.WriteLine("</html>");
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
