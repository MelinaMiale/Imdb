using IMDB.EntityModels;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace IMDB.NHibernate
{
    public class MovieMapping : ClassMapping<Movie>
    {
        public MovieMapping()
        {
            this.Schema("dbo");
            this.Table("Movies");

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
                    m.Column("Title");
                    m.NotNullable(true);
                    m.Unique(true);
                    m.Length(128);
                });

            this.Property(
                e => e.Nationality,
                m =>
                {
                    m.Column("Nationality");
                    m.NotNullable(false);
                    m.Unique(false);
                    m.Length(128);
                });

            this.Property(
                e => e.Poster,
                m =>
                {
                    m.Column("Poster");
                    m.NotNullable(true);
                    m.Unique(true);
                });

            this.Property(
                e => e.ReleaseDate,
                m =>
                {
                    m.Column("ReleaseDate");
                    m.NotNullable(true);
                    m.Unique(false);
                });

            //one to many
            this.List(
                 e => e.Characters,
                 cm =>
                 {
                     cm.Inverse(true);
                     cm.Lazy(CollectionLazy.Lazy);
                     cm.Cascade(Cascade.All | Cascade.DeleteOrphans);
                     cm.Key(k => k.Column(col => col.Name("MovieId")));
                 },
                 m => m.OneToMany());
        }
    }
}
