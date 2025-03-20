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
        [DataRow("2024-01-10", 2)]
        [DataRow("2024-01-11", 2)]
        [DataRow("2024-01-12", 0)]
        public void TestFilterByDate(string dateString, int expectedCount)
        {
            DateTime filterDate = DateTime.Parse(dateString);

            taskManager.FilterByDate(filterDate);

            Assert.AreEqual(expectedCount, taskManager.FilteredTasks.Count);
        }
    }
}
