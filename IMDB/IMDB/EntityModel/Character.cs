namespace IMDB.Web.EntityModel
{
    public class Character
    {
        public virtual long Id
        {
            get;
            set;
        }

        public virtual string Name
        {
            get;
            set;
        }

        public virtual Actor Actor
        {
            get;
            set;
        }

        public virtual Movie Movie
        {
            get;
            set;
        }

        public virtual Serie Serie
        {
            get;
            set;
        }

        public virtual int IdActor { get; set; }

        public virtual int IdMovie { get; set; }
    }
}
