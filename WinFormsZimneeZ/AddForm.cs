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
            int newId = Convert.ToInt32(idBox.Value);

            bool idExists = taskManager.Tasks.Any(task => task.id_ == newId);

            if (idExists)
            {
                MessageBox.Show("Задача с таким ID уже существует. Пожалуйста, введите другой ID.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            if (string.IsNullOrWhiteSpace(descriptionBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите описание задачи.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            taskManager.AddTask(newId, descriptionBox.Text, dateBox.Value);
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
