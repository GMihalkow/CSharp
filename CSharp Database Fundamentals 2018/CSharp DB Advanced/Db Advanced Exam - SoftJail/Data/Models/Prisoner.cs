using System;
using System.Collections.Generic;

namespace SoftJail.Data.Models
{
    public class Prisoner
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Nickname { get; set; }

        public int Age { get; set; }

        public DateTime IncarcerationDate { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public decimal? Bail { get; set; }

        public int? CellId { get; set; }

        public Cell Cell { get; set; }

        public List<Mail> Mails { get; set; }

        public List<OfficerPrisoner> PrisonerOfficers { get; set; }
    }
}