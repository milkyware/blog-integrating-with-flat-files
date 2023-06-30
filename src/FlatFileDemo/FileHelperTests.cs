using FileHelpers;
using FlatFileDemo.Models;
using FlatFileDemo.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace FlatFileDemo
{
    public class FileHelperTests
    {
        private readonly ITestOutputHelper _output;

        public FileHelperTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void GetDelmitedRecords()
        {
            using var ms = new MemoryStream(Resources.customers);
            using var sr = new StreamReader(ms);
            using var engine = new FileHelperAsyncEngine<FHCustomer>();
            using (engine.BeginReadStream(sr))
            {
                foreach (var c in engine)
                {
                    _output.WriteLine($"Processing {c.FirstName} {c.Surname}");
                }
            }
        }

        [Fact]
        public async Task GetDelimitedMixedRecords()
        {
            using var ms = new MemoryStream(Resources.mixed_customer_organisations);
            using var sr = new StreamReader(ms);
            using var engine = new MultiRecordEngine(typeof(FHCustomerMulti), typeof(FHOrganisationMulti));
            engine.RecordSelector = new RecordTypeSelector(MultiSelector);
            engine.BeginReadStream(sr);
            foreach (var r in engine)
            {
                if (r is FHCustomerMulti)
                    _output.WriteLine($"{(r as FHCustomerMulti).FirstName} {(r as FHCustomerMulti).Surname}");

                if (r is FHOrganisationMulti)
                    _output.WriteLine((r as FHOrganisationMulti).Name);
            }
        }

        private Type MultiSelector(MultiRecordEngine engine, string recordLine)
        {
            if (recordLine.Length == 0)
                return null;

            switch (recordLine[0])
            {
                case 'c':
                    return typeof(FHCustomerMulti);
                case 'o':
                    return typeof(FHOrganisationMulti);
                default:
                    return null;
            }
        }
    }
}
