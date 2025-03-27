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
        [DataRow(new int[] { 1, 2 }, new string[] { "Task 1", "Task 2" }, new string[] { "2024-01-15", "2024-02-20" })]
        [DataRow(new int[] { 3, 4, 5 }, new string[] { "Task 3", "Task 4", "Task 5" }, new string[] { "2024-03-10", "2024-04-05", "2024-04-06" })]
        [DataRow(new int[] { }, new string[] { }, new string[] { })]
        public void AddTask_MultipleTasks_TasksAddedCorrectly(int[] ids, string[] descriptions, string[] dueDateStrings)
        {
            // Arrange
            TaskManager taskManager = new TaskManager();
            List<TaskItem> expectedTasks = new List<TaskItem>();

            for (int i = 0; i < ids.Length; i++)
            {
                int id = ids[i];
                string description = descriptions[i];
                DateTime dueDate = DateTime.Parse(dueDateStrings[i]);
                TaskItem task = new TaskItem(id, description, dueDate);
                expectedTasks.Add(task);
                taskManager.AddTask(id, description, dueDate);
            }

            List<TaskItem> actualTasks = taskManager.Tasks.ToList();
            List<TaskItem> actualFilteredTasks = taskManager.FilteredTasks.ToList();

            CollectionAssert.AreEqual(expectedTasks, actualTasks);
            CollectionAssert.AreEqual(expectedTasks, actualFilteredTasks);
        }
    }
}
