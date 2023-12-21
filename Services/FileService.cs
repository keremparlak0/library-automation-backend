using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Services.Contracts;

namespace Services
{
    public class FileService : IFileService
    {
        private readonly IHostingEnvironment _environment;
        public FileService(IHostingEnvironment environment)
        {
            _environment = environment;
        }
        public string FileFromBase64(string base64, string newFileName, string existFileUrl, string existRoot)
        {
            var fileRoot = $@"{_environment.WebRootPath}\assets";
            var existFileRoot = $@"{_environment.WebRootPath}\assets\{existRoot}";

            if (Directory.Exists(existFileRoot))
            {
                Directory.CreateDirectory(existFileRoot);
            }

            var valueBytes = System.Convert.FromBase64String(base64);
            var fileName = $"{newFileName}";
            var ppRoot = $"{existFileRoot}\\{fileName}";

            var deleteingPpRoot = $"{fileRoot}\\{existFileUrl}";
            if (File.Exists(deleteingPpRoot))
            {
                File.Delete(deleteingPpRoot);
            }
            File.WriteAllBytes(ppRoot, valueBytes);

            return fileName;
        }
    }
}
