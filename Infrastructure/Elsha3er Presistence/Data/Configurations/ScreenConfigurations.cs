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
    public class ScreenConfigurations : IEntityTypeConfiguration<Screen>
    {
        public void Configure(EntityTypeBuilder<Screen> builder)
        {
            builder.Property(S => S.Price).HasColumnType("decimal(18,2)");
        }
    }
}
