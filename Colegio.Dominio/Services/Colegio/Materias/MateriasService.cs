using Colegio.Infraestructura.Colegio.Repositorios;
using Colegio.Infraestructura.Database.Entidades.Materias;

namespace Colegio.Dominio.Services.Colegio.Materias
{
    public class MateriasService
    {
        private readonly ICrudRepository<MateriaEntities> _crudRepository;
        public MateriasService(ICrudRepository<MateriaEntities> crudRepository)
        {
            _crudRepository = crudRepository;
        }
    }
}
