using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ListaLibros.Model
{
    public class libro
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Author { get; set; }

        public string ISBN { get; set; }
    }
}
