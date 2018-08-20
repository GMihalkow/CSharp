using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_BillsPaymentSystem.Data.Models;

namespace P01_BillsPaymentSystem.Data
{
    public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .HasIndex(p => new
                {
                    p.UserId,
                    p.BankAccountId,
                    p.CreditCardId
                })
                .IsUnique(true);
        }
    }
}