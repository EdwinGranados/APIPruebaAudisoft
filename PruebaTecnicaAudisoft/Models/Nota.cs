using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnicaAudisoft.Models
{
    public class Nota
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }

        [ForeignKey("Profesor")]
        public int idProfesor { get; set; }

        [ForeignKey("Estudiante")]
        public int idEstudiante { get; set; }
        public int valor { get; set; }

        public Profesor? Profesor { get; set; }

        public Estudiante? Estudiante { get; set; }
    }
}
