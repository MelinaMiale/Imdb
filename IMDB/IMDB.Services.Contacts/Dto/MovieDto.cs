using System;
using System.Collections.Generic;

namespace IMDB.Services.Contacts.Dto
{
    public class MovieDto
    {
        private IList<long> characterIds;

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

        public string Nationality
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

        public IList<long> CharacterIds
        {//en el mapper asigno a la pelicula los personajes usando esta lista de idDePersonaje.
            get { return this.characterIds ?? (this.characterIds = new List<long>()); }
            set { this.characterIds = value; }
        }
    }
}
