﻿using IMDB.EntityModels;
using System.Collections.Generic;

namespace IMDB.Web.ViewModels
{
    public class MovieCharacterInMovieViewModel
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

        //public int Actorid
        //{
        //    get;
        //    set;
        //}

        public IList<Character> Characters
        {
            get;
            set;
        }

        //public int MovieId
        //{
        //    get;
        //    set;
        //}
    }
}
