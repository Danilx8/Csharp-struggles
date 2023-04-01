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
            this.FirstFileChoiceButton = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.SecondFileChoiceButton = new System.Windows.Forms.Button();
            this.SyncButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FirstFileChoiceButton
            // 
            this.FirstFileChoiceButton.Location = new System.Drawing.Point(674, 45);
            this.FirstFileChoiceButton.Name = "FirstFileChoiceButton";
            this.FirstFileChoiceButton.Size = new System.Drawing.Size(84, 24);
            this.FirstFileChoiceButton.TabIndex = 0;
            this.FirstFileChoiceButton.Text = "Обзор...";
            this.FirstFileChoiceButton.UseVisualStyleBackColor = true;
            this.FirstFileChoiceButton.Click += new System.EventHandler(this.FirstFileChoiceButton_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(31, 44);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox1.Size = new System.Drawing.Size(612, 25);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "Выберите первый файл...";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(31, 94);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(612, 25);
            this.richTextBox2.TabIndex = 6;
            this.richTextBox2.Text = "Выберите второй файл...";
            this.richTextBox2.TextChanged += new System.EventHandler(this.richTextBox2_TextChanged);
            // 
            // SecondFileChoiceButton
            // 
            this.SecondFileChoiceButton.Location = new System.Drawing.Point(674, 95);
            this.SecondFileChoiceButton.Name = "SecondFileChoiceButton";
            this.SecondFileChoiceButton.Size = new System.Drawing.Size(84, 24);
            this.SecondFileChoiceButton.TabIndex = 5;
            this.SecondFileChoiceButton.Text = "Обзор...";
            this.SecondFileChoiceButton.UseVisualStyleBackColor = true;
            this.SecondFileChoiceButton.Click += new System.EventHandler(this.SecondFileChoiceButton_Click);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 513);
            this.Controls.Add(this.SyncButton);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.SecondFileChoiceButton);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.FirstFileChoiceButton);
            this.Name = "Form1";
            this.Text = "Синхронизатор файлов";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button FirstFileChoiceButton;
        private RichTextBox richTextBox1;
        private RichTextBox richTextBox2;
        private Button SecondFileChoiceButton;
        private Button SyncButton;
    }
}