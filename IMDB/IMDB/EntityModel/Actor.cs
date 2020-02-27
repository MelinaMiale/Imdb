using System.Collections.Generic;

namespace IMDB.Web.EntityModel
{
    public class Actor
    {
        public virtual long Id
        {
            get;
            set;
        }

        public virtual string FirstName
        {
            get;
            set;
        }

        public virtual string LastName
        {
            get;
            set;
        }

        public virtual List<Character> Characters
        {
            get;
            set;
        }

        public virtual Nationality Nationality
        {
            get;
            set;
        }

        public virtual int Age
        {
            get;
            set;
        }

        public virtual string ProfileFoto
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
