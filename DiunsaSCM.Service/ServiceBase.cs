using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Services;
using DiunsaSCM.Utils;

namespace DiunsaSCM.Service
{
    public class ServiceBase<TEntity, TModel> : IServiceBase<TModel>
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        protected readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<TEntity> repository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public virtual ServiceResult<TModel> Add(TModel model)
        {
            try
            {
                var entity = _mapper.Map<TEntity>(model);
                entity = _repository.Add(entity);
                _repository.SaveChanges();
                model = _mapper.Map<TModel>(entity);
                return ServiceResult<TModel>.SuccessResult(model);
            }
            catch (Exception ex)
            {
                return ServiceResult<TModel>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos.");
            }
        }

        public ServiceResult<TModel> Delete(long id)
        {
            try
            {
                var entity = _repository.GetById(id);
                var model = _mapper.Map<TModel>(entity);
                _repository.Delete(entity);
                _repository.SaveChanges();
                return ServiceResult<TModel>.SuccessResult(model);
            }
            catch (Exception ex)
            {
                return ServiceResult<TModel>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos.");
            }
        }

        public async Task<ServiceResult<IEnumerable<TModel>>> GetAllAsync(string searchString = "", int slice = 0)
        {
            try
            {
                var query= _repository.All(searchString, slice);
                var entityList = query;
                var model = entityList.Select(x => _mapper.Map<TModel>(x));
                return ServiceResult<IEnumerable<TModel>>.SuccessResult(model);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<TModel>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos.");
            }
        }

        public virtual async Task<ServiceResult<IEnumerable<TModel>>> GetAllByParentAsync(long parentId)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<TModel> GetById(long id)
        {
            try
            {
                var entity = _repository.GetById(id);
                var model = _mapper.Map<TModel>(entity);
                return ServiceResult<TModel>.SuccessResult(model);
            }
            catch (Exception ex)
            {
                return ServiceResult<TModel>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos.");
            }
        }

        public ServiceResult<TModel> Update(TModel model)
        {
            try
            {
                var entity = _mapper.Map<TEntity>(model);
                entity = _repository.Update(entity);
                _repository.SaveChanges();
                return ServiceResult<TModel>.SuccessResult(model);
            }
            catch (Exception ex)
            {
                return ServiceResult<TModel>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos.");
            }
        }
    }
}
