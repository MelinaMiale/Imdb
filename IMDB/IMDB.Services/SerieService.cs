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
    public class SerieService : ISerieService
    {
        private ISession session;
        private IEntityMapper<Serie, SerieDto> serieMapper;

        public SerieService(ISession session, IEntityMapper<Serie, SerieDto> serieMapper)
        {
            this.session = session;
            this.serieMapper = serieMapper;
        }

        public IEnumerable<SerieDto> GetAllSeries()
        {
            var series = this.session.Query<Serie>().ToList();
            var allSeriesDto = series.Select(serie => this.serieMapper.ToDto(serie, new SerieDto()));

            return allSeriesDto;
        }

        public SerieDto GetById(long serieId)
        {
            var serieById = this.session.Get<Serie>(serieId);
            var serieByIdDto = this.serieMapper.ToDto(serieById, new SerieDto());

            return serieByIdDto;
        }

        public long SaveSerie(SerieDto newSerieDto)
        {
            using (var transaction = this.session.BeginTransaction())
            {
                var serie = this.serieMapper.ToModel(newSerieDto, new Serie());
                this.session.Save(serie);
                this.session.Transaction.Commit();

                return serie.Id;
            }
        }
    }
}
