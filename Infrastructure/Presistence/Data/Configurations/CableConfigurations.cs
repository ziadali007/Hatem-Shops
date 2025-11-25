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
    public class CableConfigurations : IEntityTypeConfiguration<Cable>
    {
        public void Configure(EntityTypeBuilder<Cable> builder)
        {
            builder.Property(C => C.Price).HasColumnType("decimal(18,2)");
        }
    }
}
