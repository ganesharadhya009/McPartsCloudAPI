using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mcparts.Infrastructure.FileDocumentManager
{
    public class FileDocumentSettings
    {
        public string PathFolder { get; set; } = string.Empty;
        public int MaxFileSizeInMB { get; set; }
    }
}
