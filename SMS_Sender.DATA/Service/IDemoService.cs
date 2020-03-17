using SMS_Sender.DATA.Models;
using SMS_Sender.DATA.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Sender.DATA.Service
{
  public  interface IDemoService
    {
        Task<IEnumerable<Recipients>> GetRecipients();
        Task<bool> SaveRecipient(NewRecipientModel recipient);
        Task<bool> SendSms(List<NewRecipientModel> recipients, string sms);
    }
}
