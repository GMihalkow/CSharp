using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_BillsPaymentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder
                .HasKey(b => b.BankAccountId);

            builder
                .Property(b => b.BankName)
                .HasMaxLength(50)
                .IsUnicode(true);

            builder
                .Property(b => b.SwiftCode)
                .HasMaxLength(20)
                .IsUnicode(false);
        }
    }
}
