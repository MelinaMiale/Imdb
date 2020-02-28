using System;
using System.Collections.Generic;

namespace IMDB.EntityModels
{
    public class Serie
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

        //poster caps
        public List<Chapter> Chapters
        {
            get;
            set;
        }

        public string Poster
        {
            get;
            set;
        }

        public DateTime ReleaseDate
        {
            get;
            set;
        }

        public Serie()
        {
        }
    }
}
