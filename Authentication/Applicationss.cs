//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Authentication
{
    using System;
    using System.Collections.Generic;
    
    public partial class Applicationss
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Applicationss()
        {
            this.ApplicationMenus = new HashSet<ApplicationMenu>();
        }
    
        public string Application_Code { get; set; }
        public string Application_Name { get; set; }
        public string Application_URL { get; set; }
        public string Application_Des { get; set; }
        public string Application_Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ApplicationMenu> ApplicationMenus { get; set; }
    }
}