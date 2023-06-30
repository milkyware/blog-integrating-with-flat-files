using FileHelpers;
using FlatFileDemo.Models;
using FlatFileDemo.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatFileDemo
{
    public class FileHelperTests
    {
        [Fact]
        public void GetDelmitedRecords()
        {
            using var ms = new MemoryStream(Resources.customers);
            using var sr = new StreamReader(ms);
            var engine = new FileHelperAsyncEngine<FHCustomer>();
            using (engine.BeginReadStream(sr))
            {
                foreach (var c in engine)
                {
                    Console.WriteLine($"Processing {c.FirstName} {c.Surname}");
                }
            }
        }
    }
}
