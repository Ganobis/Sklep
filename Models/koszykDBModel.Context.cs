﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sklep.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SklepDB_Entities : DbContext
    {
        public SklepDB_Entities()
            : base("name=SklepDB_Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Kategorie> Kategorie { get; set; }
        public virtual DbSet<Przedmioty> Przedmioty { get; set; }
        public virtual DbSet<Hasla> Hasla { get; set; }
        public virtual DbSet<Uzytkownicy> Uzytkownicy { get; set; }
        public virtual DbSet<SzczegolyZamownienia> SzczegolyZamownienia { get; set; }
        public virtual DbSet<Zamowienia> Zamowienia { get; set; }
    }
}
