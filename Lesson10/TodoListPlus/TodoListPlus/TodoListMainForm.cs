namespace TodoListPlus
{
    public partial class TodoListMainForm : Form
    {
        public List<string> TodoLists = new();
        public List<string> TodoItems = new();
        public List<bool> IsComplete = new();
        private string TodoListsPath = "../../../todo-lists.txt";
        private string TodoItemsPath;

        public TodoListMainForm()
        {
            InitializeComponent();
            //if (!Directory.Exists("../../../lists"))
            //{
            //    Directory.CreateDirectory("../../../lists");
            //}

            TodoListsListBox.DataSource = TodoLists;
            TodoListsListBox.SelectedIndex = -1;
            NoTodoListSelected();
        }

        private void NoTodoListSelected()
        {
            CurrentListLabel.Text = "Choose or create new Todo list";
            DeleteListBtn.Enabled = false;
            RenameBtn.Enabled = false;
            RenameListBtn.Enabled = false;
            RemoveBtn.Enabled = false;
            AddBtn.Enabled = false;
        }

        private void AddTodoList_Click(object sender, EventArgs e)
        {
            CreateNewListForm createNewListForm = new CreateNewListForm(TodoLists);
            createNewListForm.ShowDialog();

            if (createNewListForm.DialogResult == DialogResult.OK)
            {
                TodoLists.Add(createNewListForm.name);

                TodoListsListBox.DataSource = null;
                TodoListsListBox.DataSource = TodoLists;
                // TODO: add saving to text file

                TodoListsListBox.SelectedIndex = TodoLists.Count() - 1;
            }
        }

        private void TodoListsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            TodoItems.Clear();
            IsComplete.Clear();

            if (TodoListsListBox.SelectedIndex == -1)
            {
                NoTodoListSelected();
                return;
            }

            CurrentListLabel.Text = TodoListsListBox?.SelectedItem?.ToString() ?? "Select todo list";

            DeleteListBtn.Enabled = true;
            RenameBtn.Enabled = true;
            RenameListBtn.Enabled = true;
            RemoveBtn.Enabled = true;
            AddBtn.Enabled = true;

            // show todo items on UI

            for (int i = 0; i < TodoItems.Count(); i++)
            {
                checkedListBoxTodoItems.Items.Add(TodoItems[i]);
                if (IsComplete[i])
                {
                    checkedListBoxTodoItems.SetItemChecked(i, true);
                }
                else
                {
                    checkedListBoxTodoItems.SetItemChecked(i, false);
                }
            }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            // open AddTodoItemForm
            // add logic for saving new todo item 
        }
    }
}