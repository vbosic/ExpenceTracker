using ExpenceTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenceTracker.Configurations
{
    public class IncomeConfiguration : IEntityTypeConfiguration<Income>
    {
        public void Configure(EntityTypeBuilder<Income> builder)
        {
            builder.HasKey(a => new {a.Id});

            builder.HasOne(p => p.User)
                .WithMany(p => p.Incomes)
                .HasForeignKey(k => k.UserId);

            builder.HasOne(p => p.Source)
                .WithMany(p => p.Incomes)
                .HasForeignKey(p => p.SourceId);
        }
    }
}
