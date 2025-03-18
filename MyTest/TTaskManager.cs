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
            TaskManager taskManager = new TaskManager();
            DateTime today = DateTime.Today;
            DateTime tomorrow = DateTime.Today.AddDays(1);
            DateTime yesterday = DateTime.Today.AddDays(-1);

            taskManager.AddTask("Сегодняшнее задание 1", today);
            taskManager.AddTask("Завтрашнее задание", tomorrow);
            taskManager.AddTask("Сегодняшнее задание 2", today);
            taskManager.AddTask("Вчерашнее задание", yesterday);

            List<TaskItem> tasksForToday = taskManager.GetTasksByDate(today);

            Assert.AreEqual(2, tasksForToday.Count);
            Assert.AreEqual("Сегодняшнее задание 1", tasksForToday[0].GetDescription());
            Assert.AreEqual("Сегодняшнее задание 2", tasksForToday[1].GetDescription());
        }

        [TestMethod]
        public void GetTasksByDate_NoTasksForDate_ReturnsEmptyList() //проверка возвращения пустого списка в случае, если нет задач на указанную дату
        {
            TaskManager taskManager = new TaskManager();
            DateTime today = DateTime.Today;
            DateTime tomorrow = DateTime.Today.AddDays(1);

            taskManager.AddTask("Завтрашнее задание", tomorrow);

            List<TaskItem> tasksForToday = taskManager.GetTasksByDate(today);

            Assert.AreEqual(0, tasksForToday.Count);
        }

        [TestMethod]
        public void GetTasksByDate_CompletedTasksAreNotReturned() //проверка на то, что выполненная задача не будет возвращаться
        {
            TaskManager taskManager = new TaskManager();
            DateTime today = DateTime.Today;

            taskManager.AddTask("Сегодняшнее задание 1", today);
            taskManager.AddTask("Сегодняшнее задание 2", today);
            taskManager.CompleteTask(0);

            List<TaskItem> tasksForToday = taskManager.GetTasksByDate(today);

            Assert.AreEqual(1, tasksForToday.Count);
            Assert.AreEqual("Сегодняшнее задание 2", tasksForToday[0].GetDescription());
        }

        [TestMethod]
        public void GetTasksByDate_DifferentTimesOnSameDate_ReturnsCorrectTasks() //проверка на то, что в случае двух задач в одну дату, но в разное время, вернутся обе задачи
        {
            TaskManager taskManager = new TaskManager();
            DateTime todayMorning = DateTime.Today.AddHours(8);
            DateTime todayEvening = DateTime.Today.AddHours(18);

            taskManager.AddTask("Утреннее задание", todayMorning);
            taskManager.AddTask("Вечерное задание", todayEvening);

            List<TaskItem> tasksForToday = taskManager.GetTasksByDate(DateTime.Today);

            Assert.AreEqual(2, tasksForToday.Count);
            Assert.AreEqual("Утреннее задание", tasksForToday[0].GetDescription());
            Assert.AreEqual("Вечерное задание", tasksForToday[1].GetDescription());
        }
    }
}
