//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DibumiLaptopWEBV2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class item_stok
    {
        public long id { get; set; }
        public Nullable<long> item_id { get; set; }
        public string type { get; set; }
        public Nullable<long> stok { get; set; }
    
        public virtual item item { get; set; }
    }
}