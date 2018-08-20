using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ExportDto
{
    [XmlType]
    public class XmlPrisonersExportDto
    {
        [XmlElement]
        public List<PrisonerXmlDto> Prisoner { get; set; }
    }
}
