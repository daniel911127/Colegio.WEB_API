using AutoMapper;
using Colegio.Comunes.Clases.Constants;
using Colegio.Comunes.Clases.Contracts.Colegio.AlumnosMaterias;
using Colegio.Comunes.Clases.Contracts.Colegio.Profesores;
using Colegio.Comunes.Clases.Contracts.Colegio.ProfesoresMaterias;
using Colegio.Dominio.Services.Colegio.Common;
using Colegio.Infraestructura.Colegio.Repositorios;
using Colegio.Infraestructura.Database.Entidades.AlumnosMaterias;
using Colegio.Infraestructura.Database.Entidades.Profesores;
using Colegio.Infraestructura.Database.Entidades.ProfesoresMaterias;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace Colegio.Dominio.Services.Colegio.AlumnosMaterias
{
    public class AlumnosMateriasService : ICrudService<AlumnosMateriasContract>
    {
        private readonly ICrudRepository<AlumnoMateriaEntities> _crudRepository;
        private readonly IMapper _mapper;
        public AlumnosMateriasService(ICrudRepository<AlumnoMateriaEntities> crudRepository,IMapper mapper)
        {
            _crudRepository = crudRepository;
            _mapper = mapper;
        }

        public async Task<AlumnosMateriasContract> CreateAsync(AlumnosMateriasContract contract)
        {
            List<AlumnoMateriaEntities> listadoalumno = await _crudRepository.GetAll();
            if (listadoalumno.Any())
            {
                AlumnoMateriaEntities alumno = listadoalumno.FirstOrDefault(x => x.identificacion_alumno == contract.identificacion_alumno);
                if (alumno == null)
                {
                    return _mapper.Map<AlumnosMateriasContract>(await _crudRepository.Create(_mapper.Map<AlumnoMateriaEntities>(contract)));
                }
                else
                {
                    List<AlumnoMateriaEntities>listadomaterias=await _crudRepository.GetAll();
                    if (listadomaterias.Any())
                    {
                        AlumnoMateriaEntities materia=listadomaterias.FirstOrDefault(x=>x.codigo_materia== contract.codigo_materia);
                        if(materia == null)
                        {
                            return _mapper.Map<AlumnosMateriasContract>(await _crudRepository.Create(_mapper.Map<AlumnoMateriaEntities>(contract)));
                        }
                        else
                        {
                            List<AlumnoMateriaEntities>listadoano=await _crudRepository.GetAll();
                            if (listadoano.Any())
                            {
                                AlumnoMateriaEntities ano = listadoano.FirstOrDefault(x => x.ano == contract.ano);
                                if(ano == null)
                                {
                                    return _mapper.Map<AlumnosMateriasContract>(await _crudRepository.Create(_mapper.Map<AlumnoMateriaEntities>(contract)));
                                }
                                else
                                {
                                    throw new ValidationException(AlumnosMateriasConstantes.MSG_ALUMNOMATERIA_ENCONTRADO);
                                }
                            }
                            else
                            {
                                return _mapper.Map<AlumnosMateriasContract>(await _crudRepository.Create(_mapper.Map<AlumnoMateriaEntities>(contract)));
                            }
                            
                        }
                    }
                    else
                    {
                        return _mapper.Map<AlumnosMateriasContract>(await _crudRepository.Create(_mapper.Map<AlumnoMateriaEntities>(contract)));
                    }
                }
            }
            else
            {
                return _mapper.Map<AlumnosMateriasContract>(await _crudRepository.Create(_mapper.Map<AlumnoMateriaEntities>(contract)));
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _crudRepository.DeleteById(id);
        }

        public async Task<List<AlumnosMateriasContract>> GetAllAsync()
        {
            List<AlumnoMateriaEntities> alumnomateriaEntities = await _crudRepository.GetAll();
            return _mapper.Map<List<AlumnosMateriasContract>>(alumnomateriaEntities);
        }

        public async Task<AlumnosMateriasContract> GetByIdAsync(int id)
        {
            AlumnoMateriaEntities alumnomateriaEntities = await _crudRepository.GetById(id);
            return _mapper.Map<AlumnosMateriasContract>(alumnomateriaEntities);
        }

        public async Task<AlumnosMateriasContract> UpdateAsync(AlumnosMateriasContract contract)
        {
            AlumnoMateriaEntities alumnomateriaEntities = await _crudRepository.GetById(contract.id);
            if (alumnomateriaEntities != null)
            {
                alumnomateriaEntities.identificacion_alumno = contract.identificacion_alumno;
                alumnomateriaEntities.codigo_materia = contract.codigo_materia;
                alumnomateriaEntities.calificacion= contract.calificacion;
                alumnomateriaEntities.ano = contract.ano;            
                alumnomateriaEntities = await _crudRepository.Update(alumnomateriaEntities);
                return _mapper.Map<AlumnosMateriasContract>(alumnomateriaEntities);
            }
            else
            {
                throw new ValidationException(AlumnosMateriasConstantes.MSG_ALUMNOMATERIA_NO_ENCONTRADO);
            }
        }
    }
}
