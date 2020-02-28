using IMDB.EntityModels;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Text;

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

                )
        }
    }
}
