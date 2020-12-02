using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ticketing_Client.Model.Configuration
{
    public class TicketConfig : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            
            //lavoro con le fluent api per definire il mio modello
            builder.HasKey(t => t.Id); //Non necessario, abbiamo rispettato le convenzioni
            builder.Property(t => t.Title)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(t => t.Description)
                .HasMaxLength(500);
            builder.Property(t => t.Category)
                .IsRequired();
            builder.Property(t => t.Requestor)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(t => t.RowVersion)
                    .IsRowVersion();
            builder
                .HasMany(t => t.Notes)
                .WithOne(n => n.Ticket)
                .HasForeignKey(n => n.TicketId)
                .HasConstraintName("FK_TicketNotes")
                .OnDelete(DeleteBehavior.Cascade);  //cosa succede se voglio cancellare un ticket collegato ad una nota 
                                                    //CASCADE: cancello ticket e nota.
        }
    }
}
