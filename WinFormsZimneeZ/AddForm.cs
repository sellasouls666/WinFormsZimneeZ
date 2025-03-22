using MyLib;
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
    public partial class AddForm: Form
    {
        private TaskManager taskManager;

        public AddForm(TaskManager taskManager)
        {
            InitializeComponent();
            this.taskManager = taskManager;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            int newId = taskManager.GenerateNextId();

            if (string.IsNullOrWhiteSpace(descriptionBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите описание задачи.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            taskManager.AddTask(newId, descriptionBox.Text, dateBox.Value);

            MessageBox.Show("Задача успешно добавлена", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
