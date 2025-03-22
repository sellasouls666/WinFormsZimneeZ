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
        private TaskManager taskManager;

        [TestInitialize]
        public void TestInitialize()
        {
            taskManager = new TaskManager();

            taskManager.AddTask(0, "Task 1", new DateTime(2024, 01, 10));
            taskManager.AddTask(1, "Task 2", new DateTime(2024, 01, 10));
            taskManager.AddTask(2, "Task 3", new DateTime(2024, 01, 11));
            taskManager.AddTask(3, "Task 4", new DateTime(2024, 01, 11));
        }

        [TestMethod]
        [DataRow("2024-01-10", 0, "Task 1", "2024-01-10", 1, "Task 2", "2024-01-10")]
        [DataRow("2024-01-11", 2, "Task 3", "2024-01-11", 3, "Task 4", "2024-01-11")]
        [DataRow("2024-01-12")]
        public void TestFilterByDate(string dateString, params object[] expectedTaskData)
        {
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
    }
}
