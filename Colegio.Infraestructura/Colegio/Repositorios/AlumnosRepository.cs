using Colegio.Infraestructura.Database.Contexto;
using Colegio.Infraestructura.Database.Entidades.Alumnos;
using Colegio.Infraestructura.Database.Entidades.Profesores;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Infraestructura.Colegio.Repositorios
{
    public class AlumnosRepository:ICrudRepository<AlumnoEntities>
    {
        private readonly ApplicationContext _context;
        public AlumnosRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<AlumnoEntities> Create(AlumnoEntities entity)
        {
            _context.Alumnos.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteById(int identificacion)
        {
            _context.Remove(await GetById(identificacion));
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<List<AlumnoEntities>> GetAll()
        {
            return await _context.Alumnos.ToListAsync();
        }

        public async Task<AlumnoEntities> GetById(int identificacion)
        {
            return await _context.Alumnos.FindAsync(identificacion);
        }

        public async Task<AlumnoEntities> Update(AlumnoEntities entity)
        {
            _context.Alumnos.Update(entity);
            //_context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
