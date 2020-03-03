using IMDB.EntityModels;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Text;

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
                    m.Column("CharacterName");
                    m.NotNullable(false);
                    m.Unique(true);
                    m.Length(50);
                });

            this.Property(
                e => e.ReleaseDate,
                m =>
                {
                    m.Column("CharacterName");
                    m.NotNullable(false);
                    m.Unique(true);
                });

            // many-to-one
            this.ManyToOne(
                e => e.Serie,
                m =>
                {
                    m.Update(true);
                    m.NotNullable(true);
                    m.Column("SerieId");
                    m.Unique(false);
                    m.Cascade(Cascade.None);
                });
        }
    }
}
