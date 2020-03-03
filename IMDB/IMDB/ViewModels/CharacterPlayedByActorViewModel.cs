using IMDB.EntityModels;
using System.Collections.Generic;

namespace IMDB.Web.ViewModels
{
    public class CharacterPlayedByActorViewModel
    {
        public IList<Movie> AvailableMovies
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public int Id
        {
            get;
            set;
        }

        public Movie Movie
        {
            get;
            set;
        }

        public Actor Actor
        {
            get;
            set;
        }
    }
}
