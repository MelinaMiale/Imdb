using System;
using System.Collections.Generic;

namespace IMDB.EntityModels
{
    public class Movie
    {
        public virtual long Id
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }

        public virtual string Nationality
        {
            get;
            set;
        }

        public virtual IList<Character> Characters
        {
            get;
            set;
        }

        public virtual DateTime ReleaseDate
        {
            get;
            set;
        }

        public virtual string Poster
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
