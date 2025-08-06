using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mcparts.Infrastructure.FileImageManager
{
    public class FileImageSettings
    {
        public string PathFolder { get; set; } = string.Empty;
        public int MaxFileSizeInMB { get; set; }
    }

}
