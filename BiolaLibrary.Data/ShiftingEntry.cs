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
    
    public partial class ShiftingEntry
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ShiftingEntry()
        {
            this.ShiftingQueueProgresses = new HashSet<ShiftingQueueProgress>();
        }
    
        public int EntryId { get; set; }
        public int EntityId { get; set; }
        public System.DateTime EntryDateTime { get; set; }
        public int PullStartingShelf { get; set; }
        public int PullFinishingShelf { get; set; }
        public int PlaceStartingShelf { get; set; }
        public int PlaceFinishingShelf { get; set; }
    
        public virtual Entity Entity { get; set; }
        public virtual Shelf Shelf { get; set; }
        public virtual Shelf Shelf1 { get; set; }
        public virtual Shelf Shelf2 { get; set; }
        public virtual Shelf Shelf3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShiftingQueueProgress> ShiftingQueueProgresses { get; set; }
    }
}
