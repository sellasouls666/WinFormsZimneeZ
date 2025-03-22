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
            this.tasksTable = new System.Windows.Forms.DataGridView();
            this.addButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.dateBoxForFiltr = new System.Windows.Forms.DateTimePicker();
            this.filtrButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.completeButton = new System.Windows.Forms.Button();
            this.deleteCompletedButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.tasksTable)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tasksTable
            // 
            this.tasksTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.tasksTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tasksTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tasksTable.Location = new System.Drawing.Point(12, 67);
            this.tasksTable.MultiSelect = false;
            this.tasksTable.Name = "tasksTable";
            this.tasksTable.ReadOnly = true;
            this.tasksTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tasksTable.Size = new System.Drawing.Size(484, 280);
            this.tasksTable.TabIndex = 0;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(15, 11);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(66, 40);
            this.addButton.TabIndex = 5;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(264, 11);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(59, 40);
            this.deleteButton.TabIndex = 6;
            this.deleteButton.Text = "Удалить задачу";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // dateBoxForFiltr
            // 
            this.dateBoxForFiltr.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateBoxForFiltr.Location = new System.Drawing.Point(116, 360);
            this.dateBoxForFiltr.Name = "dateBoxForFiltr";
            this.dateBoxForFiltr.Size = new System.Drawing.Size(92, 20);
            this.dateBoxForFiltr.TabIndex = 7;
            // 
            // filtrButton
            // 
            this.filtrButton.Location = new System.Drawing.Point(12, 358);
            this.filtrButton.Name = "filtrButton";
            this.filtrButton.Size = new System.Drawing.Size(95, 21);
            this.filtrButton.TabIndex = 8;
            this.filtrButton.Text = "Отфильтровать";
            this.filtrButton.UseVisualStyleBackColor = true;
            this.filtrButton.Click += new System.EventHandler(this.filtrButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(92, 11);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(63, 40);
            this.backButton.TabIndex = 9;
            this.backButton.Text = "Сбросить";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // completeButton
            // 
            this.completeButton.Location = new System.Drawing.Point(173, 11);
            this.completeButton.Name = "completeButton";
            this.completeButton.Size = new System.Drawing.Size(73, 40);
            this.completeButton.TabIndex = 10;
            this.completeButton.Text = "Выполнить задачу";
            this.completeButton.UseVisualStyleBackColor = true;
            this.completeButton.Click += new System.EventHandler(this.completeButton_Click);
            // 
            // deleteCompletedButton
            // 
            this.deleteCompletedButton.Location = new System.Drawing.Point(343, 11);
            this.deleteCompletedButton.Name = "deleteCompletedButton";
            this.deleteCompletedButton.Size = new System.Drawing.Size(126, 40);
            this.deleteCompletedButton.TabIndex = 11;
            this.deleteCompletedButton.Text = "Удалить выполненные задачи";
            this.deleteCompletedButton.UseVisualStyleBackColor = true;
            this.deleteCompletedButton.Click += new System.EventHandler(this.deleteCompletedButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.deleteButton);
            this.panel1.Controls.Add(this.deleteCompletedButton);
            this.panel1.Controls.Add(this.completeButton);
            this.panel1.Controls.Add(this.backButton);
            this.panel1.Controls.Add(this.addButton);
            this.panel1.Location = new System.Drawing.Point(12, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(484, 59);
            this.panel1.TabIndex = 12;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 394);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tasksTable);
            this.Controls.Add(this.filtrButton);
            this.Controls.Add(this.dateBoxForFiltr);
            this.Name = "MainForm";
            this.Text = "ToDoList";
            ((System.ComponentModel.ISupportInitialize)(this.tasksTable)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tasksTable;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.DateTimePicker dateBoxForFiltr;
        private System.Windows.Forms.Button filtrButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button completeButton;
        private System.Windows.Forms.Button deleteCompletedButton;
        private System.Windows.Forms.Panel panel1;
    }
}

