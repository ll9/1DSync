using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DSync.Models
{
    public class PseudoDynamicEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string StringCol1 { get; set; }
        public string StringCol2 { get; set; }
        public string StringCol3 { get; set; }
        public string StringCol4 { get; set; }
        public string StringCol5 { get; set; }
        public string StringCol6 { get; set; }
        public string StringCol7 { get; set; }
        public string StringCol8 { get; set; }
        public string StringCol9 { get; set; }
        public double DoubleCol1 { get; set; }
        public double DoubleCol2 { get; set; }
        public double DoubleCol3 { get; set; }
        public DateTime DateTimeCol1 { get; set; }
        public DateTime DateTimeCol2 { get; set; }

        public bool SyncStatus { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
        public DateTime? LastModified { get; set; }
    }
}
