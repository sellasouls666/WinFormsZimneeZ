using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLib;

namespace MyTest
{
    [TestClass]
    public class TTaskManager
    {
        [TestMethod]
        public void GetTasksByDate_ReturnsCorrectTasks() // проверка правильного возвращения задач на определённую дату
        {
            // Arrange
            TaskManager taskManager = new TaskManager();
            DateTime today = DateTime.Today;
            DateTime tomorrow = DateTime.Today.AddDays(1);
            DateTime yesterday = DateTime.Today.AddDays(-1);

            taskManager.AddTask("Сегодняшнее задание 1", today);
            taskManager.AddTask("Завтрашнее задание", tomorrow);
            taskManager.AddTask("Сегодняшнее задание 2", today);
            taskManager.AddTask("Вчерашнее задание", yesterday);

            // Act
            List<TaskItem> tasksForToday = taskManager.GetTasksByDate(today);

            // Assert
            Assert.AreEqual(2, tasksForToday.Count);
            Assert.AreEqual("Сегодняшнее задание 1", tasksForToday[0].GetDescription());
            Assert.AreEqual("Сегодняшнее задание 2", tasksForToday[1].GetDescription());
        }

        [TestMethod]
        public void GetTasksByDate_NoTasksForDate_ReturnsEmptyList() //проверка возвращения пустого списка в случае, если нет задач на указанную дату
        {
            // Arrange
            TaskManager taskManager = new TaskManager();
            DateTime today = DateTime.Today;
            DateTime tomorrow = DateTime.Today.AddDays(1);

            taskManager.AddTask("Завтрашнее задание", tomorrow);

            // Act
            List<TaskItem> tasksForToday = taskManager.GetTasksByDate(today);

            // Assert
            Assert.AreEqual(0, tasksForToday.Count);
        }
    }
}
