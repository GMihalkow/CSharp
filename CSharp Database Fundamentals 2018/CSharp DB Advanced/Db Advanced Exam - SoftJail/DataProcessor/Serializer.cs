namespace SoftJail.DataProcessor
{
    using AutoMapper.QueryableExtensions;
    using Data;
    using Newtonsoft.Json;
    using SoftJail.DataProcessor.ExportDto;
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners =
                context
                .Prisoners
                .Where(p => ids.Contains(p.Id))
                .Select(p => new
                {
                    Id = p.Id,
                    Name = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers.Select(po => new
                    {
                        OfficerName = po.Officer.FullName,
                        Department = po.Officer.Department.Name
                    })
                    .OrderBy(x => x.OfficerName)
                    .ToArray(),
                    TotalOfficerSalary = p.PrisonerOfficers.Sum(po => po.Officer.Salary)
                })
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .ProjectTo<PrisonerExportDto>()
                .ToArray();

            ;

            var serializer = JsonConvert.SerializeObject(prisoners, Formatting.Indented);

            return serializer.ToString().TrimEnd();

        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            string[] separatedNames =
                prisonersNames
                .Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            
            //var descr =
            //    context
            //    .Mails
            //    .Where(w => separatedNames.Contains(w.Prisoner.FullName))
            //    .Select(m => m.Description.ToCharArray().Reverse().ToString())
            //    .ToArray();

            //context.SaveChanges();

            var prisoners =
                context
                .Prisoners
                .Where(p => prisonersNames.Contains(p.FullName))
                .Select(p => new
                {
                    Id = p.Id,
                    Name = p.FullName,
                    IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd"),
                    EncryptedMessages = p.Mails.Select(m => new
                    {
                        Description = m.Description
                    }).ToArray()
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ProjectTo<PrisonerXmlDto>()
                .ToList();


            foreach (var prisoner in prisoners)
            {
                foreach (var message in prisoner.EncryptedMessages)
                {
                    var descr = message.Description;
                    string result = string.Empty;
                    for (int i = message.Description.Length-1; i >= 0; i--)
                    {
                        result += descr[i];
                    }
                    message.Description = result;
                    context.SaveChanges();
                }
            }


            ;

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            XmlPrisonersExportDto exportDto = new XmlPrisonersExportDto()
            {
                Prisoner = prisoners.ToList()
            };

            var serializer = new XmlSerializer(typeof(XmlPrisonersExportDto), new XmlRootAttribute("Prisoners"));

            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, exportDto, ns);
                return writer.ToString().TrimEnd();
            }

        }
    }
}