using System;
using System.Collections.Generic;

namespace IMDB.Web.EntityModel
{
    public class Movie
    {
        public long Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public Nationality Nationality
        {
            get;
            set;
        }

        public List<Character> Characters
        {
            get;
            set;
        }

        public DateTime ReleaseDate
        {
            get;
            set;
        }

        public string Poster
        {
            get;
            set;
        }

        public Movie()
        {
            this.Characters = new List<Character>();
        }
    }
}
