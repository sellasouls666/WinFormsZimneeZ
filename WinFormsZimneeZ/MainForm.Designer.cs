using System.Drawing;
using System.Windows.Forms;

namespace WinFormsZimneeZ
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.addButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.dateBoxForFiltr = new System.Windows.Forms.DateTimePicker();
            this.filtrButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.completeButton = new System.Windows.Forms.Button();
            this.deleteCompletedButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.saveButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tasksTable = new System.Windows.Forms.DataGridView();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tasksTable)).BeginInit();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.Transparent;
            this.addButton.FlatAppearance.BorderSize = 0;
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Image = ((System.Drawing.Image)(resources.GetObject("addButton.Image")));
            this.addButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.addButton.Location = new System.Drawing.Point(10, 8);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(70, 55);
            this.addButton.TabIndex = 5;
            this.addButton.Text = "Добавить";
            this.addButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.FlatAppearance.BorderSize = 0;
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteButton.Image")));
            this.deleteButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.deleteButton.Location = new System.Drawing.Point(150, 8);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(59, 55);
            this.deleteButton.TabIndex = 6;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // dateBoxForFiltr
            // 
            this.dateBoxForFiltr.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateBoxForFiltr.Location = new System.Drawing.Point(18, 20);
            this.dateBoxForFiltr.Name = "dateBoxForFiltr";
            this.dateBoxForFiltr.Size = new System.Drawing.Size(98, 20);
            this.dateBoxForFiltr.TabIndex = 7;
            // 
            // filtrButton
            // 
            this.filtrButton.FlatAppearance.BorderSize = 0;
            this.filtrButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.filtrButton.Image = ((System.Drawing.Image)(resources.GetObject("filtrButton.Image")));
            this.filtrButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.filtrButton.Location = new System.Drawing.Point(121, 2);
            this.filtrButton.Name = "filtrButton";
            this.filtrButton.Size = new System.Drawing.Size(95, 50);
            this.filtrButton.TabIndex = 8;
            this.filtrButton.Text = "Отфильтровать";
            this.filtrButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.filtrButton.UseVisualStyleBackColor = true;
            this.filtrButton.Click += new System.EventHandler(this.filtrButton_Click);
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.Transparent;
            this.backButton.Enabled = false;
            this.backButton.FlatAppearance.BorderSize = 0;
            this.backButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backButton.Image = ((System.Drawing.Image)(resources.GetObject("backButton.Image")));
            this.backButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.backButton.Location = new System.Drawing.Point(222, 3);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(64, 52);
            this.backButton.TabIndex = 9;
            this.backButton.Text = "Сбросить";
            this.backButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // completeButton
            // 
            this.completeButton.FlatAppearance.BorderSize = 0;
            this.completeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.completeButton.Image = ((System.Drawing.Image)(resources.GetObject("completeButton.Image")));
            this.completeButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.completeButton.Location = new System.Drawing.Point(72, 8);
            this.completeButton.Name = "completeButton";
            this.completeButton.Size = new System.Drawing.Size(75, 55);
            this.completeButton.TabIndex = 10;
            this.completeButton.Text = "Выполнить";
            this.completeButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.completeButton.UseVisualStyleBackColor = true;
            this.completeButton.Click += new System.EventHandler(this.completeButton_Click);
            // 
            // deleteCompletedButton
            // 
            this.deleteCompletedButton.FlatAppearance.BorderSize = 0;
            this.deleteCompletedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteCompletedButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteCompletedButton.Image")));
            this.deleteCompletedButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.deleteCompletedButton.Location = new System.Drawing.Point(208, 7);
            this.deleteCompletedButton.Name = "deleteCompletedButton";
            this.deleteCompletedButton.Size = new System.Drawing.Size(88, 59);
            this.deleteCompletedButton.TabIndex = 11;
            this.deleteCompletedButton.Text = "\r\nУдалить выполненные";
            this.deleteCompletedButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.deleteCompletedButton.UseVisualStyleBackColor = true;
            this.deleteCompletedButton.Click += new System.EventHandler(this.deleteCompletedButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Controls.Add(this.deleteButton);
            this.panel1.Controls.Add(this.deleteCompletedButton);
            this.panel1.Controls.Add(this.completeButton);
            this.panel1.Controls.Add(this.addButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(507, 78);
            this.panel1.TabIndex = 12;
            // 
            // saveButton
            // 
            this.saveButton.FlatAppearance.BorderSize = 0;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
            this.saveButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.saveButton.Location = new System.Drawing.Point(297, 10);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(73, 53);
            this.saveButton.TabIndex = 12;
            this.saveButton.Text = "Сохранить";
            this.saveButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dateBoxForFiltr);
            this.panel2.Controls.Add(this.filtrButton);
            this.panel2.Controls.Add(this.backButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 352);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(507, 62);
            this.panel2.TabIndex = 13;
            // 
            // tasksTable
            // 
            this.tasksTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tasksTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tasksTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tasksTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tasksTable.Location = new System.Drawing.Point(0, 78);
            this.tasksTable.MultiSelect = false;
            this.tasksTable.Name = "tasksTable";
            this.tasksTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tasksTable.Size = new System.Drawing.Size(507, 274);
            this.tasksTable.TabIndex = 14;
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 414);
            this.Controls.Add(this.tasksTable);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "ToDoList";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tasksTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.DateTimePicker dateBoxForFiltr;
        private System.Windows.Forms.Button filtrButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button completeButton;
        private System.Windows.Forms.Button deleteCompletedButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView tasksTable;
    }
}

