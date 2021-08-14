namespace DiunsaSCM.Core.Entities
{
    public class Store : AuditableEntity
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string BackStoreLocationCode { get; set; }
        public string StoreLocationCode { get; set; }
        public int Number { get; set; }
        public bool IncludedInSKUAnalysis { get; set; }
    }
}