using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Colegio.Infraestructura.Database.Entidades.ProfesoresMaterias
{
    [Table("Profesor_Materia")]
    public class ProfesorMateriaEntities
    {
        [Key]
        public int id { get; set; }
        public int identificacion_profesor { get; set; }
        public int codigo_materia { get; set; }
    }
}
