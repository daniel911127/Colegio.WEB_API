using Colegio.Infraestructura.Database.Contexto;
using Colegio.Infraestructura.Database.Entidades.ProfesoresMaterias;
using Microsoft.EntityFrameworkCore;

namespace Colegio.Infraestructura.Colegio.Repositorios
{
    public class ProfesoresMateriasRepository:ICrudRepository<ProfesorMateriaEntities>
    {
        private readonly ApplicationContext _context;
        public ProfesoresMateriasRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<ProfesorMateriaEntities> Create(ProfesorMateriaEntities entity)
        {
            _context.Profesoresmaterias.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteById(int id)
        {
            _context.Remove(id);
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<List<ProfesorMateriaEntities>> GetAll()
        {
            return await _context.Profesoresmaterias.ToListAsync();
        }

        public async Task<ProfesorMateriaEntities> GetById(int id)
        {
            return await _context.Profesoresmaterias.FindAsync(id);
        }
        public async Task<ProfesorMateriaEntities> Update(ProfesorMateriaEntities entity)
        {
            _context.Profesoresmaterias.Update(entity);
            //_context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
