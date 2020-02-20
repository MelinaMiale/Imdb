using System.Collections.Generic;

namespace IMDB.Web.EntityModel
{
    public class Actor
    {
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

        public List<Character> Characters
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

        public string ProfileFoto
        {
            get;
            set;
        }

        public Actor()
        {
            this.Characters = new List<Character>();
        }
    }
}
