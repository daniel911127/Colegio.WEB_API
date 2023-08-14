using Colegio.Infraestructura.Database.Contexto;
using Colegio.Infraestructura.Database.Entidades.AlumnosMaterias;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Infraestructura.Colegio.Repositorios
{
    public class AlumnosMateriasRepository:ICrudRepository<AlumnoMateriaEntities>
    {
        private readonly ApplicationContext _context;
        public AlumnosMateriasRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<AlumnoMateriaEntities> Create(AlumnoMateriaEntities entity)
        {
            _context.Alumnosmaterias.Add(entity);
            await _context.SaveChangesAsync();
            return entity; ;
        }

        public async Task<bool> DeleteById(int id)
        {
            _context.Remove(id);
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<List<AlumnoMateriaEntities>> GetAll()
        {
            return await _context.Alumnosmaterias.ToListAsync();
        }

        public async Task<AlumnoMateriaEntities> GetById(int id)
        {
            return await _context.Alumnosmaterias.FindAsync(id);
        }

        public async Task<AlumnoMateriaEntities> Update(AlumnoMateriaEntities entity)
        {
            _context.Alumnosmaterias.Update(entity);
            //_context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
