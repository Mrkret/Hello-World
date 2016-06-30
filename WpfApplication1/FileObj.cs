using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    public class FileObj
    {
        public FileObj(string dir)
        {
            Directory = dir;
            FileInfo fInfo = new FileInfo(Directory);
            Name = fInfo.Name;
            Extension = fInfo.Extension;
        }

        public string Name { get; set; }
       
        public string Extension { get; set; }

        public string Directory { get; set; }
    
    }
}
