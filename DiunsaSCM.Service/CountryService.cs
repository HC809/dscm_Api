using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using DiunsaSCM.Utils;

namespace DiunsaSCM.Service
{
    public class CountryService : ICountryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CountryService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public ServiceResult<CountryDataTransferObject> Add(CountryDataTransferObject countryDataTransferObject)
        {
            try
            {
                var country = _mapper.Map<Country>(countryDataTransferObject);
                country = _unitOfWork.Countries.Add(country);
                _unitOfWork.Complete();
                countryDataTransferObject.Id = country.Id;
                return ServiceResult<CountryDataTransferObject>.SuccessResult(countryDataTransferObject);
            }
            catch (Exception ex)
            {
                return ServiceResult<CountryDataTransferObject>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }

        public ServiceResult<CountryDataTransferObject> Delete(long id)
        {
            try
            {
                var country = _unitOfWork.Countries.GetById(id);
                var countryDataTransferObject = _mapper.Map<CountryDataTransferObject>(country);
                _unitOfWork.Countries.Delete(country);
                _unitOfWork.Complete();
                return ServiceResult<CountryDataTransferObject>.SuccessResult(countryDataTransferObject);
            }
            catch (Exception ex)
            {
                return ServiceResult<CountryDataTransferObject>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }

        public ServiceResult<IEnumerable<CountryDataTransferObject>> GetAll()
        {
            try
            {
                var countries = _unitOfWork.Countries.All();
                var countryDataTransferObject = countries.Select(x => _mapper.Map<CountryDataTransferObject>(x));
                return ServiceResult<IEnumerable<CountryDataTransferObject>>.SuccessResult(countryDataTransferObject);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<CountryDataTransferObject>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }

        public ServiceResult<CountryDataTransferObject> GetById(long id)
        {
            try
            {
                var country = _unitOfWork.Countries.GetById(id);
                var countryDataTransferObject = _mapper.Map<CountryDataTransferObject>(country);
                return ServiceResult<CountryDataTransferObject>.SuccessResult(countryDataTransferObject);
            }
            catch (Exception ex)
            {
                return ServiceResult<CountryDataTransferObject>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }

        public ServiceResult<CountryDataTransferObject> Update(CountryDataTransferObject countryDataTransferObject)
        {
            try
            {
                var country = _mapper.Map<Country>(countryDataTransferObject);
                country = _unitOfWork.Countries.Update(country);
                _unitOfWork.Complete();
                return ServiceResult<CountryDataTransferObject>.SuccessResult(countryDataTransferObject);
            }
            catch (Exception ex)
            {
                return ServiceResult<CountryDataTransferObject>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }
        }

    }
}
