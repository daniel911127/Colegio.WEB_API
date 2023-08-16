using AutoMapper;
using Colegio.Comunes.Clases.Constants;
using Colegio.Comunes.Clases.Contracts.Colegio.Alumnos;
using Colegio.Dominio.Services.Colegio.Common;
using Colegio.Infraestructura.Colegio.Repositorios;
using Colegio.Infraestructura.Database.Entidades.Alumnos;
using Colegio.Infraestructura.Database.Entidades.AlumnosMaterias;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;


namespace Colegio.Dominio.Services.Colegio.Alumnos
{
    public class AlumnosService:ICrudService<AlumnosContract>
    {
        private readonly ICrudRepository<AlumnoEntities> _crudRepository;
        private readonly ICrudRepository<AlumnoMateriaEntities> _crudmatRepository;
        private readonly IMapper _mapper;
        public AlumnosService(ICrudRepository<AlumnoEntities> crudRepository, IMapper mapper,ICrudRepository<AlumnoMateriaEntities>crudmatRepository)
        {
            _crudRepository = crudRepository;
            _crudmatRepository=crudmatRepository;
            _mapper = mapper;
        }

        public async Task<AlumnosContract> CreateAsync(AlumnosContract contract)
        {
            List<AlumnoEntities> alumnos = await _crudRepository.GetAll();
            if (alumnos.Any())
            {
                AlumnoEntities alumno = alumnos.FirstOrDefault(x => x.identificacion == contract.identificacion);
                if (alumno == null)
                {
                    return _mapper.Map<AlumnosContract>(await _crudRepository.Create(_mapper.Map<AlumnoEntities>(contract)));
                }
                else
                {
                    throw new ValidationException(AlumnosConstantes.MSG_ALUMNO_ENCONTRADO);
                }
            }
            else
            {
                return _mapper.Map<AlumnosContract>(await _crudRepository.Create(_mapper.Map<AlumnoEntities>(contract)));
            }
        }

        public async Task<bool> DeleteAsync(int identificacion)
        {
            List<AlumnoMateriaEntities> materias = await _crudmatRepository.GetAll();
            if (materias.Any())
            {
                AlumnoMateriaEntities materia = materias.FirstOrDefault(x => x.identificacion_alumno == identificacion);
                if (materia == null)
                {
                    return await _crudRepository.DeleteById(identificacion);
                }
                else
                {
                    throw new ValidationException(AlumnosConstantes.MSG_ALUMNO_NO_BORRARO);
                }
            }
            else
            {
                return await _crudRepository.DeleteById(identificacion); ;
            }
            

        }

        public async Task<List<AlumnosContract>> GetAllAsync()
        {
            List<AlumnoEntities> alumnoEntities = await _crudRepository.GetAll();
            return _mapper.Map<List<AlumnosContract>>(alumnoEntities);
        }

        public async Task<AlumnosContract> GetByIdAsync(int identificacion)
        {
            AlumnoEntities alumnoEntities = await _crudRepository.GetById(identificacion);
            return _mapper.Map<AlumnosContract>(alumnoEntities);
        }

        public async Task<AlumnosContract> UpdateAsync(AlumnosContract contract)
        {
            AlumnoEntities alumnoEntities = await _crudRepository.GetById(contract.identificacion);
            if  (alumnoEntities != null)
            {
                alumnoEntities.identificacion = contract.identificacion;
                alumnoEntities.nombre = contract.nombre;
                alumnoEntities.apellido = contract.apellido;
                alumnoEntities.edad = contract.edad;
                alumnoEntities.direccion = contract.direccion;
                alumnoEntities.telefono = contract.telefono;
                alumnoEntities = await _crudRepository.Update(alumnoEntities);
                return _mapper.Map<AlumnosContract>( alumnoEntities);
            }
            else
            {
                throw new ValidationException(AlumnosConstantes.MSG_ALUMNO_NO_ENCONTRADO);
            }
        }
    }
}
