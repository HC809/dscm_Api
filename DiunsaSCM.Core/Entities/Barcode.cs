using System;
namespace DiunsaSCM.Core.Entities
{
    public class Barcode : AuditableEntity
    {
        public long Id { get; set; }
        public long Number { get; set; }
        public int ControlDigit { get; set; }
        public string Code { get; set; }

        public long BarcodeBatchId { get; set; }
        public long BarcodeSourceId { get; set; }

        public virtual BarcodeBatch BarcodeBatch { get; set; }
        public virtual BarcodeSource BarcodeSource { get; set; }

        public Barcode(long number) {
            Number = number;
            this.CalculateControlDigit();
            Code = String.Format("{0}{1}",Number,ControlDigit);
        }

        public void CalculateControlDigit() {
            int oddSum = 0;
            int evenSum = 0;

            string numberStr = Number.ToString();
            for (int i = 0; i < numberStr.Length; i++)
            {
                int digit = (int)Char.GetNumericValue(numberStr[i]);
                if (i % 2 == 0)
                {
                    evenSum += digit;
                }
                else
                {
                    oddSum += digit;
                }
            }

            var totalSum = (oddSum * 3) + evenSum;
            var mod = totalSum % 10;
            ControlDigit = 10 - mod;
            if (ControlDigit == 10)
            {
                ControlDigit = 0;
            }
        }
    }
}
