using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QCinema.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
