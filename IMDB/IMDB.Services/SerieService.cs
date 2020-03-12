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
    }
}
