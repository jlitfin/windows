using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageManagement
{
    public class LibraryFile
    {

        public string SourceDirectory { get; set; }
        public string SourceName { get; set; }
        public string SourcePath
        {
            get
            {
                return SourceDirectory + "\\" + SourceName;
            }
        }


        public string TargetDirectory { get; set; }
        public string TargetName { get; set; }
        public string TargetPath
        {
            get
            {
                return TargetDirectory + "\\" + TargetName;
            }
        }
        
    }
}
