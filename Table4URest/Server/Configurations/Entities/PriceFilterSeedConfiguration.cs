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
    public class PriceFilterSeedConfiguration : IEntityTypeConfiguration<PriceFilter>
    {
        public void Configure(EntityTypeBuilder<PriceFilter> builder)
        {
            builder.HasData(
                new PriceFilter
                {
                    Id = 1,
                    PriceRange = "Budget",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System",
                },
                new PriceFilter
                {
                    Id = 2,
                    PriceRange = "Normal",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System",
                },
                new PriceFilter
                {
                    Id = 3,
                    PriceRange = "Fancy",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System",
                }
                );
        }
    }
}
