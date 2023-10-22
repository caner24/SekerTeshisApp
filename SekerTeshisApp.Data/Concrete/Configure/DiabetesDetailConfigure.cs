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
    public class DiabetesDetailConfigure : IEntityTypeConfiguration<DiabetesDetail>
    {
        public void Configure(EntityTypeBuilder<DiabetesDetail> builder)
        {
            builder.HasOne(x => x.Exercises).WithOne(x => x.DiabetesDetail).HasForeignKey<Exercises>(x => x.Id);
            builder.HasOne(x => x.Food).WithOne(x => x.DiabetesDetail).HasForeignKey<Food>(x => x.Id);
        }
    }
}
