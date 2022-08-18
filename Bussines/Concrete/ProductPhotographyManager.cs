using Bussines.Abstract;
using Core.Utilities.FileUploads;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;

namespace Bussines.Concrete
{
    public class ProductPhotographyManager : IProductPhotographyService
    {
        private readonly IFileUpload _fileUpload;
        private readonly IProductPhotographyDal _productPhotographyDal;

        public ProductPhotographyManager(IFileUpload fileUpload, IProductPhotographyDal productPhotographyDal)
        {
            _fileUpload = fileUpload;
            _productPhotographyDal = productPhotographyDal;
        }

        public async Task<IResult> AddAsync(IFormFile file, int productId)
        {
            var result = await _fileUpload.Upload(file, "Products");
            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }
            var productPhotography = new ProductPhotography { ProductId = productId, Url = "Products" + result.Data };
            await _productPhotographyDal.AddAsync(productPhotography);
            return new SuccessResult("Yüklendi");
        }

    }
}
