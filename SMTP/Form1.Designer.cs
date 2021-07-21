namespace SMTP
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.subjectTextBox = new System.Windows.Forms.TextBox();
            this.messageRichTextBox = new System.Windows.Forms.RichTextBox();
            this.exitButton = new System.Windows.Forms.Button();
            this.sendButton = new System.Windows.Forms.Button();
            this.hostTextBox = new System.Windows.Forms.TextBox();
            this.userTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.attachmentTextBox = new System.Windows.Forms.TextBox();
            this.fromTextBox = new System.Windows.Forms.TextBox();
            this.toTextBox = new System.Windows.Forms.TextBox();
            this.copyTextBox = new System.Windows.Forms.TextBox();
            this.resetButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // subjectTextBox
            // 
            this.subjectTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.subjectTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.subjectTextBox.Location = new System.Drawing.Point(15, 116);
            this.subjectTextBox.Name = "subjectTextBox";
            this.subjectTextBox.Size = new System.Drawing.Size(702, 20);
            this.subjectTextBox.TabIndex = 0;
            this.subjectTextBox.Text = "Subject";
            this.subjectTextBox.Click += new System.EventHandler(this.subjectTextBox_Click);
            // 
            // messageRichTextBox
            // 
            this.messageRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageRichTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.messageRichTextBox.Location = new System.Drawing.Point(15, 142);
            this.messageRichTextBox.Name = "messageRichTextBox";
            this.messageRichTextBox.Size = new System.Drawing.Size(702, 209);
            this.messageRichTextBox.TabIndex = 2;
            this.messageRichTextBox.Text = "Message";
            this.messageRichTextBox.Click += new System.EventHandler(this.messageRichTextBox_Click);
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.exitButton.Location = new System.Drawing.Point(15, 386);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // sendButton
            // 
            this.sendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sendButton.Enabled = false;
            this.sendButton.Location = new System.Drawing.Point(642, 386);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 23);
            this.sendButton.TabIndex = 4;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // hostTextBox
            // 
            this.hostTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hostTextBox.ForeColor = System.Drawing.Color.Red;
            this.hostTextBox.Location = new System.Drawing.Point(15, 12);
            this.hostTextBox.Name = "hostTextBox";
            this.hostTextBox.Size = new System.Drawing.Size(171, 20);
            this.hostTextBox.TabIndex = 6;
            this.hostTextBox.Text = "Host";
            this.hostTextBox.Click += new System.EventHandler(this.hostTextBox_Click);
            this.hostTextBox.TextChanged += new System.EventHandler(this.hostTextBox_TextChanged);
            // 
            // userTextBox
            // 
            this.userTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.userTextBox.Location = new System.Drawing.Point(369, 12);
            this.userTextBox.Name = "userTextBox";
            this.userTextBox.Size = new System.Drawing.Size(171, 20);
            this.userTextBox.TabIndex = 8;
            this.userTextBox.Text = "User";
            this.userTextBox.Click += new System.EventHandler(this.userTextBox_Click);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.passwordTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.passwordTextBox.Location = new System.Drawing.Point(546, 12);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(171, 20);
            this.passwordTextBox.TabIndex = 10;
            this.passwordTextBox.Text = "Password";
            this.passwordTextBox.Click += new System.EventHandler(this.passwordTextBox_Click);
            // 
            // portTextBox
            // 
            this.portTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.portTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.portTextBox.Location = new System.Drawing.Point(192, 12);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(171, 20);
            this.portTextBox.TabIndex = 12;
            this.portTextBox.Text = "Port (default 25)";
            this.portTextBox.Click += new System.EventHandler(this.portTextBox_Click);
            this.portTextBox.TextChanged += new System.EventHandler(this.portTextBox_TextChanged);
            // 
            // attachmentTextBox
            // 
            this.attachmentTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.attachmentTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.attachmentTextBox.Location = new System.Drawing.Point(15, 357);
            this.attachmentTextBox.Name = "attachmentTextBox";
            this.attachmentTextBox.Size = new System.Drawing.Size(702, 20);
            this.attachmentTextBox.TabIndex = 13;
            this.attachmentTextBox.Text = "Attachment | Attachment";
            this.attachmentTextBox.Click += new System.EventHandler(this.attachmentTextBox_Click);
            // 
            // fromTextBox
            // 
            this.fromTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.fromTextBox.Location = new System.Drawing.Point(15, 38);
            this.fromTextBox.Name = "fromTextBox";
            this.fromTextBox.Size = new System.Drawing.Size(702, 20);
            this.fromTextBox.TabIndex = 14;
            this.fromTextBox.Text = "From";
            this.fromTextBox.Click += new System.EventHandler(this.fromTextBox_Click);
            // 
            // toTextBox
            // 
            this.toTextBox.ForeColor = System.Drawing.Color.Red;
            this.toTextBox.Location = new System.Drawing.Point(15, 64);
            this.toTextBox.Name = "toTextBox";
            this.toTextBox.Size = new System.Drawing.Size(702, 20);
            this.toTextBox.TabIndex = 15;
            this.toTextBox.Text = "To , To or List file";
            this.toTextBox.Click += new System.EventHandler(this.toTextBox_Click);
            this.toTextBox.TextChanged += new System.EventHandler(this.toTextBox_TextChanged);
            // 
            // copyTextBox
            // 
            this.copyTextBox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.copyTextBox.Location = new System.Drawing.Point(15, 90);
            this.copyTextBox.Name = "copyTextBox";
            this.copyTextBox.Size = new System.Drawing.Size(702, 20);
            this.copyTextBox.TabIndex = 16;
            this.copyTextBox.Text = "Copy , Copy or List file";
            this.copyTextBox.Click += new System.EventHandler(this.copyTextBox_Click);
            // 
            // resetButton
            // 
            this.resetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.resetButton.Location = new System.Drawing.Point(96, 386);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 17;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(177, 386);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(459, 23);
            this.progressBar.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 421);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.copyTextBox);
            this.Controls.Add(this.toTextBox);
            this.Controls.Add(this.fromTextBox);
            this.Controls.Add(this.attachmentTextBox);
            this.Controls.Add(this.portTextBox);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.userTextBox);
            this.Controls.Add(this.hostTextBox);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.messageRichTextBox);
            this.Controls.Add(this.subjectTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox subjectTextBox;
        private System.Windows.Forms.RichTextBox messageRichTextBox;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox hostTextBox;
        private System.Windows.Forms.TextBox userTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.TextBox attachmentTextBox;
        private System.Windows.Forms.TextBox fromTextBox;
        private System.Windows.Forms.TextBox toTextBox;
        private System.Windows.Forms.TextBox copyTextBox;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

