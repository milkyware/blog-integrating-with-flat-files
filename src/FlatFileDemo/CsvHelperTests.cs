using CsvHelper.Configuration;
using CsvHelper;
using FlatFileDemo.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlatFileDemo.Properties;
using System.Collections.Concurrent;
using FlatFileDemo.ClassMaps;

namespace FlatFileDemo
{
    public class CsvHelperTests
    {
        [Fact]
        public async Task GetRecords()
        {
            using var ms = new MemoryStream(Resources.customers);
            using var sr = new StreamReader(ms);
            using var csv = new CsvReader(sr, new CsvConfiguration(CultureInfo.InvariantCulture));
            csv.Context.RegisterClassMap<CustomerMap>();

            var records = csv.GetRecords<CHCustomer>();
        }

        [Fact]
        public async Task GetRecordsAsync()
        {
            using var ms = new MemoryStream(Resources.customers);
            using var sr = new StreamReader(ms);
            using var csv = new CsvReader(sr, new CsvConfiguration(CultureInfo.InvariantCulture));
            csv.Context.RegisterClassMap<CustomerMap>();

            var records = new List<CHCustomer>();
            await foreach (var r in csv.GetRecordsAsync<CHCustomer>())
            {
                records.Add(r);
            }
        }

        [Fact]
        public async Task GetRecordLoop()
        {
            using var ms = new MemoryStream(Resources.customers);
            using var sr = new StreamReader(ms);
            using var csv = new CsvReader(sr, new CsvConfiguration(CultureInfo.InvariantCulture));
            csv.Context.RegisterClassMap<CustomerMap>();

            var records = new List<CHCustomer>();
            while (await csv.ReadAsync())
            {
                var r = csv.GetRecord<CHCustomer>();
                records.Add(r);
            }
        }

        [Fact]
        public async Task GetMixedRecords()
        {
            using var ms = new MemoryStream(Resources.mixed_customer_organisations);
            using var sr = new StreamReader(ms);
            using var csv = new CsvReader(sr, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false
            });
            csv.Context.RegisterClassMap<CustomerMixedMap>();
            csv.Context.RegisterClassMap<OrganisationMixedMap>();

            var records = new List<object>();
            while (await csv.ReadAsync())
            {
                switch (csv.GetField(0))
                {
                    case "c":
                        var c = csv.GetRecord<CHCustomer>();
                        records.Add(c);
                        break;
                    case "o":
                        var o = csv.GetRecord<CHOrganisation>();
                        records.Add(o);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
