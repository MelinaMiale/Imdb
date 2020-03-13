using IMDB.EntityModels;
using IMDB.Services.Contacts.Dto;
using NHibernate;
using System;

namespace IMDB.Services.Mapping.Impl
{
    public class MovieMapper : IEntityMapper<Movie, MovieDto>
    {
        private ISession session;

        public MovieMapper(ISession session)
        {
            this.session = session;
        }

        //paso dto a entity
        public Movie ToModel(MovieDto source, Movie destination)
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
            destination.Name = source.Name;
            destination.Nationality = source.Nationality;
            destination.Poster = source.Poster;
            destination.ReleaseDate = source.ReleaseDate;

            //borro los personajes q tenga ese modelo para desp agregar los que vienen del dto
            ////destination.Characters.Clear();

            ////agrego los personajes que vienen del dto
            //var sourceCharactersIds = new HashSet<long>(source.CharacterIds);
            //var charactersIds = new HashSet<long>(source.CharacterIds);
            //foreach (var character in this.session.Query<Character>().ToList().Where(c => charactersIds.Contains(c.Id)))
            //{
            //    destination.Characters.Add(character);
            //}

            //no seria necesario mapear los personajes aqui porque tiene una seccion aparte donde se dan de alta y baja, listan y editan.

            return destination;
        }

        //paso entity a dto
        public MovieDto ToDto(Movie source, MovieDto destination)
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
            destination.Name = source.Name;
            destination.Nationality = source.Nationality;
            destination.Poster = source.Poster;
            destination.ReleaseDate = source.ReleaseDate;
            //destination.CharacterIds = source.Characters.Select(character => character.Id).ToArray();//obtengo los personajes (a traves del idDePersobaje) y se los asigno a la lista de personajes de la pelicula tipo DTo
            //no seria necesario mapear los personajes aqui porque tiene una seccion aparte donde se dan de alta y baja, listan y editan.

            return destination;
        }
    }
}
