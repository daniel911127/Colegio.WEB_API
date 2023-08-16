using Colegio.Infraestructura.Database.Contexto;
using Colegio.Infraestructura.Database.Entidades.Profesores;
using Microsoft.EntityFrameworkCore;

namespace Colegio.Infraestructura.Colegio.Repositorios
{
    public class ProfesoresRepository:ICrudRepository<ProfesorEntities>
    {
        private readonly ApplicationContext _context;
        public ProfesoresRepository(ApplicationContext context) 
        {
            _context = context;
        }

        public async Task<ProfesorEntities> Create(ProfesorEntities entity)
        {
            _context.Profesores.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteById(int identificacion)
        {
            _context.Remove(await GetById(identificacion));
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<List<ProfesorEntities>> GetAll()
        {
            return await _context.Profesores.ToListAsync();
        }

        public async Task<ProfesorEntities> GetById(int identificacion)
        {
            return await _context.Profesores.FindAsync(identificacion);
        }

        public async Task<ProfesorEntities> Update(ProfesorEntities entity)
        {
            _context.Profesores.Update(entity);
            //_context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
