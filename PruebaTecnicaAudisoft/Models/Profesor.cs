namespace PruebaTecnicaAudisoft.Models
{
    public class Profesor
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public List<Nota>? Notas { get; set; }
    }
}
