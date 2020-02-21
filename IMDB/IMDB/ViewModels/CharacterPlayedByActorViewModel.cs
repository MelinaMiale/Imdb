using IMDB.Web.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDB.Web.ViewModels
{
    public class CharacterPlayedByActorViewModel
    {
        public List<Movie> AvailableMovies
        {
            get;
            set;
        }

        public int IdActor
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

        public int MovieId
        {
            get;
            set;
        }

        public CharacterPlayedByActorViewModel()
        {
            AvailableMovies = new List<Movie>();
        }
    }
}
