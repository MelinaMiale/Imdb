using ContosoUniversity.Services.Contracts.Exceptions;
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

        public bool DeleteSerie(long serieId)
        {
            using (var transaction = this.session.BeginTransaction())
            {
                var serieToDelete = this.session.Get<Serie>(serieId);

                if (serieToDelete == null)
                {
                    throw new EntityNotFoundException(string.Format("serie with id: {0} was not found", serieId));
                }

                this.session.Delete(serieToDelete);
                this.session.Transaction.Commit();
                return true;
            }
        }

        public long UpdateSerie(SerieDto editedSerie)
        {
            using (var transaction = this.session.BeginTransaction())
            {
                //obtengo pelicula a editar
                var serieToUpdate = this.session.Get<Serie>(editedSerie.Id);

                //pasar la serie editada de tipo dto a modelo
                serieToUpdate = this.serieMapper.ToModel(editedSerie, serieToUpdate);

                this.session.Save(serieToUpdate);
                this.session.Transaction.Commit();

                return serieToUpdate.Id;
            }
        }
    }
}
