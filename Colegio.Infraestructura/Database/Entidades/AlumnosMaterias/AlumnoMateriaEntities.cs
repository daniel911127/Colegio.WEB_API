using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Colegio.Infraestructura.Database.Entidades.AlumnosMaterias
{
    [Table("Alumno_Materia")]
    public class AlumnoMateriaEntities
    {
        [Key]
        public int id { get; set; }
        public int identificacion_alumno { get; set; }
        public int codigo_materia { get; set; }
        public decimal calificacion { get; set; }
        public string ano { get; set; } = string.Empty;
    }
}
