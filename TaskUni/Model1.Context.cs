﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class UniTaskEntities : DbContext
    {
        public UniTaskEntities()
            : base("name=UniTaskEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Attender> Attenders { get; set; }
        public virtual DbSet<conference> conferences { get; set; }
        public virtual DbSet<conference_attenders> conference_attenders { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}