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
        public string name;
        public string directory;
        public string extension;
        
        public string Directory
        {
            get
            {
                return directory;
            }
            set
            {
                directory = value;
                FileInfo FInfo = new FileInfo(directory);
                name = FInfo.Name;
                extension = FInfo.Extension;                
            }
        }     
    }
}
