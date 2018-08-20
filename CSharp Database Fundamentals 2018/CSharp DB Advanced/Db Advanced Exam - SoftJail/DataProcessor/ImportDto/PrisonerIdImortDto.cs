using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlRoot("Prisoners")]
    [XmlType("Prisoner")]
    public class PrisonerIdImortDto
    {
        
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
