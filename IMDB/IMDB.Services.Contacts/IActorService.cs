using IMDB.Services.Contacts.Dto;
using System.Collections.Generic;

namespace IMDB.Services.Contacts
{
    public interface IActorService
    {
        public IEnumerable<ActorDto> GetAllActors();

        ActorDto GetActorById(long idActor);

        long SaveActor(ActorDto newActor);

        long UpdateActor(ActorDto editedActor);

        bool RemoveActor(long actorId);
    }
}
