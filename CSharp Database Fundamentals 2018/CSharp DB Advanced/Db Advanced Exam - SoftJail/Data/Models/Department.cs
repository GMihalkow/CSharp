using System.Collections.Generic;

namespace SoftJail.Data.Models
{
    public class Department
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Cell> Cells { get; set; }
    }
}