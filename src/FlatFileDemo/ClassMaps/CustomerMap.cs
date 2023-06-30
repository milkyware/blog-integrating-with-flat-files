using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using FlatFileDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatFileDemo.ClassMaps
{
    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Map(m => m.Id).Index(1);
            Map(m => m.FirstName).Index(2);
            Map(m => m.Surame).Index(3);
            Map(m => m.Company).Index(4);
            Map(m => m.City).Index(5);
            Map(m => m.Country).Index(6);
            Map(m => m.Phone1).Index(7);
            Map(m => m.Phone2).Index(8);
            Map(m => m.Email).Index(9);
            Map(m => m.SubscriptionDate).Index(10);
            Map(m => m.Website).Index(11);
        }
    }
}
