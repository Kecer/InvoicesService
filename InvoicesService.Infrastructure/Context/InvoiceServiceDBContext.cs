using System;
using System.Reflection;
using InvoicesService.Core.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace InvoicesService.Infrastructure.Context
{
    public class InvoiceServiceDBContext:DbContext
    {
        public InvoiceServiceDBContext()
        {
        }

        public InvoiceServiceDBContext(DbContextOptions<InvoiceServiceDBContext> options)
            : base(options)
        {
        }
        public DbSet<Invoice> Invoices { get;  set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=..\\InvoicesService.APi\\InvoiceServiceDB.db", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiguring(optionsBuilder);
        }
    }
}