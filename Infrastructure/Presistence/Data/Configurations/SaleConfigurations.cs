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
    public class SaleConfigurations : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
           builder.HasKey(S => S.Id);
           builder.Property(S=>S.Price).HasColumnType("decimal(18,2)");
           builder.Property(S => S.Total).HasColumnType("decimal(18,2)");
        }
    }
}
