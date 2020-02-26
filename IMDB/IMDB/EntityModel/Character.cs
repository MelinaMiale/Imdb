﻿namespace IMDB.Web.EntityModel
{
    public class Character
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

        public Actor Actor
        {
            get;
            set;
        }

        public Movie Movie
        {
            get;
            set;
        }

        public Serie Serie
        {
            get;
            set;
        }

        public int IdActor { get; set; }

        public int IdMovie { get; set; }
    }
}
