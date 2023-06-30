using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatFileDemo.Models
{
    public class CHCustomer
    {
        public string? Id { get; set; }
        public string? FirstName { get; set; }
        public string? Surname { get; set; }
        public string? Company { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Phone1 { get; set; }
        public string? Phone2 { get; set; }
        public string? Email { get; set; }
        public DateTime SubscriptionDate { get; set; }
        public string? Website { get; set; }
    }
}
