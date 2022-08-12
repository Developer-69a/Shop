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

        public  async Task<IResult> AddAsync(Category category)
        {
           await _categoryDal.AddAsync(category);
            return new SuccessResult("Kategori Eklendi.");
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

        public async Task<IDataResult<Category>> GetIdAsync(int Id)
        {
            var category=await _categoryDal.GetAsync(x => x.Id == Id);
            return new SuccessDataResult<Category>(category,"");
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

        public async Task<IDataResult<List<Category>>> SearchAsync(string name)
        {
            var categoryList = await _categoryDal.GetListAsync(x => x.CategoryName.ToLower().Contains(name.ToLower()));
            return new SuccessDataResult<List<Category>>(categoryList.ToList());
        }
    }
}
