using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.MovieDatabase
{
    public class MovieDatabase : IMovieDatabase
    {

        private List<Actor> actorsList = new List<Actor>();

        private Dictionary<string, Actor> actorsDictionary = new Dictionary<string, Actor>();

        private Dictionary<string, Actor> newBieActors = new Dictionary<string, Actor>();

        private Dictionary<string, Movie> movieDictionary = new Dictionary<string, Movie>();

        public void AddActor(Actor actor)
        {
            if (!actorsDictionary.ContainsKey(actor.Id))
            {
                actorsDictionary.Add(actor.Id, actor);
                newBieActors.Add(actor.Id, actor);
                actorsList.Add(actor);
            }
        }

        public void AddMovie(Actor actor, Movie movie)
        {
            ChekForActor(actor.Id);

            actor.Movies.Add(movie);
            newBieActors.Remove(actor.Id);

            if (!movieDictionary.ContainsKey(movie.Id))
            {
                movieDictionary.Add(movie.Id, movie);
            }
        }

        public bool Contains(Actor actor)
        {
            return actorsDictionary.ContainsKey(actor.Id);
        }

        public bool Contains(Movie movie)
        {
            return movieDictionary.ContainsKey(movie.Id);
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return movieDictionary.Values;
        }

        public IEnumerable<Actor> GetNewbieActors()
        {
            return newBieActors.Values;
        }

        public IEnumerable<Movie> GetMoviesOrderedByBudgetThenByRating()
        {
            if (movieDictionary.Count == 0)
            {
                return new List<Movie>();
            }

            return movieDictionary.Values.OrderByDescending(x => x.Budget).ThenByDescending(x => x.Rating);
        }

        public IEnumerable<Movie> GetMoviesInRangeOfBudget(double lower, double upper)
        {
            movieDictionary.Values.OrderByDescending(x => x.Rating);

            var result = new List<Movie>();

            foreach (var movie in movieDictionary.Values)
            {
                if (movie.Budget >= lower && movie.Budget <= upper)
                {
                    result.Add(movie);
                }
            }

            return result;
        }

        public IEnumerable<Actor> GetActorsOrderedByMaxMovieBudgetThenByMoviesCount()
        {
            if (actorsDictionary.Count == 0)
            {
                return new List<Actor>();
            }

            return actorsDictionary.Values.OrderByDescending(x => x.Movies.Select(m => m.Budget)).ThenByDescending(x => x.Movies.Count).ToList();
        }        

        private void ChekForActor(string id)
        {
            if (!actorsDictionary.ContainsKey(id))
            {
                throw new ArgumentException();
            }
        }
    }
}
