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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace WinFormsZimneeZ
{
    public partial class MainForm: Form
    {
        public TaskManager taskManager = new TaskManager();
        private BindingSource bindingSource = new BindingSource();
        public MainForm()
        {
            InitializeComponent();
            InitializeData();
            tasksTable.DataSource = taskManager.FilteredTasks;
            tasksTable.CellFormatting += TasksTable_CellFormatting;
        }

        private void InitializeData()
        {
            taskManager.AddTask(0, "Купить молоко и хлеб", DateTime.Now.AddDays(1));
            taskManager.AddTask(1, "Пропылесосить и помыть пол", DateTime.Now.AddDays(2));
            taskManager.AddTask(2, "Подготовить отчет за месяц", DateTime.Now.AddDays(7));
        }

      

        private void addButton_Click(object sender, EventArgs e)
        {
            var addForm = new AddForm(taskManager);
            addForm.ShowDialog();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (tasksTable.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = tasksTable.SelectedRows[0];

                TaskItem selectedTask = (TaskItem)selectedRow.DataBoundItem;

                taskManager.RemoveTask(selectedTask);

            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите задачу для удаления.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void filtrButton_Click(object sender, EventArgs e)
        {
            taskManager.FilterByDate(dateBoxForFiltr.Value);
            backButton.Enabled = true;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            taskManager.ReturnAllTasks();
            backButton.Enabled = false;
        }

        private void completeButton_Click(object sender, EventArgs e)
        {
            if (tasksTable.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = tasksTable.SelectedRows[0];

                TaskItem selectedTask = (TaskItem)selectedRow.DataBoundItem;

                taskManager.CompleteTask(selectedTask);
                tasksTable.Refresh(); //чтобы выполнение отмечалось сразу, а не после клика на другую строку

            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите задачу для выполнения.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TasksTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (tasksTable.Rows[e.RowIndex].DataBoundItem is TaskItem task)
            {
                if (task.isCompleted_)
                {
                    e.CellStyle.BackColor = Color.LightGreen;
                }
                else
                {
                    e.CellStyle.BackColor = SystemColors.Window;
                }
            }
        }

        private void deleteCompletedButton_Click(object sender, EventArgs e)
        {
            taskManager.RemoveCompletedTasks();
        }
    }
}
