namespace Eigth_Laba
{
    public partial class Form1 : Form, IView
    {
        public event EventHandler<EventArgs> Synchronize;
        public Form1()
        {
            InitializeComponent();
        }

        string IView.GetMainPath()
        {
            return richTextBox1.Text;
        }

        string IView.GetSecondaryPath()
        {
            return richTextBox2.Text;
        }
        
        void IView.ShowResult(Dictionary<int, string[]> Result)
        {
            string Message = "";
            if (!Result.ContainsKey((int)StateCodes.UP_TO_DATE))
            {
                string[] ModifiedFiles;
                string[] DeletedFiles;
                string[] AddedFiles;
                if (Result.ContainsKey((int)StateCodes.UPDATED_FILES))
                {
                    ModifiedFiles = Result[(int)StateCodes.UPDATED_FILES];
                    Message += "\nModified files: ";
                    foreach (string file in ModifiedFiles)
                    {
                        Message += Path.GetFileName(file) + ", ";
                    }
                }
                if (Result.ContainsKey((int)StateCodes.DELETED_FILES))
                {

                    DeletedFiles = Result[(int)StateCodes.DELETED_FILES];
                    Message += "\nDeleted files: ";
                    foreach (string file in DeletedFiles)
                    {
                        Message += Path.GetFileName(file) + ", ";
                    }
                }
                if (Result.ContainsKey((int)StateCodes.NEW_FILES))
                {
                    AddedFiles = Result[(int)StateCodes.NEW_FILES];
                    Message += "\nAdded files: ";
                    foreach (string file in AddedFiles)
                    {
                        Message += Path.GetFileName(file) + ", ";
                    }
                }
            }
            else
            {
                Message += Result[0][0];
            }
            MessageBox.Show(Message, "Результат синхронизации", MessageBoxButtons.OK);
        }

        void IView.Connected(bool Success)
        {
            if (Success)
            {
                MessageBox.Show("Синхронизация прошла успешно!", "Результат синхронизации",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Синхронизация не выполнена", "Результат синхронизации",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FirstDirectoryChoiceButton_Click(object sender, EventArgs e)
        {
            using var ChosenFile = new FolderBrowserDialog();
            DialogResult Result = ChosenFile.ShowDialog();

            if (Result == DialogResult.OK &&
                !string.IsNullOrWhiteSpace(ChosenFile.SelectedPath))
            {
                richTextBox1.Text = ChosenFile.SelectedPath;
            }
            else
            {
                MessageBox.Show("Файл не выбран", "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SecondDirectoryChoiceButton_Click(object sender, EventArgs e)
        {
            using var ChosenFile = new FolderBrowserDialog();
            DialogResult Result = ChosenFile.ShowDialog();

            if (Result == DialogResult.OK &&
                !string.IsNullOrWhiteSpace(ChosenFile.SelectedPath))
            {
                richTextBox2.Text = ChosenFile.SelectedPath;
            }
            else
            {
                MessageBox.Show("Файл не выбран", "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SyncButton_Click(object sender, EventArgs e)
        {
            try
            {
                Synchronize(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}