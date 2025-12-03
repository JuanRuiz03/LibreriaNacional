using BibliotecaNacional.Interfaces;
using BibliotecaNacional.Models;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaNacional.Controllers
{
    public class EditorialesController : Controller
    {
        private readonly IEditorialRepository _editorialRepo;

        // Inyección del Repositorio
        public EditorialesController(IEditorialRepository editorialRepo)
        {
            _editorialRepo = editorialRepo;
        }

        // 1. LISTAR (READ)
        public async Task<IActionResult> Index()
        {
            var editoriales = await _editorialRepo.GetAllAsync();
            return View(editoriales); // Pasa la lista de editoriales a la vista
        }

        // 2. CREAR (CREATE) - Muestra el formulario
        public IActionResult Create()
        {
            return View();
        }

        // 2. CREAR (CREATE) - Procesa el formulario
        [HttpPost]
        public async Task<IActionResult> Create(Editorial editorial)
        {
            if (!ModelState.IsValid)
            {
                return View(editorial); // Valida el modelo y vuelve a la vista si encuentra algun error
            }
            await _editorialRepo.AddAsync(editorial);
            return RedirectToAction("Index"); // Redirige a la lista después de que guardo
        }

        // 3. ACTUALIZAR (UPDATE) - Muestra el formulario con datos segun id
        public async Task<IActionResult> Edit(int id)
        {
            var editorial = await _editorialRepo.GetByIdAsync(id);
            if (editorial == null) return NotFound();
            return View(editorial);
        }

        // 3. ACTUALIZAR (UPDATE) - POST: Procesa la actualización para el ID dado
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Editorial editorial)
        {
            if (id != editorial.Id) return NotFound();

            if (!ModelState.IsValid)
            {
                return View(editorial);
            }

            
            await _editorialRepo.UpdateAsync(editorial);
            return RedirectToAction("Index");
        }

        // 4. ELIMINAR (DELETE) - Muestra la confirmación
        public async Task<IActionResult> Delete(int id)
        {
            var editorial = await _editorialRepo.GetByIdAsync(id);
            if (editorial == null) return NotFound();
            return View(editorial);
        }

        
        // 4. ELIMINAR (DELETE) - Ejecuta la eliminación
        //Agregamos el manejo de excepciones para capturar errores de eliminación ya que en el modelo de Libro se presenta al relacion con el IdEditorial
        [HttpPost, ActionName("Delete")] 
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
                {
        // 1. Intentamos eliminar la editorial
        await _editorialRepo.DeleteAsync(id);
        
        // 2. Si la eliminación es exitosa, redirigimos a Index
        return RedirectToAction("Index");
                }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
                {
        // 3. Capturamos la excepción si hay libros asociados
        
        // 4. Agregamos un mensaje de error al ModelState
        ModelState.AddModelError(string.Empty, 
            "No se puede eliminar esta editorial porque tiene libros asignados. " + 
            "Por favor, elimine primero los libros asociados.");

        // 5. Obtenemos el objeto para volver a mostrar la vista
        var editorial = await _editorialRepo.GetByIdAsync(id);
        
        // 6. Volvemos a la vista Delete con el mensaje de error
        return View("Delete", editorial);
    }
}
    }
}