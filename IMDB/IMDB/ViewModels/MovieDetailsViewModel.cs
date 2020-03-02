using System;
using System.ComponentModel.DataAnnotations;

namespace IMDB.Web.ViewModels
{
    public class MovieDetailsViewModel
    {
        public long Id
        {
            get;
            set;
        }

        [Required]
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

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
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

        /*
        public String CharacterName
        {
            get;
            set;
        }

        public List<Actor> actorsInStorage
        {
            get;
            set;
        }

        public String ActorId
        {
            get;
            set;
        }
        */

        public MovieDetailsViewModel()
        {
        }

        /*
        public MovieDetailsViewModel(List<Actor> allActors)
        {
            actorsInStorage = new List<Actor>();
        }*/
    }
}
