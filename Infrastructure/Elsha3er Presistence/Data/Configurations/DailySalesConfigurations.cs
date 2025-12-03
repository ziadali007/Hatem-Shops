using Elsha3er_Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elsha3er_Presistence.Data.Configurations
{
    public class DailySalesConfigurations : IEntityTypeConfiguration<DailySales>
    {
        public void Configure(EntityTypeBuilder<DailySales> builder)
        {
            builder.Property(DS => DS.TotalAmount).HasColumnType("decimal(18,2)");
            builder.Property(DS => DS.Price).HasColumnType("decimal(18,2)");
        }
    }
}
