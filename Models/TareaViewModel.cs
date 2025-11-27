namespace ListaTareas.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public bool Completada { get; set; } = false;
    }

    public class TareaViewModel
    {
        public List<Tarea> Tareas { get; set; } = new List<Tarea>();
        public string NuevaTarea { get; set; } = string.Empty;
    }
}