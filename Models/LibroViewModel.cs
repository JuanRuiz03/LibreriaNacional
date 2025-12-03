using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaNacional.Models
{
    public class LibroViewModel
    {
        [Display(Name = "ISBN")]
        [Required]
        public long ISBN { get; set; }

        [Required(ErrorMessage = "El título es obligatorio.")]
        public string Titulo { get; set; }

        public string Sinopsis { get; set; }

        [Display(Name = "Número de Páginas")]
        public int NPaginas { get; set; }

        // Campo para seleccionar la Editorial
        [Display(Name = "Editorial")]
        [Required(ErrorMessage = "Debe seleccionar una editorial.")]
        public int EditorialesId { get; set; }

        // Lista de editoriales
        public IEnumerable<SelectListItem>? Editoriales { get; set; }
    }
}