using Microsoft.EntityFrameworkCore;
using SMS_Sender.DATA.Models;
using System;

namespace SMS_Sender.DATA.Data
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options)
        {

        }


        public  DbSet<Recipients> Recipients { get; set;}
        public DbSet<SentMessages> SentMessages { get; set; }
    }
}
