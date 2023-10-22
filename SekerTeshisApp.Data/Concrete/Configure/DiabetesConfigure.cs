using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SekerTeshis.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshisApp.Data.Concrete.Configure
{
    public class DiabetesConfigure : IEntityTypeConfiguration<Diabetes>
    {
        public void Configure(EntityTypeBuilder<Diabetes> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsDiabetUser).HasDefaultValue(false);
        }
    }
}
