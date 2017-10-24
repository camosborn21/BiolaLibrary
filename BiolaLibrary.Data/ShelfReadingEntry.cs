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
    
    public partial class ShelfReadingEntry
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ShelfReadingEntry()
        {
            this.ShelfReadingQueueProgresses = new HashSet<ShelfReadingQueueProgress>();
        }
    
        public int EntryId { get; set; }
        public int EntityId { get; set; }
        public System.DateTime EntryDateTime { get; set; }
        public int StartingShelf { get; set; }
        public int FinishingShelf { get; set; }
        public int ShelvesRead { get; set; }
    
        public virtual Entity Entity { get; set; }
        public virtual Shelf Shelf { get; set; }
        public virtual Shelf Shelf1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShelfReadingQueueProgress> ShelfReadingQueueProgresses { get; set; }
    }
}
