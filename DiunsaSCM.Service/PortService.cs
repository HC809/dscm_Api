using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using DiunsaSCM.Utils;
using Microsoft.EntityFrameworkCore;

namespace DiunsaSCM.Service
{
    public class PortService : IPortService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PortService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public ServiceResult<PortDataTransferObject> Add(PortDataTransferObject portDataTransferObject)
        {
            try
            {
                var port = _mapper.Map<Port>(portDataTransferObject);
                port = _unitOfWork.Ports.Add(port);
                _unitOfWork.Complete();
                portDataTransferObject.Id = port.Id;
                return ServiceResult<PortDataTransferObject>.SuccessResult(portDataTransferObject);
            }
            catch (Exception ex)
            {
                return ServiceResult<PortDataTransferObject>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
            
        }

        public ServiceResult<PortDataTransferObject> Delete(long id)
        {
            try
            {
                var port = _unitOfWork.Ports.GetById(id);
                var shippingCompanyDataTransferObject = _mapper.Map<PortDataTransferObject>(port);
                _unitOfWork.Ports.Delete(port);
                _unitOfWork.Complete();
                return ServiceResult<PortDataTransferObject>.SuccessResult(shippingCompanyDataTransferObject);
            }
            catch (Exception ex)
            {
                return ServiceResult<PortDataTransferObject>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
            
        }

        public ServiceResult<IEnumerable<PortDataTransferObject>> GetAll()
        {
            try
            {
                var ports = _unitOfWork.Ports.All().Include(x => x.Country);
                var portDataTransferObject = ports.Select(x => _mapper.Map<PortDataTransferObject>(x));
                return ServiceResult<IEnumerable<PortDataTransferObject>>.SuccessResult(portDataTransferObject);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable< PortDataTransferObject >>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
            
        }

        public ServiceResult<PortDataTransferObject> GetById(long id)
        {
            try
            {
                var port = _unitOfWork.Ports.GetById(id);
                var portDataTransferObject = _mapper.Map<PortDataTransferObject>(port);
                return ServiceResult<PortDataTransferObject>.SuccessResult(portDataTransferObject);
            }
            catch (Exception ex)
            {
                return ServiceResult<PortDataTransferObject>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
            
        }

        public ServiceResult<PortDataTransferObject> Update(PortDataTransferObject portDataTransferObject)
        {
            try
            {
                var port = _mapper.Map<Port>(portDataTransferObject);
                port = _unitOfWork.Ports.Update(port);
                _unitOfWork.Complete();
                return ServiceResult<PortDataTransferObject>.SuccessResult(portDataTransferObject);
            }
            catch (Exception ex)
            {
                return ServiceResult<PortDataTransferObject>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
            
        }
    }
}
