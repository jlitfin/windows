using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnector
{
    public class CompareRequest
    {
        public string PrimaryServer { get; set; }
        public string SecondaryServer { get; set; }
        public string PrimaryDatabase { get; set; }
        public string SecondaryDatabase { get; set; }
    }
}
