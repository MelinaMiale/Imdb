using IMDB.EntityModels;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace IMDB.NHibernate
{
    public class ChapterMapping : ClassMapping<Chapter>
    {
        public ChapterMapping()
        {
            this.Schema("dbo");
            this.Table("Chapters");

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
                    m.Column("ChapterName");
                    m.NotNullable(false);
                    m.Length(50);
                });

            this.Property(
                e => e.ReleaseDate,
                m =>
                {
                    m.Column("ReleaseDate");
                    m.NotNullable(false);
                });

            // many-to-one
            this.ManyToOne(
                e => e.Serie,
                m =>
                {
                    m.Update(true);
                    m.NotNullable(false);
                    m.Column("SerieId");
                    //   m.Unique(false);
                    m.Cascade(Cascade.None);
                });
        }
    }
}
