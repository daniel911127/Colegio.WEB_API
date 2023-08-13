using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Colegio.Infraestructura.Database.Entidades.Alumnos
{
    [Table("Alumno")]
    public class AlumnoEntities
    {
        [Key]
        public int identificacion { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string apellido { get; set; } = string.Empty;
        public int edad { get; set; }
        public string direccion { get; set; } = string.Empty;
        public string telefono { get; set; } = string.Empty;
    }
}
