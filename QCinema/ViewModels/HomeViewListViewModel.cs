using QCinema.Models;
using System.Collections.Generic;

namespace QCinema.ViewModels
{
    public class HomeViewListViewModel
    {
        public IEnumerable<Movie> GetMovies { get; set; }
        public IEnumerable<Genre> GetGenres { get; set; }
        public IEnumerable<Category> GetCategories { get; set; }

    }
}
