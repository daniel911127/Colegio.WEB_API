using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Colegio.Infraestructura.Database.Entidades.Materias
{
    [Table("Materia")]
    public class MateriaEntities
    {
        [Key]
        public int codigo { get; set; }
        public string nombre { get; set; } = string.Empty;
    }
}
