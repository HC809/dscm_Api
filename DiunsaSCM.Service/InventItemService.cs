using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Services;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Repositories;
using System.Threading.Tasks;

namespace DiunsaSCM.Service
{
    public class InventItemService : ServiceBase<InventItem, InventItemDTO>, IInventItemService
    {
        public InventItemService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<InventItem> repository)
            : base(mapper, unitOfWork, repository)
        {
        }
    }


    /*public class InventItemService : IInventItemService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        private readonly IERPInventItemService _eRPInventItemService;

        public InventItemService(IMapper mapper, IUnitOfWork unitOfWork, IERPInventItemService eRPInventItemService)
        {
            this._unitOfWork = unitOfWork;
            this._eRPInventItemService = eRPInventItemService;
            _mapper = mapper;
        }
        public ServiceResult<InventItemDTO> Add(InventItemDTO inventItem)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<IEnumerable<InventItemDTO>> GetAll(string searchString)
        {
            try
            {
                var eRPInventItems = _eRPInventItemService.GetAll(searchString).Data.Select(x => _mapper.Map<InventItemDTO>(x));
                return ServiceResult<IEnumerable<InventItemDTO>>.SuccessResult(eRPInventItems);
            }
            catch (Exception ex)
            {
                return ServiceResult<IEnumerable<InventItemDTO>>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos");
            }


        }
    }*/
}
