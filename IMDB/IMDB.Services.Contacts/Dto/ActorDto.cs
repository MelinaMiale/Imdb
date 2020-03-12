using System.Collections.Generic;

namespace IMDB.Services.Contacts.Dto
{
    public class ActorDto
    {
        private IList<long> characterIds;

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

        public string Nationality
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

        public IList<long> CharacterIds
        {
            get { return this.characterIds ?? (this.characterIds = new List<long>()); }
            set { this.characterIds = value; }
        }
    }
}
