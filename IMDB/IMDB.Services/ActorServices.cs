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
    public class ActorServices : IActorService
    {
        private ISession session;
        private IEntityMapper<Actor, ActorDto> actorMapper;

        public ActorServices(ISession session, IEntityMapper<Actor, ActorDto> actorMapper)
        {
            this.session = session;
            this.actorMapper = actorMapper;
        }

        public IEnumerable<ActorDto> GetAllActors()
        {
            var actors = this.session.Query<Actor>().ToList();
            var actorsDto = actors.Select(actor => this.actorMapper.ToDto(actor, new ActorDto()));

            return actorsDto;
        }

        public ActorDto GetActorById(long actorId)
        {
            var actorById = this.session.Get<Actor>(actorId);
            var actorDto = actorMapper.ToDto(actorById, new ActorDto());

            return actorDto;
        }

        public long SaveActor(ActorDto newActorDto)
        {
            using (var transaction = this.session.BeginTransaction())
            {
                var actor = this.actorMapper.ToModel(newActorDto, new Actor());

                this.session.Save(actor);
                this.session.Transaction.Commit();

                return actor.Id;
            }
        }

        public long UpdateActor(ActorDto editedActor)
        {
            using (var transaction = this.session.BeginTransaction())
            {
                //obtengo pelicula a editar
                var actor = this.session.Get<Actor>(editedActor.Id);
                if (editedActor == null)
                {
                    throw new EntityNotFoundException(string.Format("actor with id: {0} was not found", editedActor.Id));
                }

                //paso a model y guardo en db
                actor = this.actorMapper.ToModel(editedActor, actor);
                this.session.Save(actor);
                this.session.Transaction.Commit();

                return editedActor.Id;
            }
        }

        public bool RemoveActor(long actorId)
        {
            using (var transaction = this.session.BeginTransaction())
            {
                var actorToDelete = this.session.Get<Actor>(actorId);

                if (actorToDelete == null)
                {
                    throw new EntityNotFoundException(string.Format("movie with id: {0} was not found", actorId));
                }

                this.session.Delete(actorToDelete);
                this.session.Transaction.Commit();
                return true;
            }
        }
    }
}
