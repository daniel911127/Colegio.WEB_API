using AutoMapper;
using Colegio.Comunes.Clases.Constants;
using Colegio.Comunes.Clases.Contracts.Colegio.Alumnos;
using Colegio.Comunes.Clases.Contracts.Colegio.Materias;
using Colegio.Comunes.Clases.Contracts.Colegio.Profesores;
using Colegio.Dominio.Services.Colegio.Common;
using Colegio.Infraestructura.Colegio.Repositorios;
using Colegio.Infraestructura.Database.Entidades.Alumnos;
using Colegio.Infraestructura.Database.Entidades.Materias;
using Colegio.Infraestructura.Database.Entidades.Profesores;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace Colegio.Dominio.Services.Colegio.Materias
{
    public class MateriasService:ICrudService<MateriasContract>
    {
        private readonly ICrudRepository<MateriaEntities> _crudRepository;
        private readonly IMapper _mapper;
        public MateriasService(ICrudRepository<MateriaEntities> crudRepository,IMapper mapper)
        {
            _crudRepository = crudRepository;
            _mapper = mapper;
        }

        public async Task<MateriasContract> CreateAsync(MateriasContract contract)
        {
            List<MateriaEntities> materias = await _crudRepository.GetAll();
            if (materias.Any())
            {
                MateriaEntities materia = materias.FirstOrDefault(x => x.codigo == contract.codigo);
                if (materia == null)
                {
                    return _mapper.Map<MateriasContract>(await _crudRepository.Create(_mapper.Map<MateriaEntities>(contract)));
                }
                else
                {
                    throw new ValidationException(MateriasConstantes.MSG_MATERIA_ENCONTRADO);
                }
            }
            else
            {
                return _mapper.Map<MateriasContract>(await _crudRepository.Create(_mapper.Map<MateriaEntities>(contract)));
            }
        }

        public async Task<bool> DeleteAsync(int codigo)
        {
            return await _crudRepository.DeleteById(codigo);
        }

        public async Task<List<MateriasContract>> GetAllAsync()
        {
            List<MateriaEntities> materiaEntities = await _crudRepository.GetAll();
            return _mapper.Map<List<MateriasContract>>(materiaEntities);
        }

        public async Task<MateriasContract> GetByIdAsync(int codigo)
        {
            MateriaEntities materiaEntities = await _crudRepository.GetById(codigo);
            return _mapper.Map<MateriasContract>(materiaEntities);
        }

        public async Task<MateriasContract> UpdateAsync(MateriasContract contract) 
        {
            MateriaEntities materiaEntities = await _crudRepository.GetById(contract.codigo);
            if (materiaEntities != null)
            {
                materiaEntities.codigo = contract.codigo;
                materiaEntities.nombre = contract.nombre;
                materiaEntities = await _crudRepository.Update(materiaEntities);
                return _mapper.Map<MateriasContract>(materiaEntities);
            }
            else
            {
                throw new ValidationException(MateriasConstantes.MSG_MATERIA_NO_ENCONTRADO);
            }
        }
    }
}
