namespace TodoList
{
    public partial class TodoListForm : Form
    {
        public TodoListForm()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(todoTextBox.Text))
                return;

            checkedListBoxTodos.Items.Add(todoTextBox.Text);
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            todoTextBox.ResetText();
        }

        private void ClearCheckedBtn_Click(object sender, EventArgs e)
        {
            for (int i = checkedListBoxTodos.Items.Count - 1; i >= 0; i--)
            {
                if (checkedListBoxTodos.GetItemChecked(i))
                {
                    checkedListBoxTodos.Items.RemoveAt(i);
                }
            }
        }

        private void ClearAllBtn_Click(object sender, EventArgs e)
        {
            checkedListBoxTodos.Items.Clear();
            todoTextBox.ResetText();
        }
    }
}