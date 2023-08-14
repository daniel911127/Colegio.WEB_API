namespace Colegio.Comunes.Clases.Contracts.Colegio.AlumnosMaterias
{
    public class AlumnosMateriaContract
    {
        public int id { get; set; }
        public int identificacion_alumno { get; set; }
        public int codigo_materia { get; set; }
        public decimal calificacion { get; set; }
        public string ano { get; set; } = string.Empty;
    }
}
