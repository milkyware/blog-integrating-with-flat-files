using FileHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatFileDemo.Models
{
    [FixedLengthRecord]
    public class FHCustomerFixed
    {
        [FieldFixedLength(5)]
        public int Id;

        [FieldFixedLength(30)]
        [FieldTrim(TrimMode.Both)]
        public string Name;

        [FieldFixedLength(8)]
        [FieldConverter(ConverterKind.Date, "ddMMyyyy")]
        public DateTime AddedDate;
    }
}
