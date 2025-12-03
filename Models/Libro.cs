using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaNacional.Models;

public class Libro
    {
        [Key]
        [Display(Name = "ISBN")]
        public long ISBN { get; set; } // Tipo long para números grandes

        [Required(ErrorMessage = "El título es obligatorio.")]
        public string Titulo { get; set; }

        public string Sinopsis { get; set; }

        [Display(Name = "Número de Páginas")]
        public int NPaginas { get; set; }

        // Clave Foránea
        public int EditorialesId { get; set; }

        // Propiedad de Navegación: Un libro pertenece a una editorial
        [ForeignKey("EditorialesId")] 
        public Editorial Editorial { get; set; }

        //relación muchos a muchos con autores(proximamente...)
        //public ICollection<AutoresHasLibros> AutoresHasLibros { get; set; } = new List<AutoresHasLibros>();
    }
