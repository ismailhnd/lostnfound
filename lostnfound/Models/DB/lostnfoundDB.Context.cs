//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace lostnfound.Models.DB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class lostfoundDB : DbContext
    {
        public lostfoundDB()
            : base("name=lostfoundDB")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CATEGORY> CATEGORies { get; set; }
        public virtual DbSet<COLOR> COLORs { get; set; }
        public virtual DbSet<ITEM> ITEMs { get; set; }
        public virtual DbSet<ITEMSTATE> ITEMSTATEs { get; set; }
        public virtual DbSet<ITEMTYPE> ITEMTYPEs { get; set; }
        public virtual DbSet<LOCATION> LOCATIONs { get; set; }
        public virtual DbSet<PERMISSION> PERMISSIONs { get; set; }
        public virtual DbSet<PRIVILEGE> PRIVILEGEs { get; set; }
        public virtual DbSet<REPORTER> REPORTERs { get; set; }
        public virtual DbSet<ROLE> ROLEs { get; set; }
        public virtual DbSet<STATE> STATEs { get; set; }
        public virtual DbSet<USER> USERs { get; set; }
    }
}