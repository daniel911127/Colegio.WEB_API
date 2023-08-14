using Colegio.Infraestructura.Colegio.Repositorios;
using Colegio.Infraestructura.Database.Entidades.Profesores;

namespace Colegio.Dominio.Services.Colegio.Profesores
{
    public class ProfesoresService
    {
        private readonly ICrudRepository<ProfesorEntities> _crudRespository;
        public ProfesoresService(ICrudRepository<ProfesorEntities> crudRespository)
        {
            _crudRespository = crudRespository;
        }
    }
}
