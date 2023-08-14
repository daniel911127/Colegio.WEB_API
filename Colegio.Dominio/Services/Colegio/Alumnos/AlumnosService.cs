using Colegio.Infraestructura.Colegio.Repositorios;
using Colegio.Infraestructura.Database.Entidades.Alumnos;

namespace Colegio.Dominio.Services.Colegio.Alumnos
{
    public class AlumnosService
    {
        private readonly ICrudRepository<AlumnoEntities> _crudRepository;
        public AlumnosService(ICrudRepository<AlumnoEntities> crudRepository)
        {
            _crudRepository = crudRepository;
        }
    }
}
