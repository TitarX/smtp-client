using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading;

namespace SMTP
{
    public delegate void StopProgressBarDelegate();

    public partial class Form1 : Form
    {
        private Regex emailRegex = null;
        private Thread thread = null;
        private StopProgressBarDelegate stopProgressBar = null;
        private bool isWaitingToExit = false;

        public Form1()
        {
            InitializeComponent();
            this.Text = "SMPT client";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.StartPosition = FormStartPosition.CenterScreen;
            exitButton.Select();
            emailRegex = new Regex("^[_0-9a-zA-Zа-яА-Я][-._0-9a-zA-Zа-яА-Я]{0,29}[_0-9a-zA-Zа-яА-Я]@([0-9a-zA-Zа-яА-Я][-0-9a-zA-Zа-яА-Я]*[0-9a-zA-Zа-яА-Я]\\.)+[a-zA-Zа-яА-Я]{2,8}$");
            stopProgressBar = new StopProgressBarDelegate(StopProgressBar);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            if (thread != null && thread.IsAlive)
            {
                isWaitingToExit = true;
                thread.Abort();
                thread.Join();
            }
            Application.Exit();
        }

        private void hostTextBox_Click(object sender, EventArgs e)
        {
            CheckEmptyField();
            if (hostTextBox.Text.Trim().Equals("Host"))
            {
                hostTextBox.Text = "";
                hostTextBox.ForeColor = SystemColors.WindowText;
            }
        }

        private void portTextBox_Click(object sender, EventArgs e)
        {
            CheckEmptyField();
            if (portTextBox.Text.Trim().Equals("Port (default 25)"))
            {
                portTextBox.Text = "";
                portTextBox.ForeColor = SystemColors.WindowText;
            }
        }

        private void userTextBox_Click(object sender, EventArgs e)
        {
            CheckEmptyField();
            if (userTextBox.Text.Trim().Equals("User"))
            {
                userTextBox.Text = "";
                userTextBox.ForeColor = SystemColors.WindowText;
            }
        }

        private void passwordTextBox_Click(object sender, EventArgs e)
        {
            CheckEmptyField();
            if (passwordTextBox.Text.Trim().Equals("Password"))
            {
                passwordTextBox.Text = "";
                passwordTextBox.PasswordChar = '*';
                passwordTextBox.ForeColor = SystemColors.WindowText;
            }
        }

        private void fromTextBox_Click(object sender, EventArgs e)
        {
            CheckEmptyField();
            if (fromTextBox.Text.Trim().Equals("From"))
            {
                fromTextBox.Text = "";
                fromTextBox.ForeColor = SystemColors.WindowText;
            }
        }

        private void toTextBox_Click(object sender, EventArgs e)
        {
            CheckEmptyField();
            if (toTextBox.Text.Trim().Equals("To , To or List file"))
            {
                toTextBox.Text = "";
                toTextBox.ForeColor = SystemColors.WindowText;
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                toTextBox.Text = openFileDialog.FileName;
            }
        }

        private void copyTextBox_Click(object sender, EventArgs e)
        {
            CheckEmptyField();
            if (copyTextBox.Text.Trim().Equals("Copy , Copy or List file"))
            {
                copyTextBox.Text = "";
                copyTextBox.ForeColor = SystemColors.WindowText;
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                copyTextBox.Text = openFileDialog.FileName;
            }
        }

        private void subjectTextBox_Click(object sender, EventArgs e)
        {
            CheckEmptyField();
            if (subjectTextBox.Text.Trim().Equals("Subject"))
            {
                subjectTextBox.Text = "";
                subjectTextBox.ForeColor = SystemColors.WindowText;
            }
        }

        private void messageRichTextBox_Click(object sender, EventArgs e)
        {
            CheckEmptyField();
            if (messageRichTextBox.Text.Trim().Equals("Message"))
            {
                messageRichTextBox.Text = "";
                messageRichTextBox.ForeColor = SystemColors.WindowText;
            }
        }

        private void attachmentTextBox_Click(object sender, EventArgs e)
        {
            CheckEmptyField();
            if (attachmentTextBox.Text.Trim().Equals("Attachment | Attachment"))
            {
                attachmentTextBox.Text = "";
                attachmentTextBox.ForeColor = SystemColors.WindowText;
            }

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All files|*.*";
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StringBuilder stringBuilder = new StringBuilder();
                if (!attachmentTextBox.Text.Trim().Equals(""))
                {
                    stringBuilder.Append(attachmentTextBox.Text);
                }
                foreach (String fileName in openFileDialog.FileNames)
                {
                    if (stringBuilder.Length != 0)
                    {
                        stringBuilder.Append(" | ");
                    }
                    stringBuilder.Append(fileName);
                }
                attachmentTextBox.Text = stringBuilder.ToString();
            }
        }

