using IMDB.Web.EntityModel;
using System.Collections.Generic;

namespace IMDB.Web.ViewModels
{
    public class ActorDetailViewModel
    {
        public string ProfileFoto
        {
            get;
            set;
        }

        public long Id
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public Nationality Nationality
        {
            get;
            set;
        }

        public int Age
        {
            get;
            set;
        }

        public List<Character> Characters
        {
            get;
            set;
        }
    }
}
