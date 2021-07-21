using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMTP
{
    class MailingData
    {
        private String host = "";
        private String port = "";
        private String user = "";
        private String password = "";
        private String to = "";
        private String from = "";
        private String copy = "";
        private String subject = "";
        private String message = "";
        private String attachment = "";

        public String Host
        {
            get
            {
                return host;
            }

            set
            {
                host = value;
            }
        }

        public String Port
        {
            get
            {
                return port;
            }

            set
            {
                port = value;
            }
        }

        public String User
        {
            get
            {
                return user;
            }

            set
            {
                user = value;
            }
        }

        public String Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public String To
        {
            get
            {
                return to;
            }

            set
            {
                to = value;
            }
        }

        public String From
        {
            get
            {
                return from;
            }

            set
            {
                from = value;
            }
        }

        public String Copy
        {
            get
            {
                return copy;
            }

            set
            {
                copy = value;
            }
        }

        public String Subject
        {
            get
            {
                return subject;
            }

            set
            {
                subject = value;
            }
        }

        public String Message
        {
            get
            {
                return message;
            }

            set
            {
                message = value;
            }
        }

        public String Attachment
        {
            get
            {
                return attachment;
            }

            set
            {
                attachment = value;
            }
        }
    }
}
