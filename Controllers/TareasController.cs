using Microsoft.AspNetCore.Mvc;
using ListaTareas.Models;

namespace ListaTareas.Controllers
{
    public class TareasController : Controller
    {
        // Simulación de base de datos en memoria
        private static List<Tarea> tareas = new List<Tarea>
        {
            new Tarea { Id = 1, Descripcion = "Completar el ejercicio de MVC", Completada = false },
            new Tarea { Id = 2, Descripcion = "Estudiar para el examen", Completada = false }
        };

        private static int siguienteId = 3;

        public IActionResult Index()
        {
            var modelo = new TareaViewModel
            {
                Tareas = tareas
            };
            return View(modelo);
        }

        [HttpPost]
        public IActionResult Agregar(string NuevaTarea)
        {
            if (!string.IsNullOrWhiteSpace(NuevaTarea))
            {
                tareas.Add(new Tarea
                {
                    Id = siguienteId++,
                    Descripcion = NuevaTarea,
                    Completada = false
                });
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Completar(int id)
        {
            var tarea = tareas.FirstOrDefault(t => t.Id == id);
            if (tarea != null)
            {
                tarea.Completada = !tarea.Completada;
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            var tarea = tareas.FirstOrDefault(t => t.Id == id);
            if (tarea != null)
            {
                tareas.Remove(tarea);
            }

            return RedirectToAction("Index");
        }
    }
}