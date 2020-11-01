using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Numerics;
using VSP_46275z_MyProject.Data.Infrastructure;
using VSP_46275z_MyProject.Models;

namespace VSP_46275z_MyProject.Data.EntityConfiguration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(u => u.Id);
            
            builder
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();

            builder
                .HasIndex(u => u.Username)
                .IsUnique();

            builder
                .Property(u => u.Username)
                .HasMaxLength(Constants.UsernameMaxLength)
                .IsRequired();

            builder
                .Property(u => u.PasswordHash)
                .IsRequired();
        }
    }
}