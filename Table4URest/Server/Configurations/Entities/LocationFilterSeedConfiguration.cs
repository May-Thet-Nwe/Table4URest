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
    public class LocationFilterSeedConfiguration : IEntityTypeConfiguration<LocationFilter>
    {
        public void Configure(EntityTypeBuilder<LocationFilter> builder)
        {
            builder.HasData(
                new LocationFilter
                {
                    Id = 1,
                    PostalCode = 520824,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System",
                },
                new LocationFilter
                {
                    Id = 2,
                    PostalCode = 460218,
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System",
                }
                );
        }
    }
}

