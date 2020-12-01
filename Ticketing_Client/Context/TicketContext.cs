using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Ticketing_Client.Model;
using Ticketing_Helpers;

namespace Ticketing_Client.Context
{
    public sealed class TicketContext : DbContext
    {
        DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            string cs = Config.GetConnectionString("TicketDb");
            //configurazione fatta attraverso la classe helper
            //Fattorizzazione del codice
            //string cs = config.GetSection("ConncetionStrings")["TicketDb"]
            optionBuilder.UseSqlServer(cs);//metto la string in un file di configurazione (FILE JASON)
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var tm = modelBuilder.Entity<Ticket>();
            //lavoro con le fluent api per definire il mio modello
            tm .HasKey(t => t.Id); //Non necessario, abbiamo rispettato le convenzioni
            tm.Property(t => t.Title)
                .HasMaxLength(100)
                .IsRequired();
            tm.Property(t => t.Description)
                .HasMaxLength(500);
            tm.Property(t => t.Category)
                .IsRequired();
        }
    }
}
