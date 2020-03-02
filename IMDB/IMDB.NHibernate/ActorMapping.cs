using IMDB.EntityModels;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMDB.NHibernate
{
    internal class ActorMapping : ClassMapping<Actor>
    {
        public ActorMapping()
        {
            this.Schema("dbo");
            this.Table("Actors");

            this.Id(
                e => e.Id,
                m =>
                {
                    m.Column("Id");
                    m.Generator(Generators.Native);
                });

            this.Property(
                e => e.FirstName,
                m =>
                {
                    m.Column("FirstName");
                    m.NotNullable(true);
                    m.Unique(false);
                    m.Length(128);
                });

            this.Property(
                e => e.LastName,
                m =>
                {
                    m.Column("LastName");
                    m.NotNullable(true);
                    m.Unique(false);
                    m.Length(128);
                });

            this.Property(
                e => e.Age,
                m =>
                {
                    m.Column("LastName");
                    m.NotNullable(true);
                    m.Unique(false);
                });

            this.Property(
               e => e.Nationality,
               m =>
               {
                   m.Column("Nationality");
                   m.NotNullable(true);
                   m.Unique(false);
               });

            this.Property(
               e => e.ProfileFoto,
               m =>
               {
                   m.Column("ProfileFoto");
                   m.NotNullable(true);
                   m.Unique(true);
               });

            //one to many
            this.Bag(
                 e => e.Characters,
                 cm =>
                 {
                     cm.Inverse(true);
                     cm.Lazy(CollectionLazy.Lazy);
                     cm.Cascade(Cascade.All | Cascade.DeleteOrphans);
                     cm.Key(k => k.Column(col => col.Name("ActorId")));
                 },
                 m => m.OneToMany());
        }
    }
}
