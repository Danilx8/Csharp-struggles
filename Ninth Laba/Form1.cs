using Microsoft.VisualBasic;
using System.Xml;

namespace Ninth_Laba
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
        
        void IView.ShowResult(Syncronizations Result)
        {
            string Message = "";

            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.Load("Sessions.xml");

            XmlNodeList ActionTypeNodes = XmlDoc.GetElementsByTagName("Action_Type");
            if (ActionTypeNodes.Count != 0)
            {
                foreach (XmlNode ActionTypeNode in ActionTypeNodes)
                {
                    XmlNodeList FileNameNodes = ActionTypeNode.SelectNodes("following-sibling::File_name[1]/*[1]/string");
                    switch (ActionTypeNode.SelectSingleNode("string").InnerText)
                    {
                        case "Add":
                            Message += "Добавленные файлы: ";
                            break;
                        case "Delete":
                            Message += "Удалённые файлы: ";
                            break;
                        case "Edit":
                            Message += "Изменённые файлы: ";
                            break;
                    }
                    foreach (XmlNode FileNameNode in FileNameNodes)
                    {
                        Message += FileNameNode.InnerText + ' ';
                    }
                    Message += '\n';
                }
            } 
            else
            {
                Message += "Синхронизация не требуется - всё уже синхронизировано";
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