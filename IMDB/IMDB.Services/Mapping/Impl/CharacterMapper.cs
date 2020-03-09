using IMDB.EntityModels;
using IMDB.Services.Contacts.Dto;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.Services.Mapping.Impl
{
    public class CharacterMapper : IEntityMapper<Character, CharacterDto>
    {
        private ISession session;

        public CharacterMapper()
        {
            this.session = session;
        }

        public Character ToModel(CharacterDto source, Character destination)
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
            destination.Actor = source.Actor;
            destination.Serie = destination.Serie;
            destination.Movie = destination.Movie;

            return destination;
        }

        public CharacterDto ToDto(Character source, CharacterDto destination)
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
            destination.Actor = source.Actor;
            destination.Serie = destination.Serie;
            destination.Movie = destination.Movie;

            return destination;
        }
    }
}
