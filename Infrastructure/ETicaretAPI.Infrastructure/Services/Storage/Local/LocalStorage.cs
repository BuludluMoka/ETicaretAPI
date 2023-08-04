using OnionArchitecture.Application.Abstractions.Storage.Local;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Infrastructure.Services.Storage.Local
{
    public class LocalStorage : Storage, ILocalStorage
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public LocalStorage(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        private static string BasePath => "..\\Project Items\\Uploads";

        public async Task DeleteAsync(string path, string fileName)
            => File.Delete($"{path}\\{fileName}");

        public List<string> GetFiles(string path)
        {
            DirectoryInfo directory = new(path);
            return directory.GetFiles().Select(f => f.Name).ToList();
        }
        public bool HasFile(string path, string fileName)
            => File.Exists($"{path}\\{fileName}");
        async Task<bool> CopyFileAsync(string path, IFormFile file)
        {
            try
            {
                await using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                return true;
            }
            catch (Exception ex)
            {
                //todo log!
                throw ex;
            }
        }
        public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(IFormFileCollection files, string path)
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, BasePath + path);
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            List<(string fileName, string path)> datas = new();

            foreach (IFormFile file in files)
            {
                string fileNewName = await FileRenameAsync(path, file.Name, HasFile);
                await CopyFileAsync($"{uploadPath}\\{fileNewName}", file);
                datas.Add((fileNewName, $"{path}\\{fileNewName}"));
            }

            return datas;
        }
        public async Task<(string fileName, string pathOrContainerName)> UploadAsync(IFormFile file, string path)
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, BasePath + path);
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);
            (string fileName, string path) datas = new();
            string fileNewName = await FileRenameAsync(path, file.Name, HasFile);
            await CopyFileAsync($"{uploadPath}\\{fileNewName}", file);
            datas.fileName = fileNewName;
            datas.path = $"{path}\\{fileNewName}";

            return datas;
        }
    }
}
