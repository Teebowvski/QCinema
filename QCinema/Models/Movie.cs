using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QCinema.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string LongDescription { get; set; }
        public int Duration { get; set; }
        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        public int ActorId { get; set; }
        public virtual Actor Actor { get; set; }
        public int CinemaId { get; set; }
        public virtual Cinema Cinema { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int ProducerId { get; set; }
        public  virtual Producer Producer { get; set; }
       

    }
}
