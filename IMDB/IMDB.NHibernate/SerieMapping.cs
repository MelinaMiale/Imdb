using IMDB.EntityModels;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace IMDB.NHibernate
{
    public class SerieMapping : ClassMapping<Serie>
    {
        public SerieMapping()
        {
            this.Schema("dbo");
            this.Table("Series");

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
                    m.Column("Name");
                    m.NotNullable(true);
                    m.Unique(true);
                    m.Length(30);
                });

            this.Property(
                e => e.Nationality,
                m =>
                {
                    m.Column("Nationality");
                    m.NotNullable(false);
                    m.Length(30);
                });

            this.Property(
                e => e.Poster,
                m =>
                {
                    m.Column("Poster");
                    m.NotNullable(false);
                });

            this.Property(
                e => e.ReleaseDate,
                m =>
                {
                    m.Column("ReleaseDate");
                    m.NotNullable(false);
                    m.Unique(false);
                });

            //one to many
            this.Bag(
                 e => e.Characters,
                 cm =>
                 {
                     cm.Inverse(true);
                     cm.Lazy(CollectionLazy.Lazy);
                     cm.Cascade(Cascade.All | Cascade.DeleteOrphans);
                     cm.Key(k => k.Column(col => col.Name("SerieId")));
                 },
                 m => m.OneToMany());

            this.Bag(
                 e => e.Chapters,
                 cm =>
                 {
                     cm.Inverse(true);
                     cm.Lazy(CollectionLazy.Lazy);
                     cm.Cascade(Cascade.All | Cascade.DeleteOrphans);
                     cm.Key(k => k.Column(col => col.Name("SerieId")));
                 },
                 m => m.OneToMany());
        }
    }
}
