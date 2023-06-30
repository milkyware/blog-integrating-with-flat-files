using FileHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatFileDemo.Models
{
    [DelimitedRecord(",")]
    [IgnoreFirst]
    public class FHOrganisation
    {
        public int Index { get; set; }
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Website { get; set; }
        public string? Country { get; set; }
        public string? Description { get; set; }
        public int Founded { get; set; }
        public string? Industry { get; set; }
        public int Employees { get; set; }
    }
}
