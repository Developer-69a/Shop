using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Abstract
{
    public interface ICategoryService
    {
        Task<IResult> DeleteAsync(Category category);
        Task<IDataResult<List<Category>>> GetListAsync();
        Task<IDataResult<Category>> GetIdAsync(int Id);
        Task<IDataResult<List<Category>>> SearchAsync(string name);
        Task<IResult> AddAsync(Category category);
          
    }
}
