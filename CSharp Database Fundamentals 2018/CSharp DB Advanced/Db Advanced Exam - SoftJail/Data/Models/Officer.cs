using System;
using System.Collections.Generic;
using System.Text;

namespace SoftJail.Data.Models
{
    public class Officer
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public decimal Salary { get; set; }

        public Position Position { get; set; }

        public Weapon Weapon { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public List<OfficerPrisoner> OfficerPrisoners { get; set; }
    }
}
