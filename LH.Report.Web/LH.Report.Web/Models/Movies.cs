using System;
using System.Collections.Generic;

namespace DevExpress.Web.Demos {
    public static class MoviesProvider {
        public static List<Movie> GetMovies() {
            List<Movie> movies = new List<Movie>();
            movies.Add(new Movie("Titanic", new DateTime(1997, 01, 01), 200, 1.84));
            movies.Add(new Movie("Star Wars: Episode I - The Phantom Menace", new DateTime(1999, 01, 01), 115, 0.92));
            movies.Add(new Movie("Harry Potter and the Sorcerer's Stone", new DateTime(2001, 01, 01), 125, 0.98));
            movies.Add(new Movie("The Lord of the Rings: The Two Towers", new DateTime(2002, 01, 01), 94, 0.93));
            movies.Add(new Movie("The Lord of the Rings: The Return of the King", new DateTime(2003, 01, 01), 94, 1.12));
            movies.Add(new Movie("Shrek 2", new DateTime(2004, 01, 01), 150, 0.92));
            movies.Add(new Movie("Pirates of the Caribbean: Dead Man's Chest", new DateTime(2006, 01, 01), 225, 1.07));
            movies.Add(new Movie("Pirates of the Caribbean: At World's End", new DateTime(2007, 01, 01), 300, 0.96));
            movies.Add(new Movie("Harry Potter and the Order of the Phoenix", new DateTime(2007, 01, 01), 150, 0.94));
            movies.Add(new Movie("The Dark Knight", new DateTime(2008, 01, 01), 185, 0.95));
            return movies;
        }
    }

    public class Movie {
        string name;
        DateTime date;
        int budget;
        double grosses;

        public string Name { get { return name; } }
        public DateTime Date { get { return date; } }
        public int Budget { get { return budget; } }
        public double Grosses { get { return grosses; } }

        public Movie(string name, DateTime date, int budget, double grosses) {
            this.name = name;
            this.date = date;
            this.budget = budget;
            this.grosses = grosses;
        }
    }
}
