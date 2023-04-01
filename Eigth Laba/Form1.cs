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

        private void FirstFileChoiceButton_Click(object sender, EventArgs e)
        {
            using var ChosenFile = new OpenFileDialog();
            DialogResult Result = ChosenFile.ShowDialog();

            if (Result == DialogResult.OK &&
                !string.IsNullOrWhiteSpace(ChosenFile.FileName))
            {
                richTextBox1.Text = ChosenFile.FileName;
            }
            else if (ChosenFile.FileName != null)
            {
                MessageBox.Show("Файл не выбран", "Ошибка!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SecondFileChoiceButton_Click(object sender, EventArgs e)
        {
            using var ChosenFile = new OpenFileDialog();
            DialogResult Result = ChosenFile.ShowDialog();

            if (Result == DialogResult.OK &&
                !string.IsNullOrWhiteSpace(ChosenFile.FileName))
            {
                richTextBox2.Text = ChosenFile.FileName;
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