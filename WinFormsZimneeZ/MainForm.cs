using MyLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace WinFormsZimneeZ
{
    public partial class MainForm: Form
    {
        public TaskManager taskManager = new TaskManager();
        public SaveToHtml saveToHtml;
        private NotifyIcon notifyIcon;
        private System.Timers.Timer timer;
        public MainForm()
        {
            InitializeComponent();
            saveToHtml = new SaveToHtml(taskManager);
            saveToHtml.OnError += SaveToHtml_OnError;
            SQLDataReader sqlreader = new SQLDataReader();
            taskManager.Tasks = sqlreader.ReadData();
            taskManager.FilteredTasks = sqlreader.ReadData();
            tasksTable.DataSource = taskManager.FilteredTasks;
            tasksTable.CellFormatting += TasksTable_CellFormatting;
            tasksTable.CellContentClick += TasksTable_CellContentClick;
            StartTimer();
        }

        private void StartTimer()
        {
            timer = new System.Timers.Timer();
            timer.Interval = 1000; 
            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = true; 
            timer.Enabled = true; 
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            CheckForReminders();
        }

        private void CheckForReminders()
        {
            if (tasksTable.InvokeRequired)
            {
                tasksTable.Invoke(new Action(CheckForReminders));
                return;
            }

            // Get the list of tasks that need a reminder from the TaskManager
            List<TaskItem> tasks = taskManager.GetTasksForReminder();

            if (tasks.Count > 0)
            {
                // Build the notification message
                string notificationMessage = "Напоминания о задачах:\n";
                foreach (TaskItem task in tasks)
                {
                    notificationMessage += $"- {task.description_}\n";
                    task.IsNotified = true; // Mark it notified
                }

                ShowNotification(notificationMessage); // Show one combined notification

                // Refresh DGV
                tasksTable.Refresh();
            }
        }
        

        private void ShowNotification(string taskDescription)
        {
            // Показываем уведомление в трее
            notifyIcon.BalloonTipTitle = "Напоминание о задаче";
            notifyIcon.BalloonTipText = taskDescription;
            notifyIcon.Visible = true; // Сначала делаем иконку видимой
            notifyIcon.ShowBalloonTip(10000); // Показываем уведомление на 3 секунды

            // Скрываем иконку после показа уведомления (чтобы не мешала)
            System.Windows.Forms.Timer hideIconTimer = new System.Windows.Forms.Timer();
            hideIconTimer.Interval = 10000;
            hideIconTimer.Tick += (sender, e) => {
                notifyIcon.Visible = false;
                hideIconTimer.Stop();
                hideIconTimer.Dispose();
            };
            hideIconTimer.Start();
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

        private void TasksTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == tasksTable.Columns["isCompleted_"].Index && e.RowIndex >= 0)
            {
                TaskItem selectedTask = (TaskItem)tasksTable.Rows[e.RowIndex].DataBoundItem;

                taskManager.CompleteTask(selectedTask);

            }
        }

        private void deleteCompletedButton_Click(object sender, EventArgs e)
        {
            taskManager.RemoveCompletedTasks();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "HTML files (*.html)|*.html|All files (*.*)|*.*";
            saveFileDialog.Title = "Выберите место для сохранения списка задач";
            saveFileDialog.DefaultExt = "html";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                saveToHtml.Save(filePath);
                MessageBox.Show("Список задач успешно сохранен в: " + filePath, "Сохранение успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SaveToHtml_OnError(string errorMessage)
        {
            // Этот метод будет вызван, когда в SaveToHtml произойдет ошибка
            MessageBox.Show(errorMessage, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
