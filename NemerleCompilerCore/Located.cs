namespace Nemerle.Compiler
{
    public class Located
    {
        private  Location loc;

        public Located()
        {
            loc = default(Location);
        }

        public Located(Location loc)
        {
            this.loc = loc;
        }

        public bool IsGenerated => loc.IsGenerated;

        public virtual Location Location
        {
            get => loc;
            set => loc = value;
        }
    }
}