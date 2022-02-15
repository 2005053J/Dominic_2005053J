using Dominic_2005053J.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominic_2005053J.Server.Configurations.Entities
{
    public class SeveritySeedConfiguration : IEntityTypeConfiguration<Severity>
    {
        public void Configure(EntityTypeBuilder<Severity> builder)
        {
            builder.HasData(
                new Severity
                {
                    Id = 1,
                    Name = "Mild",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "System"
                },
                new Severity
                {
                    Id = 2,
                    Name = "Moderate",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "System"
                },
                new Severity
                {
                    Id = 3,
                    Name = "Severe",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "System"
                }
                );
        }
    }
}