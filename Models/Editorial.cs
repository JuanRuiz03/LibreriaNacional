using System.ComponentModel.DataAnnotations;

namespace BibliotecaNacional.Models;

public class Editorial
    {
        [Key] //clave primaria
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la editorial es obligatorio.")]
        public string Nombre { get; set; }

        public string Sede { get; set; }

        // Una editorial puede tener muchos libros
        public ICollection<Libro> Libros { get; set; } = new List<Libro>();
    }
