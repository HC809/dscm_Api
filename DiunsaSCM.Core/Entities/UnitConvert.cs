using System;
using System.ComponentModel.DataAnnotations.Schema;
using DiunsaSCM.Utils;

namespace DiunsaSCM.Core.Entities
{
    public class UnitConvert : AuditableEntity
    {
        public long Id { get; set; }
        public long ERPRecId { get; set; }

        public long InventItemId { get; set; }
        public long FromUnitId { get; set; }
        public long ToUnitId { get; set; }
        public decimal Factor { get; set; }

        public decimal GrossDepth { get; set; }
        public decimal GrossWidth { get; set; }
        public decimal GrossHeight { get; set; }
        public decimal GrossWeight { get; set; }

        [ForeignKey("FromUnitId")]
        public virtual Unit FromUnit { get; set; }
        [ForeignKey("ToUnitId")]
        public virtual Unit ToUnit { get; set; }

        public virtual InventItem InventItem { get; set; }

        public ServiceResult<UnitConvert> ValidateWrite()
        {
            if (Factor == 0)
                ServiceResult<UnitConvert>.ErrorResult("No se ha definido correctamente el factor de conversión.");
            if (GrossDepth == 0)
                ServiceResult<UnitConvert>.ErrorResult("No se ha definido correctamente el campo grosor.");
            if (GrossHeight == 0)
                ServiceResult<UnitConvert>.ErrorResult("No se ha definido correctamente el campo altura.");
            if (GrossWidth == 0)
                ServiceResult<UnitConvert>.ErrorResult("No se ha definido correctamente el campo anchura.");
            if (GrossWeight == 0)
                ServiceResult<UnitConvert>.ErrorResult("No se ha definido correctamente el campo peso.");

            return ServiceResult<UnitConvert>.SuccessResult(this);
        }
    }
}
