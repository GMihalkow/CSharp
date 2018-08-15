using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Diagnostics.CodeAnalysis;

namespace P03_SalesDatabase.Data.Models
{
    public class Sale
    {
        [DbFunctionAttribute("SqlServer", "GETDATE")]
        [SuppressMessageAttribute("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public static DateTime GetDate()
        {
            return DateTime.Now;
        }

        public int SaleId { get; set; }

        public DateTime Date { get; set; } = GetDate();

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int StoreId { get; set; }

        public Store Store { get; set; }
    }
}
