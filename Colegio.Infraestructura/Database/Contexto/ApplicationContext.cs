using Colegio.Infraestructura.Database.Entidades.Alumnos;
using Colegio.Infraestructura.Database.Entidades.AlumnosMaterias;
using Colegio.Infraestructura.Database.Entidades.Materias;
using Colegio.Infraestructura.Database.Entidades.Profesores;
using Colegio.Infraestructura.Database.Entidades.ProfesoresMaterias;
using Microsoft.EntityFrameworkCore;

namespace Colegio.Infraestructura.Database.Contexto
{
    public class ApplicationContext : DbContext
    {
        #region DBSets
        public virtual DbSet<ProfesorEntities>Profesores {get;set;}
        public virtual DbSet<AlumnoEntities> Alumnos{get;set;}
        public virtual DbSet<MateriaEntities>Materias{ get; set; }
        public virtual DbSet<AlumnoMateriaEntities>Alumnosmaterias{ get; set; }
        public virtual DbSet<ProfesorMateriaEntities>Profesoresmaterias{ get; set; }
        #endregion

        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options) 
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
    }
}
