using Apple1_Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Data.Configurations
{
    public class HeadPhonesConfigurations : IEntityTypeConfiguration<HeadPhone>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<HeadPhone> builder)
        {
            builder.Property(H => H.Price).HasColumnType("decimal(18,2)");
        }
    }
}
