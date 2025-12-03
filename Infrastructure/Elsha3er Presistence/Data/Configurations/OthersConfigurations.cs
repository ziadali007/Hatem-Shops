using Models = Elsha3er_Domain.Models.Others;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elsha3er_Presistence.Data.Configurations
{
    public class Others : IEntityTypeConfiguration<Models>
    {
        public void Configure(EntityTypeBuilder<Models> builder)
        {
            builder.Property(O => O.Price).HasColumnType("decimal(18,2)");
        }
    }
}
