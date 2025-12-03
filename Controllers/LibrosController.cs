using BibliotecaNacional.Interfaces;
using BibliotecaNacional.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BibliotecaNacional.Controllers
{
    public class LibrosController : Controller
    {
        private readonly ILibroRepository _libroRepo;
        private readonly IEditorialRepository _editorialRepo;

        public LibrosController(ILibroRepository libroRepo, IEditorialRepository editorialRepo)
        {
            _libroRepo = libroRepo;
            _editorialRepo = editorialRepo;
        }

        // 1. LISTAR (READ)
        public async Task<IActionResult> Index()
        {
            var libros = await _libroRepo.GetAllAsync();
            return View(libros);
        }

        // --- CREAR ---
        // 2. GET: Muestra formulario con lista de editoriales
        public async Task<IActionResult> Create()
        {
            var editoriales = await _editorialRepo.GetAllAsync();
            
            var viewModel = new LibroViewModel
            {
                // Convierte la lista de Editoriales en SelectListItem para el dropdown
                Editoriales = editoriales.Select(e => new SelectListItem 
                { 
                    Value = e.Id.ToString(), 
                    Text = e.Nombre 
                })
            };
            return View(viewModel);
        }

        // 2. POST: Procesa formulario
        [HttpPost]
        public async Task<IActionResult> Create(LibroViewModel vm)
        {
            if (ModelState.IsValid)
            {
                // Mapeamos el ViewModel de vuelta al Modelo de Dominio (Libro)
                var nuevoLibro = new Libro
                {
                    ISBN = vm.ISBN,
                    Titulo = vm.Titulo,
                    Sinopsis = vm.Sinopsis,
                    NPaginas = vm.NPaginas,
                    EditorialesId = vm.EditorialesId
                };
                await _libroRepo.AddAsync(nuevoLibro);
                return RedirectToAction("Index");
            }

            // Si el modelo no es válido, recargamos las editoriales para la vista
            var editoriales = await _editorialRepo.GetAllAsync();
            vm.Editoriales = editoriales.Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.Nombre });
            return View(vm);
        }
        

        // 3. ACTUALIZAR (UPDATE) - Muestra el formulario con datos
        public async Task<IActionResult> Edit(long isbn) // Usamos long para el ISBN
        {
            var libro = await _libroRepo.GetByIdAsync(isbn);
            if (libro == null) return NotFound();

            var editoriales = await _editorialRepo.GetAllAsync();

            
            var viewModel = new LibroViewModel
            {
                ISBN = libro.ISBN,
                Titulo = libro.Titulo,
                Sinopsis = libro.Sinopsis,
                NPaginas = libro.NPaginas,
                EditorialesId = libro.EditorialesId,
                // Carga la lista de editoriales para el dropdown
                Editoriales = editoriales.Select(e => new SelectListItem
                {
                    Value = e.Id.ToString(),
                    Text = e.Nombre,
                    Selected = e.Id == libro.EditorialesId // Nos muestra que Editorial está seleccionado actualmente
                })
            };
            
            return View(viewModel);
        }

        // 3. ACTUALIZAR (UPDATE) - Procesa la actualización
        [HttpPost]
        public async Task<IActionResult> Edit(long isbn, LibroViewModel vm)
        {
            if (isbn != vm.ISBN) return NotFound();

            if (ModelState.IsValid)
            {
                
                var libroActualizado = new Libro
                {
                    ISBN = vm.ISBN,
                    Titulo = vm.Titulo,
                    Sinopsis = vm.Sinopsis,
                    NPaginas = vm.NPaginas,
                    EditorialesId = vm.EditorialesId
                    
                };
                await _libroRepo.UpdateAsync(libroActualizado);
                return RedirectToAction("Index");
            }

            // Si hay errores, recargar la lista de editoriales antes de volver a la vista
            var editoriales = await _editorialRepo.GetAllAsync();
            vm.Editoriales = editoriales.Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.Nombre });
            return View(vm);
        }

        // 4. ELIMINAR (DELETE) - Muestra la confirmación
        public async Task<IActionResult> Delete(long isbn)
        {
            var libro = await _libroRepo.GetByIdAsync(isbn);
            if (libro == null) return NotFound();
            return View(libro);
        }

        // 4. ELIMINAR (DELETE) -  Ejecuta la eliminación
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(long isbn)
        {
            await _libroRepo.DeleteAsync(isbn);
            return RedirectToAction("Index");
        }
            }
        }