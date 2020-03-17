using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SMS_Sender.DATA.Models;
using SMS_Sender.DATA.Service;
using SMS_Sender.DATA.ViewModels;

namespace SMS_Sender.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDemoService _service;
        
        public HomeController(IDemoService service)
        {
            _service = service;
         
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AboutApplication()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> GetRecipients()
        {

            return View("_RecipientsList", await _service.GetRecipients());


        }
        [HttpPost]
        public async Task<bool> SaveRecipient(NewRecipientModel recipient)
        {

            try
            {
                var res = await _service.SaveRecipient(recipient);

                if (res)
                    return true;

                return false;
            }
            catch (Exception e)
            {


                return false;
            }
        }

        [HttpPost]
        public async Task<bool> SendSms(List<NewRecipientModel> recipients, string sms)
        {

            try
            {
                var res = await _service.SendSms(recipients,sms);

                if (res)
                    return true;

                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
