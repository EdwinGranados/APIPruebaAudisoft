namespace PruebaTecnicaAudisoft.Models
{
    public class Nota
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public Profesor idProfesor { get; set; } 
        public Estudiante idEstudiante { get; set; }
        public int valor { get; set; }
    }
}
