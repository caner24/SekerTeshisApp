﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SekerTeshis.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SekerTeshisApp.Data.Concrete.Configure
{
    internal class UserConfigure : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasOne(x => x.Diabetess).WithOne(x => x.User).HasForeignKey<Diabetes>(x => x.Id);
        }
    }
}