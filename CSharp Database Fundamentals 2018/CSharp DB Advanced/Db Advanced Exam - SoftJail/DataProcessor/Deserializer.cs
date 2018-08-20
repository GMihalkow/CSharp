namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using System;
    using System.Linq;
    using System.Text;
    using DataProcessor.ImportDto;
    using System.Text.RegularExpressions;
    using System.Globalization;
    using System.Collections.Generic;
    using System.Xml.Linq;
    using System.IO;
    using System.Xml.Serialization;
    using AutoMapper;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            var departments = JsonConvert.DeserializeObject<Department[]>(jsonString);

            foreach (var department in departments)
            {
                if (department.Name.Length < 3 || department.Name.Length > 25)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                if (department.Cells.Any(c => c.CellNumber > 1000 || c.CellNumber < 1))
                {

                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Department importDepartment = department;
                context.Add(importDepartment);
                context.SaveChanges();
                sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");

            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            string nicknamePattern = @"^The [A-Z][a-z]+$";
            string addressPattern = @"^[A-Z a-z0-9]+str.$";

            Regex nicknameRegex = new Regex(nicknamePattern);
            Regex addressRegex = new Regex(addressPattern);

            StringBuilder sb = new StringBuilder();

            var prisoners = JsonConvert.DeserializeObject<PrisonerImportDto[]>(jsonString);

            foreach (var prisoner in prisoners)
            {
                ;
                if (prisoner.FullName == null || prisoner.FullName.Length < 3 || prisoner.FullName.Length > 20)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                else if (prisoner.Nickname == null || nicknameRegex.Match(prisoner.Nickname).Success == false)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                else if (prisoner.Age < 18 || prisoner.Age > 65)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                else if (prisoner.Bail != null && prisoner.Bail < 0)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                else if (prisoner.Mails.Any(m => addressRegex.Match(m.Address).Success == false))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                if (prisoner.ReleaseDate == null)
                {

                    Prisoner importPrisoner = new Prisoner()
                    {
                        FullName = prisoner.FullName,
                        Nickname = prisoner.Nickname,
                        Age = prisoner.Age,
                        IncarcerationDate = DateTime.ParseExact(prisoner.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        ReleaseDate =null,
                        Bail = prisoner.Bail,
                        CellId = prisoner.CellId,
                        Mails = prisoner.Mails.ToList()
                    };

                    context.Add(importPrisoner);
                    context.SaveChanges();

                    sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
                }
                else
                {

                    Prisoner importPrisoner = new Prisoner()
                    {
                        FullName = prisoner.FullName,
                        Nickname = prisoner.Nickname,
                        Age = prisoner.Age,
                        IncarcerationDate = DateTime.ParseExact(prisoner.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        ReleaseDate = DateTime.ParseExact(prisoner.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        Bail = prisoner.Bail,
                        CellId = prisoner.CellId,
                        Mails = prisoner.Mails.ToList()
                    };

                    context.Add(importPrisoner);
                    context.SaveChanges();

                    sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            //xmlString = @"<Officers><Officer><Name>Riccardo Fockes</Name><Money>3623.98</Money><Position>Overseer</Position><Weapon>Pistol</Weapon><DepartmentId>3</DepartmentId><Prisoners><Prisoner id=""10"" /><Prisoner id=""16"" /><Prisoner id=""15"" /></Prisoners></Officer><Officer><Name>Arleen Zannolli</Name><Money>3539.40</Money><Position>Guard</Position><Weapon>FlashPulse</Weapon><DepartmentId>2</DepartmentId><Prisoners><Prisoner id=""2"" /></Prisoners></Officer><Officer><Name>Hailee Kennon</Name><Money>3652.49</Money><Position>Labour</Position><Weapon>Sniper</Weapon><DepartmentId>5</DepartmentId><Prisoners><Prisoner id=""3"" /><Prisoner id=""14"" /></Prisoners></Officer><Officer><Name>Lev de Chastelain</Name><Money>2442.80</Money><Position>Guard</Position><Weapon>Sniper</Weapon><DepartmentId>2</DepartmentId><Prisoners><Prisoner id=""13"" /><Prisoner id=""12"" /></Prisoners></Officer></Officers>";

            StringBuilder sb = new StringBuilder();

            XDocument xDoc = XDocument.Parse(xmlString);

            XmlSerializer serializer = new XmlSerializer(typeof(OfficerImportDto), new XmlRootAttribute("Officer"));
            var elements = xDoc.Root.Elements().ToArray();

            foreach (var element in elements)
            {
                using (TextReader reader = new StringReader(element.ToString()))
                {
                    var officer = (OfficerImportDto)serializer.Deserialize(reader);
                    ;
                    if (officer.Name.Length < 3 || officer.Name.Length > 30)
                    {
                        sb.AppendLine("Invalid Data");
                        continue;
                    }
                    else if (officer.Money < 0)
                    {
                        sb.AppendLine("Invalid Data");
                        continue;
                    }
                    else if (
                        officer.Position != "Overseer" 
                        && 
                        officer.Position != "Guard"
                        && 
                        officer.Position != "Watcher"
                        && 
                        officer.Position != "Labour")
                    {
                        sb.AppendLine("Invalid Data");
                        continue;
                    }
                    else if (
                        officer.Weapon != "Knife"
                        &&
                        officer.Weapon != "FlashPulse"
                        && 
                        officer.Weapon != "ChainRifle"
                        && 
                        officer.Weapon != "Pistol"
                        && 
                        officer.Weapon != "Sniper"
                        )
                    {
                        sb.AppendLine("Invalid Data");
                        continue;
                    }

                    //int invalidIds = 0;
                    //foreach (var prisoner in officer.Prisoners)
                    //{
                    //    if (context.Prisoners.Any(p => p.Id == prisoner.Id) == false)
                    //    {
                    //        invalidIds++;
                    //        break;
                    //    }
                    //}
                    //if (invalidIds > 0)
                    //{
                    //    sb.AppendLine("Invalid Data");
                    //    continue;
                    //}

                    Officer importOfficer = new Officer()
                    {
                        FullName = officer.Name,
                        Salary = officer.Money,
                        Position = (Position)Enum.Parse(typeof(Position), officer.Position, true),
                        Weapon = (Weapon)Enum.Parse(typeof(Weapon), officer.Weapon, true),
                        DepartmentId = officer.DepartmentId
                    };

                    context.Add(importOfficer);
                    context.SaveChanges();

                    foreach (var prisoner in officer.Prisoners)
                    {
                        OfficerPrisoner officerPrisoner = new OfficerPrisoner()
                        {
                            OfficerId = importOfficer.Id,
                            PrisonerId = prisoner.Id
                        };

                        context.Add(officerPrisoner);
                        context.SaveChanges();
                    }
                    
                    sb.AppendLine($"Imported {officer.Name} ({officer.Prisoners.Count} prisoners)");
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}