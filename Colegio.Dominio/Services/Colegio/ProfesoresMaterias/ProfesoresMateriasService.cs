using Colegio.Infraestructura.Colegio.Repositorios;
using Colegio.Infraestructura.Database.Entidades.ProfesoresMaterias;

namespace Colegio.Dominio.Services.Colegio.ProfesoresMaterias
{
    public class ProfesoresMateriasService
    {
        private readonly ICrudRepository<ProfesorMateriaEntities> _crudRepository;
        public ProfesoresMateriasService(ICrudRepository<ProfesorMateriaEntities>crudRepository)
        {
            _crudRepository = crudRepository;
        }
    }
}
