namespace Colegio.Comunes.Clases.Contracts.Colegio.Alumnos
{
    public class AlumnosContract
    {
        public int identificacion { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string apellido { get; set; } = string.Empty;
        public int edad { get; set; }
        public string direccion { get; set; } = string.Empty;
        public string telefono { get; set; } = string.Empty;
    }
}
