using AutoMapper;
using Colegio.Comunes.Clases.Constants;
using Colegio.Comunes.Clases.Contracts.Colegio.Profesores;
using Colegio.Comunes.Clases.Contracts.Colegio.ProfesoresMaterias;
using Colegio.Dominio.Services.Colegio.Common;
using Colegio.Infraestructura.Colegio.Repositorios;
using Colegio.Infraestructura.Database.Entidades.Materias;
using Colegio.Infraestructura.Database.Entidades.Profesores;
using Colegio.Infraestructura.Database.Entidades.ProfesoresMaterias;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace Colegio.Dominio.Services.Colegio.ProfesoresMaterias
{
    public class ProfesoresMateriasService:ICrudService<ProfesoresMateriasContract>
    {
        private readonly ICrudRepository<ProfesorMateriaEntities> _crudRepository;
        private readonly IMapper _mapper;
        public ProfesoresMateriasService(ICrudRepository<ProfesorMateriaEntities>crudRepository,IMapper mapper)
        {
            _crudRepository = crudRepository;
            _mapper = mapper;
            
        }

        public async Task<ProfesoresMateriasContract> CreateAsync(ProfesoresMateriasContract contract)
        {
            List<ProfesorMateriaEntities> listado = await _crudRepository.GetAll();
            if (listado.Any())
            {
                ProfesorMateriaEntities materia = listado.FirstOrDefault(x => x.codigo_materia == contract.codigo_materia);
                if (materia == null)
                {
                    return _mapper.Map<ProfesoresMateriasContract>(await _crudRepository.Create(_mapper.Map<ProfesorMateriaEntities>(contract)));
                }
                else
                {
                    throw new ValidationException(ProfesoresMateriasConstantes.MSG_PROFESORMATERIA_ENCONTRADO);
                }
            }
            else
            {
                return _mapper.Map<ProfesoresMateriasContract>(await _crudRepository.Create(_mapper.Map<ProfesorMateriaEntities>(contract)));
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _crudRepository.DeleteById(id);
        }

        public async Task<List<ProfesoresMateriasContract>> GetAllAsync()
        {
            List<ProfesorMateriaEntities> profesormateriaEntities = await _crudRepository.GetAll();
            return _mapper.Map<List<ProfesoresMateriasContract>>(profesormateriaEntities);
        }

        public async Task<ProfesoresMateriasContract> GetByIdAsync(int id)
        {
            ProfesorMateriaEntities profesormateriaEntities = await _crudRepository.GetById(id);
            return _mapper.Map<ProfesoresMateriasContract>(profesormateriaEntities);
        }

        public async Task<ProfesoresMateriasContract> UpdateAsync(ProfesoresMateriasContract contract)
        {
            ProfesorMateriaEntities profesormateriaEntities = await _crudRepository.GetById(contract.id);
            if (profesormateriaEntities != null)
            {      
                profesormateriaEntities.identificacion_profesor = profesormateriaEntities.identificacion_profesor;
                profesormateriaEntities.codigo_materia = profesormateriaEntities.identificacion_profesor;
                profesormateriaEntities = await _crudRepository.Update(profesormateriaEntities);
                return _mapper.Map<ProfesoresMateriasContract>(profesormateriaEntities);
            }
            else
            {
                throw new ValidationException(ProfesoresMateriasConstantes.MSG_PROFESORMATERIA_NO_ENCONTRADO);
            }
        }
    }
}
