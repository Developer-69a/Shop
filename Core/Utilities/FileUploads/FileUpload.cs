using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.FileUploads
{
    public class FileUpload : IFileUpload
    {
        public Task<IResult> Delete(string path)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<string>> Upload(IFormFile file, string path )
        {
            try
            { 
                var fileName = "";
                var fileRootPath = ""; 
                fileRootPath = Directory.GetCurrentDirectory()+"\\wwwroot\\"+path;
                if (PathFileControl(fileRootPath))
                {                      
                    var getFileExtensions = Path.GetExtension(file.FileName).ToLower(new CultureInfo("tr-TR", false));
                    fileName = "\\" + Guid.NewGuid().ToString() + getFileExtensions;
                    fileRootPath += fileName;
                    using (var stream = System.IO.File.Create(fileRootPath))
                    {

                        await file.CopyToAsync(stream);
                    }
                    return new SuccessDataResult<string> ( fileName,"" );
                }
                else
                {
                    return new ErrorDataResult<string>("Dosya hatası");
                }
            }
            catch (Exception ex)
            {

               return new ErrorDataResult<string>(ex.Message);
            }
        }
        public bool PathFileControl(string path)
        {

            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
