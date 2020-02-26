using IMDB.Web.EntityModel;
using System.Collections.Generic;

namespace IMDB.Web.ViewModels
{
    public class CharacterPlayedByActorViewModel
    {
        public List<Movie> AvailableMovies
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

        public string MovieId
        {
            get;
            set;
        }

        public int IdActor
        {
            get;
            set;
        }

        /* public CharacterPlayedByActorViewModel()
         {
             AvailableMovies = new List<Movie>();
         }*/
    }
}
