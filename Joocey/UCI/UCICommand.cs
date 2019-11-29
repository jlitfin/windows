using System;
using System.Collections.Generic;
using System.Text;

namespace UCI
{
    public class UCICommand
    {
        public string Command { get; set; }
        public string Reply { get; set; }
        public StateKeyValue SetKey { get; set; }
    }
}
