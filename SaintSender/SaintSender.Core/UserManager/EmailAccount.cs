﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintSender.Core
{
    public class EmailAccount
    {
        public string IMAPServer { get; set; }
        public int Port { get; set; }
        public string EmailAddress { get; set; }
        public string ApplicationPassword { get; set; }

        public EmailAccount(string IMAPServer, int port, string emailAddress, string applicationPassword)
        {
            this.IMAPServer = IMAPServer;
            Port = port;
            EmailAddress = emailAddress;
            ApplicationPassword = applicationPassword;
        }

        public override string ToString()
        {
            return EmailAddress;
        }
    }
}
