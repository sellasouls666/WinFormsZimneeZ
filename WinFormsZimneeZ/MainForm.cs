﻿using MyLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsZimneeZ
{
    public partial class MainForm: Form
    {
        private TaskManager taskManager = new TaskManager();
        public MainForm()
        {
            InitializeComponent();
            InitializeData();
            tasksTable.DataSource = taskManager.Tasks;
        }

        private void InitializeData()
        {
            taskManager.AddTask("Купить молоко и хлеб", DateTime.Now.AddDays(1));
            taskManager.AddTask("Пропылесосить и помыть пол", DateTime.Now.AddDays(2));
            taskManager.AddTask("Подготовить отчет за месяц", DateTime.Now.AddDays(7));
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(descriptionTextForAdd.Text))
            {
                MessageBox.Show("Пожалуйста, введите описание задачи.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            taskManager.AddTask(descriptionTextForAdd.Text, dateBoxForAdd.Value);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            int rowIndex = tasksTable.SelectedRows[0].Index;
            taskManager.RemoveTask(rowIndex);
        }

        private void filtrButton_Click(object sender, EventArgs e)
        {
            tasksTable.DataSource = taskManager.GetTasksByDate(dateBoxForFiltr.Value);
        }


    }
}
