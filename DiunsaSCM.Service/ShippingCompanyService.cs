using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Services;
using DiunsaSCM.Utils;

namespace DiunsaSCM.Service
{
    public class ShippingCompanyService : IShippingCompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ShippingCompanyService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public ServiceResult<ShippingCompanyDataTransferObject> Add(ShippingCompanyDataTransferObject shippingCompanyDataTransferObject)
        {
            try
            {
                var shippingCompany = _mapper.Map<ShippingCompany>(shippingCompanyDataTransferObject);
                shippingCompany = _unitOfWork.ShippingCompanies.Add(shippingCompany);
                _unitOfWork.Complete();
                shippingCompanyDataTransferObject.Id = shippingCompany.Id;
                return ServiceResult<ShippingCompanyDataTransferObject>.SuccessResult(shippingCompanyDataTransferObject);
            }
            catch (Exception ex)
            {
                return ServiceResult<ShippingCompanyDataTransferObject>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }

        public ServiceResult<ShippingCompanyDataTransferObject> Delete(long id)
        {
            try
            {
                var shippingCompany = _unitOfWork.ShippingCompanies.GetById(id);
                var shippingCompanyDataTransferObject = _mapper.Map<ShippingCompanyDataTransferObject>(shippingCompany);
                _unitOfWork.ShippingCompanies.Delete(shippingCompany);
                _unitOfWork.Complete();
                return ServiceResult<ShippingCompanyDataTransferObject>.SuccessResult(shippingCompanyDataTransferObject);
            }
            catch (Exception ex)
            {
                return ServiceResult<ShippingCompanyDataTransferObject>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }

        public ServiceResult<IEnumerable<ShippingCompanyDataTransferObject>> GetAll()
        {
            try
            {
                var shippingCompanies = _unitOfWork.ShippingCompanies.All();
                var shippingCompanyDataTransferObjects = shippingCompanies.Select(x => _mapper.Map<ShippingCompanyDataTransferObject>(x));
                return ServiceResult<IEnumerable<ShippingCompanyDataTransferObject>>.SuccessResult(shippingCompanyDataTransferObjects);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<ShippingCompanyDataTransferObject>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }

        public ServiceResult<ShippingCompanyDataTransferObject> GetById(long id)
        {
            try
            {
                var shippingCompany = _unitOfWork.ShippingCompanies.GetById(id);
                var shippingCompanyDataTransferObject = _mapper.Map<ShippingCompanyDataTransferObject>(shippingCompany);
                return ServiceResult<ShippingCompanyDataTransferObject>.SuccessResult(shippingCompanyDataTransferObject);
            }
            catch (Exception ex)
            {
                return ServiceResult<ShippingCompanyDataTransferObject>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }

        public ServiceResult<ShippingCompanyDataTransferObject> Update(ShippingCompanyDataTransferObject shippingCompanyDataTransferObject)
        {
            try
            {
                var shippingCompany = _mapper.Map<ShippingCompany>(shippingCompanyDataTransferObject);
                shippingCompany = _unitOfWork.ShippingCompanies.Update(shippingCompany);
                _unitOfWork.Complete();
                return ServiceResult<ShippingCompanyDataTransferObject>.SuccessResult(shippingCompanyDataTransferObject);
            }
            catch (Exception ex)
            {
                return ServiceResult<ShippingCompanyDataTransferObject>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }
    }
}
