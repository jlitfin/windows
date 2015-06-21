using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmsFilter
{
    public class Sms
    {
        public string Alias { get; set; }
        public string Sender { get; set; }
        public string Content { get; set; }
        public string DateString { get; set; }
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
    }
}
