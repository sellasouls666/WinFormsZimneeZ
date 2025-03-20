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
            this.label1 = new System.Windows.Forms.Label();
            this.descriptionTextForAdd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateBoxForAdd = new System.Windows.Forms.DateTimePicker();
            this.addButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.dateBoxForFiltr = new System.Windows.Forms.DateTimePicker();
            this.filtrButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.completeButton = new System.Windows.Forms.Button();
            this.deleteCompletedButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tasksTable)).BeginInit();
            this.SuspendLayout();
            // 
            // tasksTable
            // 
            this.tasksTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.tasksTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tasksTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tasksTable.Location = new System.Drawing.Point(12, 12);
            this.tasksTable.MultiSelect = false;
            this.tasksTable.Name = "tasksTable";
            this.tasksTable.ReadOnly = true;
            this.tasksTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tasksTable.Size = new System.Drawing.Size(776, 210);
            this.tasksTable.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 245);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Описание задачи";
            // 
            // descriptionTextForAdd
            // 
            this.descriptionTextForAdd.Location = new System.Drawing.Point(125, 242);
            this.descriptionTextForAdd.Name = "descriptionTextForAdd";
            this.descriptionTextForAdd.Size = new System.Drawing.Size(210, 20);
            this.descriptionTextForAdd.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(348, 245);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Дата выполнения";
            // 
            // dateBoxForAdd
            // 
            this.dateBoxForAdd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateBoxForAdd.Location = new System.Drawing.Point(451, 242);
            this.dateBoxForAdd.Name = "dateBoxForAdd";
            this.dateBoxForAdd.Size = new System.Drawing.Size(83, 20);
            this.dateBoxForAdd.TabIndex = 4;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(569, 241);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 5;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(290, 277);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(198, 23);
            this.deleteButton.TabIndex = 6;
            this.deleteButton.Text = "Удалить задачу";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // dateBoxForFiltr
            // 
            this.dateBoxForFiltr.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateBoxForFiltr.Location = new System.Drawing.Point(27, 317);
            this.dateBoxForFiltr.Name = "dateBoxForFiltr";
            this.dateBoxForFiltr.Size = new System.Drawing.Size(92, 20);
            this.dateBoxForFiltr.TabIndex = 7;
            // 
            // filtrButton
            // 
            this.filtrButton.Location = new System.Drawing.Point(147, 315);
            this.filtrButton.Name = "filtrButton";
            this.filtrButton.Size = new System.Drawing.Size(98, 23);
            this.filtrButton.TabIndex = 8;
            this.filtrButton.Text = "Отфильтровать";
            this.filtrButton.UseVisualStyleBackColor = true;
            this.filtrButton.Click += new System.EventHandler(this.filtrButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(266, 317);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 9;
            this.backButton.Text = "Сбросить";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // completeButton
            // 
            this.completeButton.Location = new System.Drawing.Point(27, 277);
            this.completeButton.Name = "completeButton";
            this.completeButton.Size = new System.Drawing.Size(218, 23);
            this.completeButton.TabIndex = 10;
            this.completeButton.Text = "Выполнить задачу";
            this.completeButton.UseVisualStyleBackColor = true;
            this.completeButton.Click += new System.EventHandler(this.completeButton_Click);
            // 
            // deleteCompletedButton
            // 
            this.deleteCompletedButton.Location = new System.Drawing.Point(543, 276);
            this.deleteCompletedButton.Name = "deleteCompletedButton";
            this.deleteCompletedButton.Size = new System.Drawing.Size(228, 23);
            this.deleteCompletedButton.TabIndex = 11;
            this.deleteCompletedButton.Text = "Удалить выполненные задачи";
            this.deleteCompletedButton.UseVisualStyleBackColor = true;
            this.deleteCompletedButton.Click += new System.EventHandler(this.deleteCompletedButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.deleteCompletedButton);
            this.Controls.Add(this.completeButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.filtrButton);
            this.Controls.Add(this.dateBoxForFiltr);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.dateBoxForAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.descriptionTextForAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tasksTable);
            this.Name = "MainForm";
            this.Text = "ToDoList";
            ((System.ComponentModel.ISupportInitialize)(this.tasksTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tasksTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox descriptionTextForAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateBoxForAdd;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.DateTimePicker dateBoxForFiltr;
        private System.Windows.Forms.Button filtrButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button completeButton;
        private System.Windows.Forms.Button deleteCompletedButton;
    }
}

