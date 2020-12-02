using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Ticketing_Client.Model;
using Ticketing_Client.Model.Configuration;
using Ticketing_Helpers;

namespace Ticketing_Client.Context
{
    public sealed class TicketContext : DbContext
    {
       public  DbSet<Ticket> Tickets { get; set; }
       public DbSet<Notes> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            string cs = Config.GetConnectionString("TicketDb");
            //configurazione fatta attraverso la classe helper
            //Fattorizzazione del codice
            //string cs = config.GetSection("ConncetionStrings")["TicketDb"]
            optionBuilder.UseLazyLoadingProxies();
            optionBuilder.UseSqlServer(cs);//metto la string in un file di configurazione (FILE JASON)
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Ticket>(new TicketConfig());
            modelBuilder.ApplyConfiguration<Notes>(new NotesConfiguration());
        }
    }
}
