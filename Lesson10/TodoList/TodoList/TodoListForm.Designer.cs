namespace TodoList
{
    partial class TodoListForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            TodoLabel = new Label();
            todoTextBox = new TextBox();
            AddBtn = new Button();
            ClearBtn = new Button();
            checkedListBoxTodos = new CheckedListBox();
            ClearCheckedBtn = new Button();
            ClearAllBtn = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // TodoLabel
            // 
            TodoLabel.AutoSize = true;
            TodoLabel.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            TodoLabel.ForeColor = SystemColors.Info;
            TodoLabel.Location = new Point(116, 17);
            TodoLabel.Name = "TodoLabel";
            TodoLabel.Size = new Size(201, 45);
            TodoLabel.TabIndex = 0;
            TodoLabel.Text = "What To Do?";
            TodoLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // todoTextBox
            // 
            todoTextBox.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            todoTextBox.Location = new Point(10, 55);
            todoTextBox.Margin = new Padding(3, 2, 3, 2);
            todoTextBox.Multiline = true;
            todoTextBox.Name = "todoTextBox";
            todoTextBox.Size = new Size(414, 81);
            todoTextBox.TabIndex = 1;
            // 
            // AddBtn
            // 
            AddBtn.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            AddBtn.ForeColor = Color.FromArgb(0, 192, 0);
            AddBtn.Location = new Point(10, 141);
            AddBtn.Margin = new Padding(3, 2, 3, 2);
            AddBtn.Name = "AddBtn";
            AddBtn.Size = new Size(203, 49);
            AddBtn.TabIndex = 2;
            AddBtn.Text = "Add";
            AddBtn.UseVisualStyleBackColor = true;
            AddBtn.Click += AddBtn_Click;
            // 
            // ClearBtn
            // 
            ClearBtn.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            ClearBtn.ForeColor = Color.Red;
            ClearBtn.Location = new Point(219, 141);
            ClearBtn.Margin = new Padding(3, 2, 3, 2);
            ClearBtn.Name = "ClearBtn";
            ClearBtn.Size = new Size(206, 49);
            ClearBtn.TabIndex = 3;
            ClearBtn.Text = "Clear";
            ClearBtn.UseVisualStyleBackColor = true;
            ClearBtn.Click += ClearBtn_Click;
            // 
            // checkedListBoxTodos
            // 
            checkedListBoxTodos.FormattingEnabled = true;
            checkedListBoxTodos.Location = new Point(11, 201);
            checkedListBoxTodos.Margin = new Padding(3, 2, 3, 2);
            checkedListBoxTodos.Name = "checkedListBoxTodos";
            checkedListBoxTodos.Size = new Size(414, 238);
            checkedListBoxTodos.TabIndex = 4;
            // 
            // ClearCheckedBtn
            // 
            ClearCheckedBtn.BackColor = Color.FromArgb(255, 128, 128);
            ClearCheckedBtn.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            ClearCheckedBtn.ForeColor = Color.White;
            ClearCheckedBtn.Location = new Point(11, 458);
            ClearCheckedBtn.Margin = new Padding(3, 2, 3, 2);
            ClearCheckedBtn.Name = "ClearCheckedBtn";
            ClearCheckedBtn.Size = new Size(202, 46);
            ClearCheckedBtn.TabIndex = 5;
            ClearCheckedBtn.Text = "Clear checked";
            ClearCheckedBtn.UseVisualStyleBackColor = false;
            ClearCheckedBtn.Click += ClearCheckedBtn_Click;
            // 
            // ClearAllBtn
            // 
            ClearAllBtn.BackColor = Color.FromArgb(192, 0, 0);
            ClearAllBtn.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            ClearAllBtn.ForeColor = Color.FromArgb(192, 255, 192);
            ClearAllBtn.Location = new Point(219, 458);
            ClearAllBtn.Margin = new Padding(3, 2, 3, 2);
            ClearAllBtn.Name = "ClearAllBtn";
            ClearAllBtn.Size = new Size(206, 46);
            ClearAllBtn.TabIndex = 6;
            ClearAllBtn.Text = "Clear all";
            ClearAllBtn.UseVisualStyleBackColor = false;
            ClearAllBtn.Click += ClearAllBtn_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // TodoListForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(435, 513);
            Controls.Add(ClearAllBtn);
            Controls.Add(ClearCheckedBtn);
            Controls.Add(checkedListBoxTodos);
            Controls.Add(ClearBtn);
            Controls.Add(AddBtn);
            Controls.Add(todoTextBox);
            Controls.Add(TodoLabel);
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "TodoListForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Todo list";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TodoLabel;
        private TextBox todoTextBox;
        private Button AddBtn;
        private Button ClearBtn;
        private CheckedListBox checkedListBoxTodos;
        private Button ClearCheckedBtn;
        private Button ClearAllBtn;
        private ErrorProvider errorProvider1;
    }
}