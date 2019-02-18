using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingStore.Domain.Concrete
{
    public class EmailSettings
    {
        public string MailToAddress = "ali.ben.belgassem@gmail.com";
        public string MailFromAddress = "ali.ben.belgassem@gmail.com";
        public bool UseSsl = true;
        public string Username = "ali.ben.belgassem@gmail.com";
        public string Password = "LILOWAAMGMAIL"; // Create your own google app password, In the video I have shown you how to create app password.
        public string ServerName = "smtp.gmail.com";
        public int ServerPort = 587;
    }
}
