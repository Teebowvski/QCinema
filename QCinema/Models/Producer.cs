using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QCinema.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Bio { get; set; }
        public  List<Movie> Movies { get; set; }
    }
}
