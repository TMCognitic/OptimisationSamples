using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoVsEF
{
    public class Sample
    {
        public int Id { get; set; }
        public Guid Uid { get; set; }

        public override string ToString()
        {
            return $"{Id:D7} - {Uid.ToString().ToUpper()}";
        }
    }
}
