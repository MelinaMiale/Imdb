using IMDB.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.Services.Contacts.Dto
{
    public class CharacterDto
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
    }
}
