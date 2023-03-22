using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using QCinema.Models;
using System.Collections.Generic;
using System.Linq;

namespace QCinema.Data
{
    public class AppDbInitialier
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

            context.Database.EnsureCreated();

          

            if (!context.Categories.Any())
            {
                context.AddRange(new List<Category>
                {
                    new Category(){Name ="Upcoming"},
                    new Category(){Name ="Available"},
                    
                        new Category(){Name="Sports"}
                });
                context.SaveChanges();
            }

           
        

            if (!context.Genres.Any())
            {
                context.Genres.AddRange(new List<Genre>()
                {
                    new Genre(){Name = "Action"},
                     new Genre(){Name = "Documentary"},
                      new Genre(){Name = "Animation"},
                       new Genre(){Name = "Sci-Fi"},
                        new Genre(){Name = "Adventure"},
                         new Genre(){Name = "comedy"},
                         new Genre(){Name = "Horror"},

                });
                context.SaveChanges();



            }


            if (!context.Cinemas.Any())
            {

                context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
 Name =  "Cinema 1",

Description="This is the description for Cinema 1"
                        },
                          new Cinema()
                        {
Name =  "Cinema 2",

Description="This is the description for Cinema 2"
                        },
                            new Cinema()
                        {
Name =  "Cinema 3",

Description="This is the description for Cinema 3"
                        },
                              new Cinema()
                        {
Name =  "Cinema 4",

Description="This is the description for Cinema 4"
                        },
                                new Cinema()
                        {
Name =  "Cinema 5",

Description="This is the description for Cinema 5"
                        }
                    });
                context.SaveChanges();

            }



            if (!context.Producers.Any())
            {
                context.Producers.AddRange(new List<Producer>
                    {
                        new Producer()
                        {
                            Name="James Cameron",
                            ImageUrl ="http://dotnethow.net/images/producers/producer-1.jpeg",
                            Bio=    "Thsis is the Bio for producer 1"

                        },
                        new Producer()
                        {
                            Name="Ryan Coogley",
                            ImageUrl ="http://dotnethow.net/images/producers/producer-2.jpeg",
                            Bio=    "Thsis is the Bio for producer 2"
                        },
                        new Producer()
                        {
                            Name="Micheal Bay",
                            ImageUrl ="http://dotnethow.net/images/producers/producer-3.jpeg",
                            Bio=    "Thsis is the Bio for producer 3"
                        },
                        new Producer()
                        {
                            Name="This is the Name for producer 4",
                            ImageUrl ="http://dotnethow.net/images/producers/producer-4.jpeg",
                            Bio=    "Thsis is the Bio for producer 4"
                        },
                        new Producer()
                        {
                            Name="This is the Name for producer 5",
                            ImageUrl ="http://dotnethow.net/images/producers/producer-5.jpeg",
                            Bio=    "Thsis is the Bio for producer 5"
                        }

                    });
                context.SaveChanges();

            }


            if (!context.Actors.Any())
            {
                context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            Name ="Dwayne Johnson",
                            ImageUrl="http://dotnethow.net/images/actors/actors-1.jpeg",
                            Bio="This is the Bio of actor 1"
                        },

                        new Actor()
                        {
                            Name ="Will Smith",
                            ImageUrl="http://dotnethow.net/images/actors/actors-2.jpeg",
                            Bio="This is the Bio of actor 2"
                        },
                        new Actor()
                        {
                            Name ="Actor 3",
                            ImageUrl="http://dotnethow.net/images/actors/actors-3.jpeg",
                            Bio="This is the Bio of actor 3"
                        },
                        new Actor()
                        {
                            Name ="Angela Basset",
                            ImageUrl="http://dotnethow.net/images/actors/actors-4.jpeg",
                            Bio="This is the Bio of actor 4"
                        },
                        new Actor()
                        {
                            Name ="Robert Dowrey Jnr",
                            ImageUrl="http://dotnethow.net/images/actors/actors-5.jpeg",
                            Bio="This is the Bio of actor 5"
                        },
                    });
                context.SaveChanges();
            }


            if (!context.Movies.Any())
            {
                context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name="Black Adam",
                            ImageUrl="http://dotnethow.net/images/movies/movies-7.jpeg",
                           Price=39.50,
                           Description= "",
                            LongDescription= "",
                            GenreId = 1,
                            StartDate=System.DateTime.Now.AddDays(-10),
                            EndDate=System.DateTime.Now.AddDays(-2),
                            CinemaId=1,
                            CategoryId=2,
                            ProducerId=3,
                            ActorId=1,

                        },

                        new Movie()
                        {
                            Name="Wakanda Forever",
                            ImageUrl="http://dotnethow.net/images/movies/movies-8.jpeg",
                            Price=39.50,
                            Description= "",
                            LongDescription= "",
                            GenreId=4,
                            StartDate=System.DateTime.Now.AddDays(3),
                            EndDate=System.DateTime.Now.AddDays(20),
                            CinemaId=1,
                            CategoryId=1,
                            ProducerId=5,
                            ActorId=4

                        },

                        new Movie()
                        {
                            Name="Avatar",
                            ImageUrl="http://dotnethow.net/images/movies/movies-6.jpeg",
                            Price=39.50,
                            Description= "",
                            LongDescription= "",
                            GenreId= 4,
                            StartDate=System.DateTime.Now.AddDays(-10),
                            EndDate=System.DateTime.Now.AddDays(-5),
                            CategoryId=1,
                            CinemaId=1,
                            ProducerId=2,
                            ActorId=4

                        },

                        new Movie()
                        {
                            Name="Ghost",
                            ImageUrl="http://dotnethow.net/images/movies/movies-4.jpeg",
                           Price=39.50,
                           Description= "",
                            LongDescription= "",
                            GenreId=7,
                            StartDate=System.DateTime.Now,
                            EndDate=System.DateTime.Now.AddDays(7),
                            CinemaId=4,
                            CategoryId=2,
                            ProducerId=4,
                            ActorId=3

                        },

                        new Movie()
                        {
                            Name="Men In Black",
                            ImageUrl="http://dotnethow.net/images/movies/movies-3.jpeg",
                            Price=39.50,
                            Description= "",
                            LongDescription= "",
                            GenreId= 4,
                            StartDate=System.DateTime.Now.AddDays(-10),
                            EndDate=System.DateTime.Now.AddDays(10),
                            CinemaId=3,
                            CategoryId=2,
                            ProducerId=3,
                            ActorId=2,

                        },

                        new Movie()
                        {
                            Name="The Avengers",
                            ImageUrl="http://dotnethow.net/images/movies/movies-1.jpeg",
                            Price=29.50,
                            Description= "",
                            LongDescription= "",
                            GenreId= 1,
                            StartDate=System.DateTime.Now,
                            EndDate=System.DateTime.Now.AddDays(3),
                            CinemaId=1,
                            CategoryId=2,
                            ProducerId=1,
                            ActorId=5

                        }

                    });
                context.SaveChanges();

            }

        }
    }
}