using IMDB.EntityModels;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace IMDB.NHibernate
{
    public class CharacterMapping : ClassMapping<Character>
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

            this.Property(
                e => e.Name,
                m =>
                {
                    m.Column("CharacterName");
                    m.NotNullable(false);
                    m.Unique(true);
                    m.Length(50);
                });

            // many-to-one
            this.ManyToOne(
                e => e.Movie,
                m =>
                {
                    m.Update(true);
                    m.NotNullable(false);
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

            this.ManyToOne(
                e => e.Serie,
                m =>
                {
                    m.Update(true);
                    m.NotNullable(false);
                    m.Column("SerieId");
                    m.Unique(false);
                    m.Cascade(Cascade.None);
                });
        }
    }
}
