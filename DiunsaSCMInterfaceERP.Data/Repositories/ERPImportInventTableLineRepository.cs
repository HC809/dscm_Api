using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiunsaSCMInterfaceERP.Core;
using DiunsaSCMInterfaceERP.Core.Entities;
using DiunsaSCMInterfaceERP.Core.Models;
using DiunsaSCMInterfaceERP.Core.Repositories;
using Microsoft.Extensions.Configuration;

namespace DiunsaSCMInterfaceERP.Data.Repositories
{
    public class ERPImportInventTableLineRepository : IERPRepository<ERPImportInventTableLine>
    {
        private readonly DiunsaSCMInterfaceERPContext _context;

        public ERPImportInventTableLineRepository(DiunsaSCMInterfaceERPContext context)
        {
            _context = context;
        }

        public async Task<ERPImportInventTableLine> AddAsync(ERPImportInventTableLine entity)
        {
            var apiURI = _context._configuration.GetConnectionString("API_URI");
            ERPInterface eRPInterface = new ERPInterface(apiURI);
            object[] args = {
                entity.ParentRecId,
                entity.ItemId,
                entity.InventDimGroupId,
                entity.NameAlias,
                entity.ItemBarcode,
                entity.InventSizeId,
                entity.SizeName,
                entity.InventColorId,
                entity.ColorName,
                entity.ItemName,
                entity.Cantidad,
                entity.Costo,
                entity.GrupoId,
                entity.Accountnum,
                entity.TaxItemGroupId,
                entity.Descontable,
                entity.DescuentoEmpl,
                entity.BrandId,
                entity.ItemUME,
                entity.ClasificacionTemporada,
                entity.CMR_T1,
                entity.CMR_T2,
                entity.CMR_T3,
                entity.CMR_T4,
                entity.CMR_T5,
                entity.CMR_T6,
                entity.CMR_MAY,
                entity.CMR_ECOM,
            };
            var result = await eRPInterface.ExecuteMethod("IDiunsaSCM_ImportInventTableLine", "Add", args);
            entity.Id = Convert.ToInt64(result.CallAXClassMethodResult);
            return entity;
        }

        public IQueryable<ERPImportInventTableLine> All()
        {
            throw new NotImplementedException();
        }

        public IQueryable<ERPImportInventTableLine> All(string searchString)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ERPImportInventTableLine> AllByFilterModel(ERPFilterBaseDTO filterModel)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ERPImportInventTableLine> AllByParent(long parent)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ERPImportInventTableLine> ExecuteActionAsync(string action, object[] args)
        {
            throw new NotImplementedException();
        }

        public ERPImportInventTableLine GetById(long id)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<ERPImportInventTableLine> UpdatAsync(ERPImportInventTableLine entity)
        {
            throw new NotImplementedException();
        }
    }
}
