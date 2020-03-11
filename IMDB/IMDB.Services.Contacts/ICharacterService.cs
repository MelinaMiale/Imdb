using IMDB.Services.Contacts.Dto;
using System.Collections.Generic;

namespace IMDB.Services.Contacts
{
    public interface ICharacterService
    {
        IEnumerable<CharacterDTO> GetMovieCharacters(long movieId);

        IEnumerable<CharacterDTO> GetActorCharacters(long actorId);

        public CharacterDTO GetCharacterById(long characterId);

        public long SaveCharacter(CharacterDTO newCharacterDto);

        public long UpdateCharacter(CharacterDTO characterId);

        bool RemoveCharacter(long characterId);
    }
}
