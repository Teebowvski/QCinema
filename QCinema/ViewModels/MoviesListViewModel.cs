using QCinema.Models;
using System.Collections.Generic;

namespace QCinema.ViewModels
{
    public class MoviesListviewModel
    {
      public  IEnumerable<Movie> Movies { get; set; }
        public IEnumerable<Genre> Genres { get; set; }

        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Actor> Actors { get; set; }
        public IEnumerable<Producer> Producers { get; set; }
        public IEnumerable<Cinema> Cinemas { get; set; }

    }
}
