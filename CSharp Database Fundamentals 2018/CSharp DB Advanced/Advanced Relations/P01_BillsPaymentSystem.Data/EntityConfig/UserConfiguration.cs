﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_BillsPaymentSystem.Data.Models;

namespace P01_BillsPaymentSystem.Data
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(u => u.UserId);

            builder
                .Property(u => u.FirstName)
                .HasMaxLength(50)
                .IsUnicode(true);

            builder
                .Property(u => u.LastName)
                .HasMaxLength(50)
                .IsUnicode(true);

            builder
                .Property(u => u.Email)
                .HasMaxLength(80)
                .IsUnicode(false);

            builder
                .Property(u => u.Password)
                .HasMaxLength(25)
                .IsUnicode(false);
        }
    }
}