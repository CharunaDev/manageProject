//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApp1.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public Nullable<int> EmployeeId { get; set; }
        public Nullable<bool> Active { get; set; }
        public System.DateTime CreateDate { get; set; }
    
        public virtual tblEmployee tblEmployee { get; set; }
        public virtual tblRole tblRole { get; set; }
    }
}
