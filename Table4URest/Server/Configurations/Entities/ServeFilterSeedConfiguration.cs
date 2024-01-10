using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Table4URest.Shared.Domain;

namespace Table4URest.Server.Configurations.Entities
{
    public class ServeFilterSeedConfiguration : IEntityTypeConfiguration<ServeFilter>
    {
        public void Configure(EntityTypeBuilder<ServeFilter> builder)
        {
            builder.HasData(
                new ServeFilter
                {
                    Id = 1,
                    ServeRange = "Breakfast",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System",
                },
                new ServeFilter
                {
                    Id = 2,
                    ServeRange = "Lunch",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System",
                },
                new ServeFilter
                {
                    Id = 3,
                    ServeRange = "Dinner",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System",
                }
                );
        }
    }
}
