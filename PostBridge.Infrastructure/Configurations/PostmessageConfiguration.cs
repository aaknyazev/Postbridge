using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PostBridge.Domain.Postmessage;

namespace PostBridge.Infrastructure.Configurations
{
    public class PostmessageConfiguration: IEntityTypeConfiguration<Postmessage>
    {
        public void Configure(EntityTypeBuilder<Postmessage> builder)
        {
            builder.ToTable("Postmessage").HasKey(p => p.Id);
            builder.Property(p => p.Id).UseIdentityColumn();
            builder.Property(p => p.Status).IsRequired();
            builder.Property(p => p.Message).HasColumnType("nvarchar(max)");
            builder.Property(p => p.CreationDate).HasColumnType("datetime");
            builder.Property(p => p.SentDate).HasColumnType("datetime");
            builder.Property(p => p.ReceivedDate).HasColumnType("datetime");
        }
    }
}
