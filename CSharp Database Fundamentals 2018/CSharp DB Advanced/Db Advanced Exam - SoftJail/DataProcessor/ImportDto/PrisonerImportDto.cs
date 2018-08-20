using SoftJail.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftJail.DataProcessor.ImportDto
{
    public class PrisonerImportDto
    {
        public string FullName { get; set; }

        public string Nickname { get; set; }

        public int Age { get; set; }

        public string IncarcerationDate { get; set; }

        public string ReleaseDate { get; set; }

        public int? CellId { get; set; }

        public decimal? Bail { get; set; }

        public ICollection<Mail> Mails { get; set; }
    }
}
