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
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public  async Task<IResult> DeleteAsync(Category category)
        {
            if (category == null)
            {
                return new ErrorResult("Kategori Silinemedi.");
            }
            await _categoryDal.DeleteAsync(category);
            return new SuccessResult("Kategori Silindi.");
        }

        public async Task<IDataResult<List<Category>>> GetListAsync()
        {
            var CategoryList= await _categoryDal.GetListAsync();
            if (CategoryList==null)
            {
                return new ErrorDataResult<List<Category>>("Kategori Listelenemedi.");
            }
            return new SuccessDataResult<List<Category>>(CategoryList.ToList(), "Kategory Listelendi.");
        }
    }
}
