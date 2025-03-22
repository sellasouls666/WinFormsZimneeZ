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
            taskManager.AddTask(Convert.ToInt32(idBox.Value), descriptionBox.Text, dateBox.Value);
        }
    }
}
