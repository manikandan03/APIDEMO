﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KlassaktWebApi.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class LMSContentEntities : DbContext
    {
        public LMSContentEntities()
            : base("name=LMSContentEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Master_Course> Master_Course { get; set; }
        public virtual DbSet<QAOfSection> QAOfSections { get; set; }
        public virtual DbSet<SectionsOfUnit> SectionsOfUnits { get; set; }
        public virtual DbSet<UnitsOfCourse> UnitsOfCourses { get; set; }
        public virtual DbSet<UserDetail> UserDetails { get; set; }
    
        public virtual int spDropTableAndConstraints(string tableName)
        {
            var tableNameParameter = tableName != null ?
                new ObjectParameter("TableName", tableName) :
                new ObjectParameter("TableName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spDropTableAndConstraints", tableNameParameter);
        }
    }
}