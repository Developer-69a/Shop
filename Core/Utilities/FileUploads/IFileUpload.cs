using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.FileUploads
{
    public interface IFileUpload
    {
        Task<IDataResult<string>> Upload(IFormFile file,string path);
        Task<IResult> Delete(string path);
    }
}
