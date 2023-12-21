using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IFileService
    {
        string FileFromBase64(string base64, string newFileName, string existFileUrl, string existRoot);
    }
}
