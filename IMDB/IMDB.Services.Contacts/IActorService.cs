using IMDB.Services.Contacts.Dto;
using System.Collections.Generic;

namespace IMDB.Services.Contacts
{
    public interface IActorService
    {
        IEnumerable<ActorDto> GetAllActors();

        ActorDto GetActorById(long idActor);

        long SaveActor(MovieDto newMovie);

        long UpdateActor(MovieDto editedMovie);

        bool RemoveActor(long movieId);
    }
}
