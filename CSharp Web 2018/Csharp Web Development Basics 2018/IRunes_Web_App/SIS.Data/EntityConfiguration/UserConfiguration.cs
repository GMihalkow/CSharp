namespace ByTheCake.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using ByTheCake.Models;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(u => u.Id);

            builder
                .Property(u => u.Username)
                .HasAnnotation(@"[StringLength(30, MinimumLength = 3, ErrorMessage = ""Invalid"")]", true)
                .HasColumnType("VARCHAR(30)");
            
            builder
                .Property(u => u.Password)
                .IsRequired(true);

            builder
                .Property(u => u.ConfirmPassword)
                .IsRequired(true);
        }
    }
}
