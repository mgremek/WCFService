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
    
    public partial class clients
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public clients()
        {
            this.Basket = new HashSet<Basket>();
        }
    
        public int client_ID { get; set; }
        public string Name { get; set; }
        public string Pass { get; set; }
        public string Login { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public string phonenumber { get; set; }
        public System.DateTime DateInSystem { get; set; }
        public string Email { get; set; }
        public string OtherXML { get; set; }
        public int City_id { get; set; }
        public byte[] Hashed { get; set; }
        public string PasswordProxy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Basket> Basket { get; set; }
    }
}
