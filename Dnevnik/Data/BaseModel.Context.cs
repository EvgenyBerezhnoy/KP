//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dnevnik.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AcademicEntitiesControl : DbContext
    {
        private static AcademicEntitiesControl context;

        public static AcademicEntitiesControl getContext()
        {
            if (context == null)
                context = new AcademicEntitiesControl();
            return context;
        }

        public AcademicEntitiesControl()
            : base("name=AcademicEntitiesControl")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Faculties> Faculties { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<LoginHistory> LoginHistory { get; set; }
        public virtual DbSet<Rate> Rate { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
