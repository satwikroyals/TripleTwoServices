//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TripleTwo.edmx
{
    using System;
    using System.Collections.Generic;
    
    public partial class Business
    {
        public int BusinessId { get; set; }
        public string BusinessName { get; set; }
        public Nullable<int> BusinessTypeId { get; set; }
        public string BusinessLogo { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactMobile { get; set; }
        public string ContactEmail { get; set; }
        public string Location { get; set; }
        public Nullable<int> CountryId { get; set; }
        public string OtherInfo { get; set; }
        public string ABN { get; set; }
        public string WebSiteUrl { get; set; }
        public Nullable<int> IsActive { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    }
}
