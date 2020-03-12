using IMDB.Services.Contacts.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.Services.Contacts
{
    public interface ICharacterService
    {
        IEnumerable<CharacterDTO> GetCharacters(long movieId);

        public CharacterDTO GetCharacterById(long characterId);

        public long SaveCharacter(CharacterDTO newCharacterDto);

        public CharacterDTO UpdateCharacter(CharacterDTO characterId);

        bool RemoveCharacter(long characterId);
    }
}
