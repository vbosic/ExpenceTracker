using ExpenceTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenceTracker.Configurations
{
    public class OutcomeConfiguration : IEntityTypeConfiguration<Outcome>
    {
        public void Configure(EntityTypeBuilder<Outcome> builder)
        {
            builder.HasKey(p => new {p.Id});

            builder.HasOne(p => p.User)
                .WithMany(p => p.Outcomes)
                .HasForeignKey(p => p.UserId);

            builder.HasOne(p => p.Target)
                .WithMany(p => p.Outcomes)
                .HasForeignKey(p => p.TargetId);
        }
    }
}
