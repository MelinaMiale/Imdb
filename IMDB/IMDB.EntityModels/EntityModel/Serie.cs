using System;
using System.Collections.Generic;

namespace IMDB.EntityModels
{
    public class Serie
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

        //poster caps
        public virtual IList<Chapter> Chapters
        {
            get;
            set;
        }

        public virtual string Poster
        {
            get;
            set;
        }

        public virtual DateTime ReleaseDate
        {
            get;
            set;
        }

        public Serie()
        {
            this.Characters = new List<Character>();
            this.Chapters = new List<Chapter>();
        }
    }
}
