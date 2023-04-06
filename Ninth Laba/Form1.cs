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
            string[] ModifiedFiles;
            string[] DeletedFiles;
            string[] AddedFiles;

            XmlDocument XmlDoc = new XmlDocument();
            XmlDoc.Load("Sessions.xml");

            XmlNodeList ActionTypeNodes = XmlDoc.GetElementsByTagName("Action_Type");
            foreach (XmlNode ActionTypeNode in ActionTypeNodes)
            {
                XmlNodeList FileNameNodes = ActionTypeNode.SelectNodes("following-sibling::File_name[1]/*[1]/string");
                switch (ActionTypeNode.SelectSingleNode("string").InnerText)
                {
                    case "Add":
                        Message += "����������� �����: ";
                        break;
                    case "Delete":
                        Message += "�������� �����: ";
                        break;
                    case "Edit":
                        Message += "��������� �����: ";
                        break;
                }
                foreach (XmlNode FileNameNode in FileNameNodes)
                {
                    Message += FileNameNode.InnerText + ' ';
                }
                Message += '\n';
            }


           
            //if (!Result.ContainsKey("Nothing"))
            //{
            //    string[] ModifiedFiles;
            //    string[] DeletedFiles;
            //    string[] AddedFiles;
            //    if (Result.ContainsKey("Edit"))
            //    {
            //        ModifiedFiles = Result["Edit"];
            //        Message += "\nModified files: ";
            //        foreach (string file in ModifiedFiles)
            //        {
            //            Message += Path.GetFileName(file) + ", ";
            //        }
            //    }
            //    if (Result.ContainsKey("Delete"))
            //    {

            //        DeletedFiles = Result["Delete"];
            //        Message += "\nDeleted files: ";
            //        foreach (string file in DeletedFiles)
            //        {
            //            Message += Path.GetFileName(file) + ", ";
            //        }
            //    }
            //    if (Result.ContainsKey("Add"))
            //    {
            //        AddedFiles = Result["Add"];
            //        Message += "\nAdded files: ";
            //        foreach (string file in AddedFiles)
            //        {
            //            Message += Path.GetFileName(file) + ", ";
            //        }
            //    }
            //}
            //else
            //{
            //    Message += Result["Nothing"][0];
            //}
            MessageBox.Show(Message, "��������� �������������", MessageBoxButtons.OK);
        }

        void IView.Connected(bool Success)
        {
            if (Success)
            {
                MessageBox.Show("������������� ������ �������!", "��������� �������������",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("������������� �� ���������", "��������� �������������",
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
                MessageBox.Show("���� �� ������", "������!",
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
                MessageBox.Show("���� �� ������", "������!",
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
                MessageBox.Show(ex.Message, "������!", MessageBoxButtons.OK,
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