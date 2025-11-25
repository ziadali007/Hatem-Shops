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
    public class DailySalesArchiveConfigurations : IEntityTypeConfiguration<DailySalesArchive>
    {
        public void Configure(EntityTypeBuilder<DailySalesArchive> builder)
        {
            builder.Property(DSA => DSA.Price).HasColumnType("decimal(18,2)");
            builder.Property(DSA => DSA.Total).HasColumnType("decimal(18,2)");
        }
    }
}
