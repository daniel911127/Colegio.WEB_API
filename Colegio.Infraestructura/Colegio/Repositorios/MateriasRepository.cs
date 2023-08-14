using Colegio.Infraestructura.Database.Contexto;
using Colegio.Infraestructura.Database.Entidades.Materias;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.Infraestructura.Colegio.Repositorios
{
    public class MateriasRepository:ICrudRepository<MateriaEntities>
    {
        private readonly ApplicationContext _context;
        public MateriasRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<MateriaEntities> Create(MateriaEntities entity)
        {
            _context.Materias.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteById(int codigo)
        {
            _context.Remove(codigo);
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<List<MateriaEntities>> GetAll()
        {
            return await _context.Materias.ToListAsync();
        }

        public async Task<MateriaEntities> GetById(int codigo)
        {
            return await _context.Materias.FindAsync(codigo); ;
        }

        public async Task<MateriaEntities> Update(MateriaEntities entity)
        {
            _context.Materias.Update(entity);
            //_context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
