﻿using IMDB.EntityModels;
using System.Collections.Generic;

namespace IMDB.Web.ViewModels
{
    public class SerieCharacters
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

        public IList<Character> Characters
        {
            get;
            set;
        }
    }
}
