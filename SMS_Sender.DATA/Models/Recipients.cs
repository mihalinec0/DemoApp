using System;
using System.Collections.Generic;
using System.Text;

namespace SMS_Sender.DATA.Models
{
    public class Recipients
    {
        public int Id { get; set; }
        public string NameAndSurname { get; set; }
        public string MobileNumber { get; set; }
    }
}
