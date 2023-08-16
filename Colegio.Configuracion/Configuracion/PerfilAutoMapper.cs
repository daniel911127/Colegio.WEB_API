using AutoMapper;
using Colegio.Comunes.Clases.Contracts.Colegio.Alumnos;
using Colegio.Comunes.Clases.Contracts.Colegio.AlumnosMaterias;
using Colegio.Comunes.Clases.Contracts.Colegio.Materias;
using Colegio.Comunes.Clases.Contracts.Colegio.Profesores;
using Colegio.Comunes.Clases.Contracts.Colegio.ProfesoresMaterias;
using Colegio.Infraestructura.Database.Entidades.Alumnos;
using Colegio.Infraestructura.Database.Entidades.AlumnosMaterias;
using Colegio.Infraestructura.Database.Entidades.Materias;
using Colegio.Infraestructura.Database.Entidades.Profesores;
using Colegio.Infraestructura.Database.Entidades.ProfesoresMaterias;

namespace Colegio.Configuracion.Configuracion
{
    public class PerfilAutoMapper:Profile
    {
        public PerfilAutoMapper()
        {
            CreateMap<ProfesorEntities, ProfesoresContract>().ReverseMap();
            CreateMap<AlumnoEntities, AlumnosContract>().ReverseMap();
            CreateMap<MateriaEntities, MateriasContract>().ReverseMap();
            CreateMap<ProfesorMateriaEntities, ProfesoresMateriasContract>().ReverseMap();
            CreateMap<AlumnoMateriaEntities, AlumnosMateriasContract>().ReverseMap();
        }
    }
}
