using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ticketing_Client.Model.Configuration
{
    public class NotesConfiguration : IEntityTypeConfiguration<Notes>
    {
        public void Configure(EntityTypeBuilder<Notes> builder)
        {
            builder.HasKey(n => n.Id);

            builder.Property(n => n.Comments)
                .HasMaxLength(1000)
                .IsRequired();

            builder.Property(n => n.RowVersion)
                .IsRowVersion();
        }
    }
}
