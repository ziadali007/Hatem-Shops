using Apple1_Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Data.Configurations
{
    public class DailySalesConfigurations : IEntityTypeConfiguration<DailySales>
    {
        public void Configure(EntityTypeBuilder<DailySales> builder)
        {
            builder.Property(DS => DS.Price).HasColumnType("decimal(18,2)");
            builder.Property(DS => DS.Total).HasColumnType("decimal(18,2)");
        }
    }
}
