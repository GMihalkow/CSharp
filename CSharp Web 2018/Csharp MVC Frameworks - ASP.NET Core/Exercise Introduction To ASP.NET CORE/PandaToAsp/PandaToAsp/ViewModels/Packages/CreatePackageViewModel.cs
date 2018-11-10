namespace PandaToAsp.ViewModels.Packages
{
    using Panda.Models.Enums;
    using System;

    public class CreatePackageViewModel
    {
        public string Description { get; set; }

        public double Weight { get; set; }

        public string ShippingAddress { get; set; }

        public Status Status { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public string Recepient { get; set; }
    }
}