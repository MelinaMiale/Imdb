using IMDB.EntityModels;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace IMDB.NHibernate
{
    internal class CharacterMapping : ClassMapping<Character>
    {
        public CharacterMapping()
        {
            this.Schema("dbo");
            this.Table("Characters");

            this.Id(
                e => e.Id,
                m =>
                {
                    m.Column("Id");
                    m.Generator(Generators.Native);
                });

            // many-to-one

            this.ManyToOne(
                e => e.Movie,
                m =>
                {
                    m.Update(true);
                    m.NotNullable(true);
                    m.Column("MovieId");
                    m.Unique(false);
                    m.Cascade(Cascade.None);
                });

            this.ManyToOne(
                e => e.Actor,
                m =>
                {
                    m.Update(true);
                    m.NotNullable(true);
                    m.Column("ActorId");
                    m.Unique(false);
                    m.Cascade(Cascade.None);
                });
        }
    }
}
