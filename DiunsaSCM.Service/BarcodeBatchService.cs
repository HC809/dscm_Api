using System;
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
    public class BarcodeBatchService : ServiceBase<BarcodeBatch, BarcodeBatchDTO>, IBarcodeBatchService
    {
        public BarcodeBatchService(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryBase<BarcodeBatch> repository)
            : base(mapper, unitOfWork, repository)
        {
        }

        public virtual ServiceResult<BarcodeBatchDTO> Add(BarcodeBatchDTO model)
        {
            try
            {
                var entity = _mapper.Map<BarcodeBatch>(model);

                int qtyGenerated = 0;
                var barcodeSources = _unitOfWork.BarcodeSources.All()
                    .Where(x => x.NextAvailable <= x.RangeLast)
                    .OrderBy(x => x.Id)
                    .ToList();

                entity.Barcodes = new System.Collections.Generic.List<Barcode>();

                foreach (var barcodeSource in barcodeSources)
                {
                    while(qtyGenerated < entity.QtyRequested && barcodeSource.NextAvailable != -1)
                    {
                        long barcodeNumber = barcodeSource.NextAvailable;
                        var barcode = new Barcode(barcodeNumber);
                        barcode.BarcodeSourceId = barcodeSource.Id;
                        entity.Barcodes.Add(barcode);

                        barcodeSource.NextAvailable++;
                        if (barcodeSource.NextAvailable > barcodeSource.RangeLast)
                        {
                            barcodeSource.NextAvailable = -1;
                        }
                        qtyGenerated++;
                    }
                }
                entity.QtyGenerated = qtyGenerated;
                entity = _repository.Add(entity);
                _repository.SaveChanges();
                model = _mapper.Map<BarcodeBatchDTO>(entity);
                return ServiceResult<BarcodeBatchDTO>.SuccessResult(model);
            }
            catch (Exception ex)
            {
                return ServiceResult<BarcodeBatchDTO>.ErrorResult("Ha ocurrido un error al ejecutar la operación en la base de datos.");
            }
        }
    }
}
