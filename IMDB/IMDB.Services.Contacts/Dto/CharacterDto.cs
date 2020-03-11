using System.Runtime.Serialization;

namespace IMDB.Services.Contacts.Dto
{
    [DataContract]
    public class CharacterDTO
    {
        [DataMember]
        public long Id
        {
            get;
            set;
        }

        [DataMember]
        public string Name
        {
            get;
            set;
        }

        [DataMember]
        public ActorDto Actor
        {
            get;
            set;
        }

        [DataMember]
        public MovieDto Movie
        {
            get;
            set;
        }

        [DataMember]
        public SerieDto Serie
        {
            get;
            set;
        }
    }
}
