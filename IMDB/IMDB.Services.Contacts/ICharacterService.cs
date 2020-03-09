using IMDB.Services.Contacts.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.Services.Contacts
{
    public interface ICharacterService
    {
        IEnumerable<CharacterDto> GetCharacters(long movieId);

        //CharacterDto GetCharacterById(long idCharacter);

        //long SaveCharacter(CharacterDto newCharacter);

        //long UpdateCharacter(CharacterDto updatedCharacter);

        //bool DeleteCharacter(long characterId);
    }
}
