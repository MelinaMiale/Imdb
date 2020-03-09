using IMDB.EntityModels;
using IMDB.Services.Contacts.Dto;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IMDB.Services.Mapping.Impl
{
    public class ActorMapper : IEntityMapper<Actor, ActorDto>
    {
        private ISession session;

        public ActorMapper(ISession session)
        {
            this.session = session;
        }

        //paso a entity
        public Actor ToModel(ActorDto source, Actor destination)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (destination == null)
            {
                throw new ArgumentNullException(nameof(destination));
            }

            destination.Id = source.Id;
            destination.FirstName = source.FirstName;
            destination.LastName = source.LastName;
            destination.Nationality = source.Nationality;
            destination.ProfileFoto = source.ProfileFoto;
            destination.Age = source.Age;

            //borro los personajes q tenga ese modelo para desp agregar los que vienen del dto
            destination.Characters.Clear();

            //agrego los personajes que vienen del dto
            var charactersIds = new HashSet<long>(source.CharacterIds);
            foreach (var character in this.session.Query<Character>().ToList().Where(c => charactersIds.Contains(c.Id)))
            {
                destination.Characters.Add(character);
            }

            return destination;
        }

        //paso a dto
        public ActorDto ToDto(Actor source, ActorDto destination)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (destination == null)
            {
                throw new ArgumentNullException(nameof(destination));
            }

            destination.Id = source.Id;
            destination.FirstName = source.FirstName;
            destination.LastName = source.LastName;
            destination.Nationality = source.Nationality;
            destination.ProfileFoto = source.ProfileFoto;
            destination.Age = source.Age;
            destination.CharacterIds = source.Characters.Select(character => character.Id).ToArray();

            return destination;
        }
    }
}
