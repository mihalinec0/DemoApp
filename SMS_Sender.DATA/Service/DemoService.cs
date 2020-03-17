using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using SMS_Sender.DATA.Data;
using SMS_Sender.DATA.Models;
using SMS_Sender.DATA.ViewModels;
using System.IO;
using Microsoft.Extensions.Logging;

namespace SMS_Sender.DATA.Service
{
    public class DemoService : IDemoService
    {
        private readonly DemoDbContext _context;
        private readonly IHostingEnvironment _env;
        private readonly ILogger<DemoService> _logger;

        public DemoService(DemoDbContext context, IHostingEnvironment env,ILogger<DemoService> logger)
        {
            _context = context;
            _env = env;
            _logger = logger;
        }


        public async Task<IEnumerable<Recipients>> GetRecipients()
        {
            try
            {
                return await _context.Recipients.AsNoTracking().ToListAsync();

               
            }
            catch (Exception e)
            {

                var error = e.Message;
                _logger.LogError($"Greška kod dohvata podataka primatelja: {error}");

                return new List<Recipients>();
            }



        }

        public async Task<bool> SaveRecipient(NewRecipientModel recipient)
        {

            try
            {
                var trimMobileNumber = recipient.MobileNumber.Replace(" ", "");

                _context.Recipients.Add(new Recipients {

                    NameAndSurname = recipient.NameAndSurname,
                    MobileNumber = trimMobileNumber

                });

                await _context.SaveChangesAsync();

                _logger.LogInformation($"Uspješno spremljen primatelj {recipient.NameAndSurname} s brojem mobitela {trimMobileNumber}!");

                return true;

               
               
            }
            catch (Exception e)
            {

                var error = e.Message;
                _logger.LogError($"Greška kod spremanja primatelja: {error}");

                return false;
            }




        }

        public async Task<bool> SendSms(List<NewRecipientModel> recipients, string sms)
        {
            try
            {
                var filepath = Path.Combine(_env.ContentRootPath, "sms");

                if (!Directory.Exists(filepath))
                {

                    Directory.CreateDirectory(filepath);
                }


                foreach (var rec in recipients)
                {

                    var txtFile = Path.Combine(filepath, $"demo_{rec.MobileNumber}.txt");

                    using (FileStream fs = new FileStream(Path.Combine(filepath, txtFile), FileMode.Create))
                    {


                        fs.Dispose();

                        using (StreamWriter sw = new StreamWriter(txtFile))
                        {

                            sw.WriteLine(sms);
                        }
                    }

                    _logger.LogInformation($"Uspješno slanje poruke korisniku:{rec.NameAndSurname} na broj: {rec.MobileNumber}");

                    _context.SentMessages.Add(new SentMessages
                    {

                        DateAndTime = DateTime.Now,
                        FileName = Path.GetFileName(txtFile),
                        MobileNumber = rec.MobileNumber,
                        Recipient = rec.NameAndSurname

                    });


                    await _context.SaveChangesAsync();

                    _logger.LogInformation($"Podaci poslane poruke korisniku:{rec.NameAndSurname}" +
                        $" na broj: {rec.MobileNumber}" +
                        $"su uspješno spremljene u bazu podataka.");
                }

                return true;
            }
            catch (Exception e)
            {

                var error = e.Message;
                _logger.LogError($"Greška slanja ili spremanja SMS poruka: {error}");

                return false;
            }



        }
    }
}
