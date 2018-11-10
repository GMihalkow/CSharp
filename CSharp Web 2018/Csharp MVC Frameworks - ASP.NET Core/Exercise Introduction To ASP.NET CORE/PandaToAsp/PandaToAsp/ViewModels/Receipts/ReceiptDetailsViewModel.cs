using System;

namespace PandaToAsp.ViewModels.Receipts
{
    public class ReceiptDetailsViewModel
    {
        public string Id { get; set; }

        public DateTime IssuedOn { get; set; }

        public string DeliveryAddress { get; set; }

        public double PackageWeight { get; set; }

        public string Description { get; set; }

        public decimal Total { get; set; }

        public string Recipient { get; set; }
    }
}
