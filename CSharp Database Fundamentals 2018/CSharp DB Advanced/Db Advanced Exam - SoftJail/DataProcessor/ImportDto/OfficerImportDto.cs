using SoftJail.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlRoot("Officer")]
    public class OfficerImportDto
    {
        public string Name { get; set; }

        public decimal Money { get; set; }

        public string Position { get; set; }

        public string Weapon { get; set; }

        public int DepartmentId { get; set; }

        [XmlArray("Prisoners")]
        [XmlArrayItem("Prisoner", typeof(PrisonerIdImortDto))]
        public List<PrisonerIdImortDto> Prisoners { get; set; }

    }
}
