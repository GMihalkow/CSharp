﻿namespace Panda.Models
{
    using System;

    public class Receipt
    {
        public string Id { get; set; }

        public decimal Fee { get; set; }

        public DateTime IssuedOn { get; set; }

        public PandaUser Recipient { get; set; }

        public string RecipientId { get; set; }

        public Package Package { get; set; }

        public string PackageId { get; set; }
    }
}