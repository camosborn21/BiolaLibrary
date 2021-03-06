//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BiolaLibrary.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class EntityIdentification
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EntityIdentification()
        {
            this.IDCharacteristics = new HashSet<IDCharacteristic>();
        }
    
        public int EntityIdentificationId { get; set; }
        public int IDType { get; set; }
        public int EntityId { get; set; }
        public string IDValue { get; set; }
        public System.Guid rowguid { get; set; }
        public System.DateTime ModifiedDate { get; set; }
    
        public virtual Entity Entity { get; set; }
        public virtual EntityIDType EntityIDType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IDCharacteristic> IDCharacteristics { get; set; }
    }
}
