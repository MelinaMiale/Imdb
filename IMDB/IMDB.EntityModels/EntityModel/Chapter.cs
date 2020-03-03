using System;

namespace IMDB.EntityModels
{
    public class Chapter
    {
        public virtual long Id
        {
            get;
            set;
        }

        public virtual DateTime ReleaseDate
        {
            get;
            set;
        }

        public virtual float Duration
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public Serie Serie
        {
            get;
            set;
        }

        public Chapter()
        {
        }
    }
}
