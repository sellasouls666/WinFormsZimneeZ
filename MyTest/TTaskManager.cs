using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLib;

namespace MyTest
{
    [TestClass]
    public class TTaskManager
    {

        [TestMethod]
        [DataRow("2024-01-10", 0, "Task 1", "2024-01-10", 1, "Task 2", "2024-01-10")]
        [DataRow("2024-01-11", 2, "Task 3", "2024-01-11", 3, "Task 4", "2024-01-11")]
        [DataRow("2024-01-12")]
        public void TestFilterByDate(string dateString, params object[] expectedTaskData)
        {
            TaskManager taskManager = new TaskManager();

            taskManager.AddTask(0, "Task 1", new DateTime(2024, 01, 10));
            taskManager.AddTask(1, "Task 2", new DateTime(2024, 01, 10));
            taskManager.AddTask(2, "Task 3", new DateTime(2024, 01, 11));
            taskManager.AddTask(3, "Task 4", new DateTime(2024, 01, 11));

            DateTime filterDate = DateTime.Parse(dateString);
            taskManager.FilterByDate(filterDate);

            List<TaskItem> expectedTasks = new List<TaskItem>();

            for (int i = 0; i < expectedTaskData.Length; i += 3)
            {
                int id = Convert.ToInt32(expectedTaskData[i]);
                string description = (string)expectedTaskData[i + 1];
                DateTime dueDate = DateTime.Parse((string)expectedTaskData[i + 2]);

                expectedTasks.Add(new TaskItem(id, description, dueDate));
            }
            CollectionAssert.AreEqual(expectedTasks, taskManager.FilteredTasks);
        }

        [TestMethod]
        [DataRow("2024-01-10", 0, "Task 1")]
        [DataRow("2024-01-11", 1, "Task 2")]
        public void TestAddTask(string dueDateString, int id, string description)
        {
            TaskManager taskManager = new TaskManager();

            // Arrange
            DateTime dueDate = DateTime.Parse(dueDateString);

            // Act
            taskManager.AddTask(id, description, dueDate);

            // Assert
            // Проверка Tasks
            List<TaskItem> expectedTasks = new List<TaskItem> {
            new TaskItem(id, description, dueDate)
            };
            List<TaskItem> actualTasks = taskManager.Tasks.ToList();
            CollectionAssert.AreEqual(expectedTasks, actualTasks, "Списки Tasks не совпадают.");

            // Проверка FilteredTasks
            List<TaskItem> expectedFilteredTasks = new List<TaskItem> {
            new TaskItem(id, description, dueDate)
            };
            List<TaskItem> actualFilteredTasks = taskManager.FilteredTasks.ToList();
            CollectionAssert.AreEqual(expectedFilteredTasks, actualFilteredTasks, "Списки FilteredTasks не совпадают.");
        }
    }
}
