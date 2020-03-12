using IMDB.EntityModels;
using IMDB.Services.Contacts.Dto;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IMDB.Services.Mapping.Impl
{
    public class SerieMapper : IEntityMapper<Serie, SerieDto>
    {
        private ISession session;

        public SerieMapper(ISession session)
        {
            this.session = session;
        }

        public SerieDto ToDto(Serie source, SerieDto destination)
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
            destination.Nationality = source.Nationality;
            destination.Poster = source.Poster;
            destination.ReleaseDate = source.ReleaseDate;
            destination.CharacterIds = source.Characters.Select(character => character.Id).ToArray();
            destination.ChapterIds = source.Chapters.Select(chapter => chapter.Id).ToArray();

            return destination;
        }

        public Serie ToModel(SerieDto source, Serie destination)
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
            destination.Nationality = source.Nationality;
            destination.Poster = source.Poster;
            destination.ReleaseDate = source.ReleaseDate;

            //borro los personajes y capitulos q tenga ese modelo para desp agregar los que vienen del dto
            destination.Characters.Clear();
            destination.Chapters.Clear();

            //agrego los personajes que vienen del dto
            var charactersIds = new HashSet<long>(source.CharacterIds);
            foreach (var character in this.session.Query<Character>().ToList().Where(c => charactersIds.Contains(c.Id)))
            {
                destination.Characters.Add(character);
            }

            //agrego los capitulos que vienen del dto
            var chapterIds = new HashSet<long>(source.ChapterIds);
            foreach (var chapter in this.session.Query<Chapter>().ToList().Where(episode => chapterIds.Contains(episode.Id)))
            {
                destination.Chapters.Add(chapter);
            }

            return destination;
        }
    }
}
