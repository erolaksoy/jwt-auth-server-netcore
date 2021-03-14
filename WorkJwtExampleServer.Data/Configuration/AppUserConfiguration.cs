using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkJwtExampleServer.Core.Entities;

namespace WorkJwtExampleServer.Data.Configuration
{
    internal class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasMany(x => x.FlashCards).WithOne(x => x.AppUser).HasForeignKey(x => x.AppUserId);
        }
    }
}
