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
    
    public partial class Shelf
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Shelf()
        {
            this.InventoryEntries = new HashSet<InventoryEntry>();
            this.InventoryEntries1 = new HashSet<InventoryEntry>();
            this.InventoryQueues = new HashSet<InventoryQueue>();
            this.InventoryQueues1 = new HashSet<InventoryQueue>();
            this.ShelfReadingEntries = new HashSet<ShelfReadingEntry>();
            this.ShelfReadingEntries1 = new HashSet<ShelfReadingEntry>();
            this.ShelfReadingQueues = new HashSet<ShelfReadingQueue>();
            this.ShelfReadingQueues1 = new HashSet<ShelfReadingQueue>();
            this.ShiftingEntries = new HashSet<ShiftingEntry>();
            this.ShiftingEntries1 = new HashSet<ShiftingEntry>();
            this.ShiftingEntries2 = new HashSet<ShiftingEntry>();
            this.ShiftingEntries3 = new HashSet<ShiftingEntry>();
            this.ShiftingQueues = new HashSet<ShiftingQueue>();
            this.ShiftingQueues1 = new HashSet<ShiftingQueue>();
        }
    
        public int ShelfId { get; set; }
        public int ColumnId { get; set; }
        public int ShelfNumber { get; set; }
        public Nullable<bool> IsReturnShelf { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InventoryEntry> InventoryEntries { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InventoryEntry> InventoryEntries1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InventoryQueue> InventoryQueues { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InventoryQueue> InventoryQueues1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShelfReadingEntry> ShelfReadingEntries { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShelfReadingEntry> ShelfReadingEntries1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShelfReadingQueue> ShelfReadingQueues { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShelfReadingQueue> ShelfReadingQueues1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShiftingEntry> ShiftingEntries { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShiftingEntry> ShiftingEntries1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShiftingEntry> ShiftingEntries2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShiftingEntry> ShiftingEntries3 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShiftingQueue> ShiftingQueues { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShiftingQueue> ShiftingQueues1 { get; set; }
        public virtual Column Column { get; set; }
    }
}