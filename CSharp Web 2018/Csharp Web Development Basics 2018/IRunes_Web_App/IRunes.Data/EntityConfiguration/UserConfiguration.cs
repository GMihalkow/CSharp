namespace IRunes.Data.EntityConfiguration
{
    using IRunes.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(user => user.Id);

            builder
                .Property(user => user.Username)
                .HasAnnotation(@"[StringLength(30, MinimumLength = 3, ErrorMessage = ""Invalid"")]", true)
                .HasColumnType("VARCHAR(30)");

            builder
                .Property(user => user.Password)
                .HasColumnType("VARCHAR(100)");

            builder
                .Property(user => user.Email)
                .HasAnnotation(@"[StringLength(30, MinimumLength = 3, ErrorMessage = ""Invalid"")]", true)
                .HasColumnType("VARCHAR(30)");
            
        }
    }
}
