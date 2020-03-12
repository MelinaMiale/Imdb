using IMDB.EntityModels;
using IMDB.Services.Contacts.Dto;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.Services.Mapping.Impl
{
    public class CharacterMapper : IEntityMapper<Character, CharacterDTO>
    {
        private ISession session;
        private IEntityMapper<Actor, ActorDto> actorMapper;
        private IEntityMapper<Movie, MovieDto> movieMapper;

        public CharacterMapper(ISession session, IEntityMapper<Actor, ActorDto> actorMapper, IEntityMapper<Movie, MovieDto> movieMapper)
        {
            this.session = session;
            this.actorMapper = actorMapper;
            this.movieMapper = movieMapper;
        }

        public Character ToModel(CharacterDTO source, Character destination)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            if (destination == null)
            {
                throw new ArgumentNullException();
            }

            destination.Id = source.Id;
            destination.Name = source.Name;
            destination.Actor = this.actorMapper.ToModel(source.Actor, new Actor());
            // destination.Serie = source.Serie;
            destination.Movie = this.movieMapper.ToModel(source.Movie, new Movie());

            return destination;
        }

        public CharacterDTO ToDto(Character source, CharacterDTO destination)
        {
            if (source == null)
            {
                throw new ArgumentNullException();
            }

            if (destination == null)
            {
                throw new ArgumentNullException();
            }

            destination.Id = source.Id;
            destination.Name = source.Name;
            destination.Actor = this.actorMapper.ToDto(source.Actor, new ActorDto());
            //destination.Serie = source.Serie;
            destination.Movie = this.movieMapper.ToDto(source.Movie, new MovieDto());

            return destination;
        }
    }
}
