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
    
    public partial class Employee
    {
        public int EntityId { get; set; }
        public string NetId { get; set; }
        public string Barcode { get; set; }
        public string PinHash { get; set; }
        public string PinSalt { get; set; }
        public System.DateTime FirstHiredDate { get; set; }
        public Nullable<bool> CurrentFlag { get; set; }
        public Nullable<int> OtherOnCampusJobHours { get; set; }
        public System.Guid rowguid { get; set; }
        public System.DateTime ModifiedDate { get; set; }
    
        public virtual Entity Entity { get; set; }
    }
}
