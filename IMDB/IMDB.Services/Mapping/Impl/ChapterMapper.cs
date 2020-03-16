using IMDB.EntityModels;
using IMDB.Services.Contacts.Dto;
using NHibernate;
using System;

namespace IMDB.Services.Mapping.Impl
{
    public class ChapterMapper : IEntityMapper<Chapter, ChapterDto>
    {
        private ISession session;
        private IEntityMapper<Actor, ActorDto> actorMapper;
        private IEntityMapper<Serie, SerieDto> serieMapper;

        public ChapterMapper(ISession session, IEntityMapper<Actor, ActorDto> actorMapper, IEntityMapper<Serie, SerieDto> serieMapper)
        {
            this.session = session;
            this.actorMapper = actorMapper;
            this.serieMapper = serieMapper;
        }

        public ChapterDto ToDto(Chapter source, ChapterDto destination)
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
            destination.ReleaseDate = source.ReleaseDate;
            destination.Duration = source.Duration;
            destination.Serie = this.serieMapper.ToDto(source.Serie, new SerieDto());

            return destination;
        }

        public Chapter ToModel(ChapterDto source, Chapter destination)
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
            destination.ReleaseDate = source.ReleaseDate;
            destination.Duration = source.Duration;
            destination.Serie = this.serieMapper.ToModel(source.Serie, new Serie());

            return destination;
        }
    }
}
