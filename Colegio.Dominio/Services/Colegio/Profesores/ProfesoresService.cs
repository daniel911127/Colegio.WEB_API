using AutoMapper;
using Colegio.Comunes.Clases.Constants;
using Colegio.Comunes.Clases.Contracts.Colegio.Profesores;
using Colegio.Dominio.Services.Colegio.Common;
using Colegio.Infraestructura.Colegio.Repositorios;
using Colegio.Infraestructura.Database.Entidades.Profesores;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Colegio.Dominio.Services.Colegio.Profesores
{
    public class ProfesoresService : ICrudService<ProfesoresContract>
    {
        private readonly ICrudRepository<ProfesorEntities> _crudRepository;
        private readonly IMapper _mapper;
        public ProfesoresService(ICrudRepository<ProfesorEntities> crudRepository, IMapper mapper)
        {
            _crudRepository = crudRepository;
            _mapper = mapper;
        }

        public async Task<ProfesoresContract> CreateAsync(ProfesoresContract contract)
        {
            List<ProfesorEntities> profesores = await _crudRepository.GetAll();
            if (profesores.Any())
            {
                ProfesorEntities profesor = profesores.FirstOrDefault(x => x.identificacion == contract.identificacion);
                if (profesor == null)
                {
                    return _mapper.Map<ProfesoresContract>(await _crudRepository.Create(_mapper.Map<ProfesorEntities>(contract)));
                }
                else
                {
                    throw new ValidationException(ProfesoresConstantes.MSG_PROFESOR_ENCONTRADO);
                }
            }
            else
            {
                return _mapper.Map<ProfesoresContract>(await _crudRepository.Create(_mapper.Map<ProfesorEntities>(contract)));
            }

        }

        public async Task<bool> DeleteAsync(int identificacion)
        {
            return await _crudRepository.DeleteById(identificacion);
        }

        public async Task<List<ProfesoresContract>> GetAllAsync()
        {
            List<ProfesorEntities> profesorEntities = await _crudRepository.GetAll();
            return _mapper.Map<List<ProfesoresContract>>(profesorEntities);
        }

        public async Task<ProfesoresContract> GetByIdAsync(int identificacion)
        {
            ProfesorEntities profesorEntities = await _crudRepository.GetById(identificacion);
            return _mapper.Map<ProfesoresContract>(profesorEntities);
        }

        public async Task<ProfesoresContract> UpdateAsync(ProfesoresContract contract)
        {
            ProfesorEntities profesorEntities = await _crudRepository.GetById(contract.identificacion);
            if (profesorEntities != null)
            {
                profesorEntities.identificacion = contract.identificacion;
                profesorEntities.nombre = contract.nombre;
                profesorEntities.apellido = contract.apellido;
                profesorEntities.edad = contract.edad;
                profesorEntities.direccion = contract.direccion;
                profesorEntities.telefono = contract.telefono;
                profesorEntities = await _crudRepository.Update(profesorEntities);
                return _mapper.Map<ProfesoresContract>(profesorEntities);
            }
            else
            {
                throw new ValidationException(ProfesoresConstantes.MSG_PROFESOR_NO_ENCONTRADO);
            }
        }
    }
}
