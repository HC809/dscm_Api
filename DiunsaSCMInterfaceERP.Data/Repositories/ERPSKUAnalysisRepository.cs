using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiunsaSCMInterfaceERP.Core;
using DiunsaSCMInterfaceERP.Core.Entities;
using DiunsaSCMInterfaceERP.Core.Models;
using DiunsaSCMInterfaceERP.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DiunsaSCMInterfaceERP.Data.Repositories
{
    public class ERPSKUAnalysisRepository : IERPRepository<ERPSKUAnalysis>
    {
        private readonly DiunsaSCMInterfaceERPContext _context;

        public ERPSKUAnalysisRepository(DiunsaSCMInterfaceERPContext context)
        {
            _context = context;
        }

        public Task<ERPSKUAnalysis> AddAsync(ERPSKUAnalysis entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ERPSKUAnalysis> All()
        {
            return _context.ERPSKUAnalysis.FromSqlRaw("EXECUTE dbo.SP_SCM_GetERPSKUAnalysis");
        }

        public IQueryable<ERPSKUAnalysis> All(string searchString)
        {
            var searchStr = new SqlParameter("searchStr", searchString);
            return _context.ERPSKUAnalysis.FromSqlRaw("EXECUTE dbo.SP_SCM_GetERPSKUAnalysis @searchStr=@searchStr", searchStr);
        }

        public IQueryable<ERPSKUAnalysis> AllByFilterModel(ERPFilterBaseDTO filterModel)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Item", typeof(string));

            ERPFilterSKUAnalysisDTO erpFilterSKYAnalysisDTO = (ERPFilterSKUAnalysisDTO)filterModel;

            foreach (string str in erpFilterSKYAnalysisDTO.Barcodes)
            {
                dataTable.Rows.Add(str);
            }
            SqlParameter searchStrListParam = new SqlParameter("searchStrListParam", dataTable);
            searchStrListParam.SqlDbType = SqlDbType.Structured;
            searchStrListParam.TypeName = "dbo.StringList";

            object[] parameters = {
                searchStrListParam,
                new SqlParameter("fromDate", erpFilterSKYAnalysisDTO.FromDate),
                new SqlParameter("toDate", erpFilterSKYAnalysisDTO.ToDate),
            };

            return _context.ERPSKUAnalysis.FromSqlRaw("EXECUTE dbo.SP_SCM_GetERPSKUAnalysisByList @list=@searchStrListParam, @fromDate=@fromDate, @toDate=@toDate", parameters);
        }

        public IQueryable<ERPSKUAnalysis> AllByParent(long parent)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ERPSKUAnalysis> ExecuteActionAsync(string action, object[] args)
        {
            throw new NotImplementedException();
        }

        public ERPSKUAnalysis GetById(long id)
        {
            return _context.ERPSKUAnalysis.FromSqlRaw("EXECUTE dbo.SP_SCM_GetERPSKUAnalysis @recId", id).FirstOrDefault(x => x.Id == id); ;
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Task<ERPSKUAnalysis> UpdatAsync(ERPSKUAnalysis entity)
        {
            throw new NotImplementedException();
        }

    }
}
