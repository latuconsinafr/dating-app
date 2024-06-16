using DatingApp.Core.Aggregates.Profiles;
using DatingApp.Core.Aggregates.Profiles.Entities;
using DatingApp.Core.Aggregates.Profiles.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DatingApp.Infrastructure.Data.Configurations;

public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
{
  public void Configure(EntityTypeBuilder<Profile> builder)
  {
    builder.HasKey(builder => builder.Id);

    builder.Property(p => p.Id)
        .ValueGeneratedNever();

    builder.Property(p => p.FirstName)
      .IsRequired()
      .HasMaxLength(ProfileConstants.FIRST_NAME_MAX_LENGTH);

    builder.Property(p => p.LastName)
      .IsRequired()
      .HasMaxLength(ProfileConstants.LAST_NAME_MAX_LENGTH);

    builder.OwnsOne(builder => builder.Birthday, b =>
    {
      b.Property(bp => bp.Day)
        .HasMaxLength(2)
        .IsRequired();

      b.Property(bp => bp.Month)
        .HasMaxLength(2)
        .IsRequired();

      b.Property(bp => bp.Year)
      .HasMaxLength(4)
      .IsRequired();
    });

    builder.Property(p => p.Gender)
      .IsRequired()
      .HasConversion(
        v => v.ToString(),
        v => (ProfileGender)Enum.Parse(typeof(ProfileGender), v));

    builder.Property(p => p.LookingFor)
      .IsRequired()
      .HasConversion(
        v => v.ToString(),
        v => (ProfileLookingFor)Enum.Parse(typeof(ProfileLookingFor), v));
  }
}
