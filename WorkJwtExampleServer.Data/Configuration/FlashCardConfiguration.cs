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
    class FlashCardConfiguration : IEntityTypeConfiguration<FlashCard>
    {
        public void Configure(EntityTypeBuilder<FlashCard> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.MotherLanguageText).HasMaxLength(100);
            builder.Property(x => x.TargetLanguageText).HasMaxLength(100);
            builder.Property(x => x.Caption).HasMaxLength(300);
            builder.Property(x => x.PhotoPath).HasMaxLength(300);
        }
    }
}
