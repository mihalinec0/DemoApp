using System;
using System.Collections.Generic;
using System.Text;

namespace SMS_Sender.DATA.Models
{
    public class SentMessages
    {
        public int Id { get; set; }
        public DateTime DateAndTime { get; set; }
        public string Recipient { get; set; }
        public string MobileNumber { get; set; }
        public string FileName { get; set; }
    }
}
