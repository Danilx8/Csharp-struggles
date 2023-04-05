namespace Eigth_Laba
{
    partial class Form1
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
            this.FirstDirectoryChoiceButton = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.SecondDirectoryChoiceButton = new System.Windows.Forms.Button();
            this.SyncButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // FirstDirectoryChoiceButton
            // 
            this.FirstDirectoryChoiceButton.Location = new System.Drawing.Point(675, 68);
            this.FirstDirectoryChoiceButton.Name = "FirstDirectoryChoiceButton";
            this.FirstDirectoryChoiceButton.Size = new System.Drawing.Size(84, 24);
            this.FirstDirectoryChoiceButton.TabIndex = 0;
            this.FirstDirectoryChoiceButton.Text = "Обзор...";
            this.FirstDirectoryChoiceButton.UseVisualStyleBackColor = true;
            this.FirstDirectoryChoiceButton.Click += new System.EventHandler(this.FirstDirectoryChoiceButton_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(32, 67);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox1.Size = new System.Drawing.Size(612, 25);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "Выберите главную директорию...";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(32, 117);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(612, 25);
            this.richTextBox2.TabIndex = 6;
            this.richTextBox2.Text = "Выберите побочную директорию...";
            this.richTextBox2.TextChanged += new System.EventHandler(this.richTextBox2_TextChanged);
            // 
            // SecondDirectoryChoiceButton
            // 
            this.SecondDirectoryChoiceButton.Location = new System.Drawing.Point(675, 118);
            this.SecondDirectoryChoiceButton.Name = "SecondDirectoryChoiceButton";
            this.SecondDirectoryChoiceButton.Size = new System.Drawing.Size(84, 24);
            this.SecondDirectoryChoiceButton.TabIndex = 5;
            this.SecondDirectoryChoiceButton.Text = "Обзор...";
            this.SecondDirectoryChoiceButton.UseVisualStyleBackColor = true;
            this.SecondDirectoryChoiceButton.Click += new System.EventHandler(this.SecondDirectoryChoiceButton_Click);
            // 
            // SyncButton
            // 
            this.SyncButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SyncButton.Location = new System.Drawing.Point(260, 246);
            this.SyncButton.Name = "SyncButton";
            this.SyncButton.Size = new System.Drawing.Size(241, 140);
            this.SyncButton.TabIndex = 7;
            this.SyncButton.Text = "Синхронизировать!";
            this.SyncButton.UseVisualStyleBackColor = true;
            this.SyncButton.Click += new System.EventHandler(this.SyncButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(774, 128);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выберите директории, которые вы хотите синхронизировать";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 513);
            this.Controls.Add(this.SyncButton);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.SecondDirectoryChoiceButton);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.FirstDirectoryChoiceButton);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Синхронизатор файлов";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button FirstDirectoryChoiceButton;
        private RichTextBox richTextBox1;
        private RichTextBox richTextBox2;
        private Button SecondDirectoryChoiceButton;
        private Button SyncButton;
        private GroupBox groupBox1;
    }
}