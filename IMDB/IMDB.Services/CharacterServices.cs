using IMDB.EntityModels;
using IMDB.Services.Contacts;
using IMDB.Services.Contacts.Dto;
using IMDB.Services.Mapping;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IMDB.Services
{
    public class CharacterServices : ICharacterService
    {
        private ISession session;
        private IEntityMapper<Character, CharacterDto> characterMapper;
        private IEntityMapper<Movie, MovieDto> movieMapper;

        public CharacterServices(ISession session, IEntityMapper<Character, CharacterDto> characterMapper, IEntityMapper<Movie, MovieDto> movieMapper)
        {
            this.session = session;
            this.characterMapper = characterMapper;
            this.movieMapper = movieMapper;
        }

        public IEnumerable<CharacterDto> GetCharacters(long movieId)
        {
            //obtengo pelicula
            var movie = this.session.Get<Movie>(movieId);

            //obtengo todos los personajes y los paso a dto
            var characters = this.session.Query<Character>().Where(c => c.Movie.Id == movieId);

            var charactersDto = characters.Select(role => this.characterMapper.ToDto(role, new CharacterDto()));

            return charactersDto;
        }
    }
}
