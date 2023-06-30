using FileHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatFileDemo.Models
{
    [DelimitedRecord(",")]
    public class FHCustomerMulti
    {
        public string? Tag { get; set; }
        public int Index { get; set; }
        public string? Id { get; set; }
        public string? FirstName { get; set; }
        public string? Surname { get; set; }
        [FieldQuoted]
        public string? Company { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Phone1 { get; set; }
        public string? Phone2 { get; set; }
        public string? Email { get; set; }
        [FieldConverter(ConverterKind.Date, "yyyy-MM-dd")]
        public DateTime SubscriptionDate { get; set; }
        public string? Website { get; set; }
    }
}
