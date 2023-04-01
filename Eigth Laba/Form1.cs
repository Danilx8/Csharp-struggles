namespace Eigth_Laba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}