        private void CheckEmptyField()
        {
            if (hostTextBox.Text.Trim().Equals(""))
            {
                hostTextBox.ForeColor = Color.Red;
                hostTextBox.Text = "Host";
            }
            if (portTextBox.Text.Trim().Equals(""))
            {
                portTextBox.ForeColor = SystemColors.GrayText;
                portTextBox.Text = "Port (default 25)";
            }
            if (userTextBox.Text.Trim().Equals(""))
            {
                userTextBox.ForeColor = SystemColors.GrayText;
                userTextBox.Text = "User";
            }
            if (passwordTextBox.Text.Trim().Equals(""))
            {
                passwordTextBox.ForeColor = SystemColors.GrayText;
                passwordTextBox.Text = "Password";
                //passwordTextBox.PasswordChar = serverTextBox.PasswordChar;
                passwordTextBox.PasswordChar = '\0';
            }
            if (fromTextBox.Text.Trim().Equals(""))
            {
                fromTextBox.ForeColor = SystemColors.GrayText;
                fromTextBox.Text = "From";
            }
            if (toTextBox.Text.Trim().Equals(""))
            {
                toTextBox.ForeColor = Color.Red;
                toTextBox.Text = "To , To or List file";
            }
            if (copyTextBox.Text.Trim().Equals(""))
            {
                copyTextBox.ForeColor = SystemColors.GrayText;
                copyTextBox.Text = "Copy , Copy or List file";
            }
            if (subjectTextBox.Text.Trim().Equals(""))
            {
                subjectTextBox.ForeColor = SystemColors.GrayText;
                subjectTextBox.Text = "Subject";
            }
            if (messageRichTextBox.Text.Trim().Equals(""))
            {
                messageRichTextBox.ForeColor = SystemColors.GrayText;
                messageRichTextBox.Text = "Message";
            }
            if (attachmentTextBox.Text.Trim().Equals(""))
            {
                attachmentTextBox.ForeColor = SystemColors.GrayText;
                attachmentTextBox.Text = "Attachment | Attachment";
            }
        }

        private void hostTextBox_TextChanged(object sender, EventArgs e)
        {
            ChangeSendButtonStat();
        }

        private void portTextBox_TextChanged(object sender, EventArgs e)
        {
            ChangeSendButtonStat();
        }

        private void toTextBox_TextChanged(object sender, EventArgs e)
        {
            ChangeSendButtonStat();
        }

