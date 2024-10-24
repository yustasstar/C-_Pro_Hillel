namespace TodoListPlus
{
    partial class TodoListMainForm
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
            TodoListsListBox = new ListBox();
            AddTodoList = new Button();
            CurrentListLabel = new Label();
            checkedListBoxTodoItems = new CheckedListBox();
            AddBtn = new Button();
            RemoveBtn = new Button();
            RenameBtn = new Button();
            DeleteListBtn = new Button();
            RenameListBtn = new Button();
            SuspendLayout();
            // 
            // TodoListsListBox
            // 
            TodoListsListBox.FormattingEnabled = true;
            TodoListsListBox.ItemHeight = 19;
            TodoListsListBox.Location = new Point(12, 12);
            TodoListsListBox.Name = "TodoListsListBox";
            TodoListsListBox.Size = new Size(251, 536);
            TodoListsListBox.TabIndex = 0;
            TodoListsListBox.SelectedIndexChanged += TodoListsListBox_SelectedIndexChanged;
            // 
            // AddTodoList
            // 
            AddTodoList.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            AddTodoList.ForeColor = Color.Black;
            AddTodoList.Location = new Point(12, 554);
            AddTodoList.Name = "AddTodoList";
            AddTodoList.Size = new Size(251, 50);
            AddTodoList.TabIndex = 1;
            AddTodoList.Text = "Add new list";
            AddTodoList.UseVisualStyleBackColor = true;
            AddTodoList.Click += AddTodoList_Click;
            // 
            // CurrentListLabel
            // 
            CurrentListLabel.AutoSize = true;
            CurrentListLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            CurrentListLabel.Location = new Point(285, 9);
            CurrentListLabel.Name = "CurrentListLabel";
            CurrentListLabel.Size = new Size(192, 37);
            CurrentListLabel.TabIndex = 2;
            CurrentListLabel.Text = "<Current-List>";
            // 
            // checkedListBoxTodoItems
            // 
            checkedListBoxTodoItems.FormattingEnabled = true;
            checkedListBoxTodoItems.Location = new Point(285, 48);
            checkedListBoxTodoItems.Name = "checkedListBoxTodoItems";
            checkedListBoxTodoItems.Size = new Size(471, 445);
            checkedListBoxTodoItems.TabIndex = 3;
            // 
            // AddBtn
            // 
            AddBtn.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            AddBtn.ForeColor = Color.DarkOliveGreen;
            AddBtn.Location = new Point(285, 499);
            AddBtn.Name = "AddBtn";
            AddBtn.Size = new Size(161, 49);
            AddBtn.TabIndex = 4;
            AddBtn.Text = "Add";
            AddBtn.UseVisualStyleBackColor = true;
            AddBtn.Click += AddBtn_Click;
            // 
            // RemoveBtn
            // 
            RemoveBtn.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            RemoveBtn.ForeColor = Color.FromArgb(192, 0, 0);
            RemoveBtn.Location = new Point(452, 499);
            RemoveBtn.Name = "RemoveBtn";
            RemoveBtn.Size = new Size(156, 49);
            RemoveBtn.TabIndex = 5;
            RemoveBtn.Text = "Remove";
            RemoveBtn.UseVisualStyleBackColor = true;
            // 
            // RenameBtn
            // 
            RenameBtn.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            RenameBtn.Location = new Point(614, 499);
            RenameBtn.Name = "RenameBtn";
            RenameBtn.Size = new Size(142, 49);
            RenameBtn.TabIndex = 6;
            RenameBtn.Text = "Rename";
            RenameBtn.UseVisualStyleBackColor = true;
            // 
            // DeleteListBtn
            // 
            DeleteListBtn.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            DeleteListBtn.ForeColor = Color.FromArgb(192, 64, 0);
            DeleteListBtn.Location = new Point(544, 554);
            DeleteListBtn.Name = "DeleteListBtn";
            DeleteListBtn.Size = new Size(212, 50);
            DeleteListBtn.TabIndex = 7;
            DeleteListBtn.Text = "Delete List";
            DeleteListBtn.UseVisualStyleBackColor = true;
            // 
            // RenameListBtn
            // 
            RenameListBtn.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            RenameListBtn.ForeColor = Color.ForestGreen;
            RenameListBtn.Location = new Point(285, 554);
            RenameListBtn.Name = "RenameListBtn";
            RenameListBtn.Size = new Size(253, 50);
            RenameListBtn.TabIndex = 8;
            RenameListBtn.Text = "Rename List";
            RenameListBtn.UseVisualStyleBackColor = true;
            // 
            // TodoListMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(768, 619);
            Controls.Add(RenameListBtn);
            Controls.Add(DeleteListBtn);
            Controls.Add(RenameBtn);
            Controls.Add(RemoveBtn);
            Controls.Add(AddBtn);
            Controls.Add(checkedListBoxTodoItems);
            Controls.Add(CurrentListLabel);
            Controls.Add(AddTodoList);
            Controls.Add(TodoListsListBox);
            MaximizeBox = false;
            Name = "TodoListMainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Todo List";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox TodoListsListBox;
        private Button AddTodoList;
        private Label CurrentListLabel;
        private CheckedListBox checkedListBoxTodoItems;
        private Button AddBtn;
        private Button RemoveBtn;
        private Button RenameBtn;
        private Button DeleteListBtn;
        private Button RenameListBtn;
    }
}