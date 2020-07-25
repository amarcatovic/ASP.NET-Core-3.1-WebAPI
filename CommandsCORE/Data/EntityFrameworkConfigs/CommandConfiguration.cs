using CommandsCORE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandsCORE.Data.EntityFrameworkConfigs
{
    public class CommandConfiguration : IEntityTypeConfiguration<Command>
    {
        public void Configure(EntityTypeBuilder<Command> builder)
        {
            builder.Property(c => c.HowTo)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.CommandLine)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.Platform)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
