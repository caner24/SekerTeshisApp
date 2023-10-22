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
    public class ExerciesesConfigure : IEntityTypeConfiguration<Exercises>
    {
        public void Configure(EntityTypeBuilder<Exercises> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
