using System;
using System.Collections.Generic;
using System.Text;

namespace SMS_Sender.DATA.ViewModels
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
