using ContosoUniversity.Services.Contracts.Exceptions;
using IMDB.EntityModels;
using IMDB.Services.Contacts;
using IMDB.Services.Contacts.Dto;
using IMDB.Services.Mapping;
using NHibernate;
using System.Collections.Generic;
using System.Linq;

namespace IMDB.Services
{
    public class CharacterServices : ICharacterService
    {
        private ISession session;
        private IEntityMapper<Character, CharacterDTO> characterMapper;
        private IEntityMapper<Movie, MovieDto> movieMapper;
        private IEntityMapper<Actor, ActorDto> actorMapper;

        public CharacterServices(ISession session, IEntityMapper<Character, CharacterDTO> characterMapper, IEntityMapper<Movie, MovieDto> movieMapper, IEntityMapper<Actor, ActorDto> actorMapper)
        {
            this.session = session;
            this.characterMapper = characterMapper;
            this.movieMapper = movieMapper;
            this.actorMapper = actorMapper;
        }

        public IEnumerable<CharacterDTO> GetMovieCharacters(long movieId)
        {
            //obtengo pelicula
            var movie = this.session.Get<Movie>(movieId);

            //obtengo todos los personajes (INNER JOIN VS MOVIE AND CHARACTERS TABLES)
            var characters = this.session.Query<Character>().Where(c => c.Movie.Id == movieId);// trae personaje con pelicula asociada

            //¿porque no funciona?
            //var charactersDto = characters.Select(character => this.characterMapper.ToDto(character, new CharacterDto())).ToList();

            var charactersDto = new List<CharacterDTO>();
            foreach (var character in characters)
            {
                charactersDto.Add(this.characterMapper.ToDto(character, new CharacterDTO()));
            }

            return charactersDto;
        }

        public IEnumerable<CharacterDTO> GetActorCharacters(long actorId)
        {
            //obtengo actor
            var actorById = this.session.Get<Actor>(actorId);

            //obtengo todos los personajes (INNER JOIN VS ACTOR AND CHARACTERS TABLES)
            var allCharacters = this.session.Query<Character>().Where(c => c.Actor.Id == actorId);

            //paso a dto los personajes y los agrego a la lista de tipo dto
            var charactersDto = new List<CharacterDTO>();
            foreach (var character in allCharacters)
            {
                charactersDto.Add(this.characterMapper.ToDto(character, new CharacterDTO()));
            }

            // devuelvo lista
            return charactersDto;
        }

        public long SaveCharacter(CharacterDTO newCharacterDto)
        {
            using (var transaction = this.session.BeginTransaction())
            {
                //paso de dto a entity
                var newCharacter = this.characterMapper.ToModel(newCharacterDto, new Character());

                //guardo en db
                this.session.Save(newCharacter);
                this.session.Transaction.Commit();

                //devuelvo el id del nuevo character
                return newCharacter.Id;
            }
        }

        public bool RemoveCharacter(long characterId)
        {
            using (var transaction = this.session.BeginTransaction())
            {
                //obtengo el personaje a borrar
                var characterToDelete = this.session.Get<Character>(characterId);

                if (characterToDelete == null)
                {
                    throw new EntityNotFoundException(string.Format("movie with id: {0} was not found", characterId));
                }

                //lo borro y persisto en bd
                this.session.Delete(characterToDelete);
                this.session.Transaction.Commit();

                //devuelvo ok! si lo borre
                return true;
            }
        }

        public CharacterDTO GetCharacterById(long characterId)
        {
            //obtengo personaje de la bd
            var characterById = this.session.Get<Character>(characterId);

            //paso personaje a roleDto
            var characterDto = this.characterMapper.ToDto(characterById, new CharacterDTO());

            //devuelvo ese personaje
            return characterDto;
        }

        public long UpdateCharacter(CharacterDTO updatedCharacter)
        {
            using (var transaction = this.session.BeginTransaction())
            {
                var characterToEdit = this.session.Get<Character>(updatedCharacter.Id);
                if (characterToEdit == null)
                {
                    throw new EntityNotFoundException(string.Format("movie with id: {0} was not found", updatedCharacter.Id));
                }
                //mapeo personaje editado a modelo
                characterToEdit = this.characterMapper.ToModel(updatedCharacter, characterToEdit);

                //persisto en bd
                this.session.Save(characterToEdit);
                this.session.Transaction.Commit();

                return updatedCharacter.Id;
            }
        }

        //public IEnumerable<CharacterDTO> GetSerieCharacters(long serieId)
        //{
        //    //obtengo pelicula
        //    var serie = this.session.Get<Movie>(serieId);

        //    //obtengo todos los personajes (INNER JOIN VS MOVIE AND CHARACTERS TABLES)
        //    var characters = this.session.Query<Character>().Where(c => c.Serie.Id == serieId);// trae personaje con pelicula asociada

        //    var charactersDto = new List<CharacterDTO>();
        //    foreach (var character in characters)
        //    {
        //        charactersDto.Add(this.characterMapper.ToDto(character, new CharacterDTO()));
        //    }

        //    return charactersDto;
        //}
    }
}
