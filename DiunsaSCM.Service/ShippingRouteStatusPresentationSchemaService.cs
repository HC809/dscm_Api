using System;
using AutoMapper;
using DiunsaSCM.Core;
using DiunsaSCM.Core.Entities;
using DiunsaSCM.Core.Models;
using DiunsaSCM.Core.Repositories;
using DiunsaSCM.Core.Services;

namespace DiunsaSCM.Service
{
    public class ShippingRouteStatusPresentationSchemaService : ServiceBase<ShippingRouteStatusPresentationSchema, ShippingRouteStatusPresentationSchemaDTO>, IShippingRouteStatusPresentationSchemaService
    {
        public ShippingRouteStatusPresentationSchemaService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<ShippingRouteStatusPresentationSchema> repository)
            : base(mapper, unitOfWork, repository)
        {
        }
    }
}