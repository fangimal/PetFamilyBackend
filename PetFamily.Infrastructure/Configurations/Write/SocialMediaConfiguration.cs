using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Entities;

namespace PetFamily.Infrastructure.Configurations.Write;

public class SocialMediaConfiguration : IEntityTypeConfiguration<SocialMedia>
{
    public void Configure(EntityTypeBuilder<SocialMedia> builder)
    {
        builder.ToTable("social_medias");
        builder.HasKey(s => s.Id);

        builder.ComplexProperty(s => s.Social, b => 
            b.Property(s => s.Value).HasColumnName("social"));
    }
}