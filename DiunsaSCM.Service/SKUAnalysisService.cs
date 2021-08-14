using System;
using AutoMapper;
using DiunsaSCM.Core;
using  DiunsaSCM.Core.Entities;
using  DiunsaSCM.Core.Models;
using  DiunsaSCM.Core.Repositories;
using  DiunsaSCM.Core.Services;

namespace  DiunsaSCM.Service
{
    public class SKUAnalysisService : ServiceBase<SKUAnalysis, SKUAnalysisDTO>, ISKUAnalysisService
    {
        public SKUAnalysisService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<SKUAnalysis> repository)
            : base(mapper, unitOfWork, repository)
        {
        }
    }
}
