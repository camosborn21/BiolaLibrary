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
    
    public partial class InventoryQueue
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InventoryQueue()
        {
            this.InventoryQueueProgresses = new HashSet<InventoryQueueProgress>();
        }
    
        public int QueueId { get; set; }
        public int StartingShelf { get; set; }
        public int FinisingShelf { get; set; }
        public int OrderNumber { get; set; }
        public Nullable<System.DateTime> DateTimeProgressStart { get; set; }
        public Nullable<int> EntityId { get; set; }
    
        public virtual Entity Entity { get; set; }
        public virtual Shelf Shelf { get; set; }
        public virtual Shelf Shelf1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InventoryQueueProgress> InventoryQueueProgresses { get; set; }
    }
}