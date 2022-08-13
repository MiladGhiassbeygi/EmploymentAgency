using Domain.WriteModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration.AreaConfig
{
    internal class ReminderDataConfig : IEntityTypeConfiguration<ReminderData>
    {
        public void Configure(EntityTypeBuilder<ReminderData> builder)
        {
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.EventDate).HasColumnType("timestamp");

            builder.Property(e => e.Note).IsRequired();

            builder.Property(e => e.NoteTitle)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(e => e.OwnerId).IsRequired();
        }
    }
}
