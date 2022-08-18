using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Abstract
{
    public interface IProductPhotographyService
    {
        Task<IResult> AddAsync(IFormFile file,int productId);
    }
}
