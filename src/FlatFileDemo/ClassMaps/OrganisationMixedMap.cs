using CsvHelper.Configuration;
using FlatFileDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatFileDemo.ClassMaps
{
    public class OrganisationMixedMap : ClassMap<CHOrganisation>
    {
        public OrganisationMixedMap()
        {
            Map(m => m.Id).Index(2);
            Map(m => m.Name).Index(3);
            Map(m => m.Website).Index(4);
            Map(m => m.Country).Index(5);
            Map(m => m.Description).Index(6);
            Map(m => m.Founded).Index(7);
            Map(m => m.Industry).Index(8);
            Map(m => m.Employees).Index(9);
        }
    }
}
