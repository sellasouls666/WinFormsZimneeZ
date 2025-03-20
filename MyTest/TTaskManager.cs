using System;
using System.Collections.Generic;
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

            taskManager.AddTask("Task 1", new DateTime(2024, 01, 10));
            taskManager.AddTask("Task 2", new DateTime(2024, 01, 10));
            taskManager.AddTask("Task 3", new DateTime(2024, 01, 11));
            taskManager.AddTask("Task 4", new DateTime(2024, 01, 11));
        }

        [TestMethod]
        [DataRow("2024-01-10", 2, new string[] { "Task 1", "Task 2" })]
        [DataRow("2024-01-11", 2, new string[] { "Task 3", "Task 4" })]
        [DataRow("2024-01-12", 0, new string[] { })]
        public void TestFilterByDate(string dateString, int expectedCount, string[] expectedDescriptions)
        {
            DateTime filterDate = DateTime.Parse(dateString);

            taskManager.FilterByDate(filterDate);

            Assert.AreEqual(expectedCount, taskManager.FilteredTasks.Count);
            for (int i = 0; i < expectedDescriptions.Length; i++)
            {
                Assert.AreEqual(expectedDescriptions[i], taskManager.FilteredTasks[i].description_);
            }
        }
    }
}
