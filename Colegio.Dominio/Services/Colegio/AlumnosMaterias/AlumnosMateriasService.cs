using Colegio.Infraestructura.Colegio.Repositorios;
using Colegio.Infraestructura.Database.Entidades.AlumnosMaterias;

namespace Colegio.Dominio.Services.Colegio.AlumnosMaterias
{
    public class AlumnosMateriasService
    {
        private readonly ICrudRepository<AlumnoMateriaEntities> _crudRepository;
        public AlumnosMateriasService(ICrudRepository<AlumnoMateriaEntities> crudRepository)
        {
            _crudRepository = crudRepository;
        }
    }
}
