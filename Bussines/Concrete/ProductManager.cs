using Bussines.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public async Task<IResult> AddAsync(Product product)
        {
            await _productDal.AddAsync(product);
            return new SuccessResult("Ürün Eklendi");
        }

        public async Task<IDataResult<List<Product>>> GetAll()
        {
            var productList = await _productDal.GetListAsync();
            return new SuccessDataResult<List<Product>>(productList.ToList());
        }
    }
}