        private void ChangeSendButtonStat()
        {
            if (hostTextBox.Text.Trim().Equals("") || hostTextBox.Text.Trim().Equals("Host")
                || portTextBox.Text.Trim().Equals("") || portTextBox.Text.Trim().Equals("Port")
                || toTextBox.Text.Trim().Equals("") || toTextBox.Text.Trim().Equals("To , To or List file"))
            {
                sendButton.Enabled = false;
            }
            else
            {
                sendButton.Enabled = true;
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            MailingData mailingData = new MailingData();
            mailingData.Host = hostTextBox.Text.Trim();
            mailingData.Port = portTextBox.Text.Trim();
            mailingData.User = userTextBox.Text.Trim();
            mailingData.Password = passwordTextBox.Text.Trim();
            mailingData.To = toTextBox.Text.Trim();
            mailingData.From = fromTextBox.Text.Trim();
            mailingData.Copy = copyTextBox.Text.Trim();
            mailingData.Subject = subjectTextBox.Text.Trim();
            mailingData.Message = messageRichTextBox.Text.Trim();
            mailingData.Attachment = attachmentTextBox.Text.Trim();

            progressBar.Style = ProgressBarStyle.Marquee;
            thread = new Thread(new ParameterizedThreadStart(Process));
            thread.Start(mailingData);
        }

        private void StopProgressBar()
        {
            progressBar.Style = ProgressBarStyle.Blocks;
        }

        private void Process(Object mailingObject)
        {
            try
            {
                MailingData mailingData = (MailingData)mailingObject;
                String host = mailingData.Host;
                String port = mailingData.Port;
                String user = mailingData.User;
                String password = mailingData.Password;
                String to = mailingData.To;
                String from = mailingData.From;
                String copy = mailingData.Copy;
                String subject = mailingData.Subject;
                String message = mailingData.Message;
                String attachment = mailingData.Attachment;


                bool isSuccessfully = true;
                if (!port.Equals("") && !port.Equals("Port (default 25)") && Regex.IsMatch(port, "[^0-9]"))
                {
                    isSuccessfully = false;
                    MessageBox.Show("\"Port\" field must contain only digits", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (isSuccessfully && !from.Equals("") && !from.Equals("From") && !emailRegex.IsMatch(from))
                {
                    isSuccessfully = false;
                    MessageBox.Show("\"From\" field contain incorrect email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (isSuccessfully && (port.Equals("") || port.Equals("Port (default 25)")))
                {
                    port = "25";
                }
                if (isSuccessfully && (from.Equals("") || from.Equals("From")))
                {
                    from = "email@email.net";
                }

                if (isSuccessfully)
                {
                    SmtpClient smtpClient = new SmtpClient(host, Convert.ToInt32(port));
                    smtpClient.Timeout = 36000000;//10 hours
                    if ((!user.Equals("") && !user.Equals("User")) || (!password.Equals("") && !password.Equals("Password")))
                    {
                        smtpClient.Credentials = new NetworkCredential(user, password);
                    }
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress(from);

                    MailAddressCollection mailAddressCollection = CreateMailAddressCollection(to);
                    if (mailAddressCollection == null)
                    {
                        isSuccessfully = false;
                    }
                    else
                    {
                        foreach (MailAddress mailAddress in mailAddressCollection)
                        {
                            mailMessage.To.Add(mailAddress);
                        }
                    }

                    if (isSuccessfully && !copy.Equals("") && !copy.Equals("Copy , Copy or List file"))
                    {
                        mailAddressCollection = CreateMailAddressCollection(copy);
                        if (mailAddressCollection == null)
                        {
                            isSuccessfully = false;
                        }
                        else
                        {
                            foreach (MailAddress mailAddress in mailAddressCollection)
                            {
                                mailMessage.CC.Add(mailAddress);
                            }
                        }
                    }

                    if (isSuccessfully)
                    {
                        mailMessage.Subject = subject;
                        mailMessage.Body = message;

                        if (!attachment.Equals("") && !attachment.Equals("Attachment | Attachment"))
                        {
                            foreach (String a in attachment.Split('|'))
                            {
                                if (!a.Trim().Equals(""))
                                {
                                    if (File.Exists(a.Trim()))
                                    {
                                        mailMessage.Attachments.Add(new Attachment(a));
                                    }
                                    else
                                    {
                                        MessageBox.Show(String.Format("File \"{0}\" not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error), a.Trim());
                                        break;
                                    }
                                }
                            }
                        }

                        smtpClient.Send(mailMessage);
                        MessageBox.Show("Message sent successfully", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                if (!isWaitingToExit)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                if (!isWaitingToExit)
                {
                    progressBar.Invoke(stopProgressBar);
                }
            }

        }

        private MailAddressCollection CreateMailAddressCollection(String listAddresses)
        {
            MailAddressCollection mailAddressCollection = new MailAddressCollection();
            if (Regex.IsMatch(listAddresses, "\\/|\\\\"))
            {
                if (File.Exists(listAddresses))
                {
                    StreamReader streamReader = null;
                    try
                    {
                        streamReader = File.OpenText(listAddresses);
                        listAddresses = streamReader.ReadToEnd();

                        mailAddressCollection = FillMailAddressCollection(listAddresses, mailAddressCollection);
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        if (streamReader != null)
                        {
                            streamReader.Close();
                        }
                    }
                }
                else
                {
                    mailAddressCollection = null;
                    MessageBox.Show(String.Format("File \"{0}\" not exist", listAddresses), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                mailAddressCollection = FillMailAddressCollection(listAddresses, mailAddressCollection);
            }

            return mailAddressCollection;
        }

        private MailAddressCollection FillMailAddressCollection(String listAddresses, MailAddressCollection mailAddressCollection)
        {
            foreach (String t in listAddresses.Split(new char[] { ',' }))
            {
                if (!t.Trim().Equals(""))
                {
                    if (emailRegex.IsMatch(t.Trim()))
                    {
                        mailAddressCollection.Add(new MailAddress(t.Trim()));
                    }
                    else
                    {
                        mailAddressCollection = null;
                        MessageBox.Show(String.Format("Email \"{0}\" incorrect", t.Trim()), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }
            }

            return mailAddressCollection;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            hostTextBox.ForeColor = Color.Red;
            hostTextBox.Text = "Host";
            portTextBox.ForeColor = SystemColors.GrayText;
            portTextBox.Text = "Port (default 25)";
            userTextBox.ForeColor = SystemColors.GrayText;
            userTextBox.Text = "User";
            passwordTextBox.ForeColor = SystemColors.GrayText;
            passwordTextBox.Text = "Password";
            //passwordTextBox.PasswordChar = serverTextBox.PasswordChar;
            passwordTextBox.PasswordChar = '\0';
            fromTextBox.ForeColor = SystemColors.GrayText;
            fromTextBox.Text = "From";
            toTextBox.ForeColor = Color.Red;
            toTextBox.Text = "To , To or List file";
            copyTextBox.ForeColor = SystemColors.GrayText;
            copyTextBox.Text = "Copy , Copy or List file";
            subjectTextBox.ForeColor = SystemColors.GrayText;
            subjectTextBox.Text = "Subject";
            messageRichTextBox.ForeColor = SystemColors.GrayText;
            messageRichTextBox.Text = "Message";
            attachmentTextBox.ForeColor = SystemColors.GrayText;
            attachmentTextBox.Text = "Attachment | Attachment";

            sendButton.Enabled = false;
        }
    }
}
