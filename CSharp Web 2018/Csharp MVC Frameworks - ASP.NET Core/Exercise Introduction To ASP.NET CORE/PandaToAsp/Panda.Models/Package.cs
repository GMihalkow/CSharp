namespace Panda.Models
{
    using Panda.Models.Enums;
    using System;
    using System.Collections.Generic;

    public class Package
    {
        public string Id { get; set; }

        public string Description { get; set; }

        public double Weight { get; set; }

        public string ShippingAddress { get; set; }

        public Status Status { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public PandaUser Recipient { get; set; }

        public string RecipientId { get; set; }

        public ICollection<Receipt> Receipts { get; set; }
    }
}
