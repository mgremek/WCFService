//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProduktyService
{
    using System;
    using System.Collections.Generic;
    
    public partial class Basket
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Basket()
        {
            this.BasketItems = new HashSet<BasketItems>();
        }
    
        public int BasketId { get; set; }
        public Nullable<int> ClientId { get; set; }
        public Nullable<int> BasketStatusId { get; set; }
    
        public virtual BasketStatusCode BasketStatusCode { get; set; }
        public virtual clients clients { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BasketItems> BasketItems { get; set; }
    }
}