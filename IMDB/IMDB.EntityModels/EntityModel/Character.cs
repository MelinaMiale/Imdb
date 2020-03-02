namespace IMDB.EntityModels
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

        //public Serie Serie
        //{
        //    get;
        //    set;
        //}

        //   public int IdActor { get; set; }

        //  public int IdMovie { get; set; }
    }
}
