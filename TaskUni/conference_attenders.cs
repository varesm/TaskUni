//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TaskUni
{
    using System;
    using System.Collections.Generic;
    
    public partial class conference_attenders
    {
        public int id { get; set; }
        public Nullable<int> conference_id { get; set; }
        public Nullable<int> user_id { get; set; }
        public Nullable<bool> isAccepted { get; set; }
    
        public virtual Attender Attender { get; set; }
        public virtual conference conference { get; set; }
    }
}
