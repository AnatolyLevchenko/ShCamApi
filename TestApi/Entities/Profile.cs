using System;

namespace TestApi.Entities
{
    public class Profile:BaseEntity
    {
        public string Name { get; set; }
        public string Lib { get; set; }
        public string Renfort { get; set; }
        public string Type { get; set; }
        public string Info { get; set; }
        public decimal Y { get; set; }
        public decimal Z { get; set; }
        public decimal Klem { get; set; }
        public decimal Zaag { get; set; }
        public decimal Verval { get; set; }

        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public bool Redefine { get; set; }
        public bool Active { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime CreatedOnUtc { get; set; }
        public DateTime UpdatedOnUtc { get; set; }
        public DateTime DeletedOnUtc { get; set; }
    }
}