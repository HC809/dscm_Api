using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiunsaSCM.Utils;

namespace DiunsaSCM.Core.Services
{
    public interface IServiceBase<TModel>
    {
        ServiceResult<TModel> Add(TModel model);
        Task<ServiceResult<IEnumerable<TModel>>> GetAllAsync(string searchString = "", int slice = 0);
        Task<ServiceResult<IEnumerable<TModel>>> GetAllByParentAsync(long parentId);
        ServiceResult<TModel> GetById(long id);
        ServiceResult<TModel> Delete(long id);
        ServiceResult<TModel> Update(TModel model);
    }
}
