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

            // Create a list of expected TaskItem objects
            List<TaskItem> expectedTasks = expectedDescriptions.Select(desc => new TaskItem(desc, filterDate)).ToList();


            CollectionAssert.AreEqual(expectedTasks, taskManager.FilteredTasks);
        }
    }
}
