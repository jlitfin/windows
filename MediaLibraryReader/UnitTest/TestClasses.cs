using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTest
{

    public class testObj
    {
        public testObj()
        {
            ihateyou = new stupid();
        }

        public stupid ihateyou { get; set; }

    }

    public class stupid
    {
        public stupid()
        {
            episodes = new List<worst>();
            year = string.Empty;
        }
        public List<worst> episodes { get;set;}
        public string year { get; set; }
    }

    public class worst
    {
        public worst()
        {
            name = string.Empty;
            number = string.Empty;
        }
        public string name { get; set; }
        public string number { get; set; }
    }
}
