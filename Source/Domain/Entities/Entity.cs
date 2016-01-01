namespace ScotlandsMountains.Domain.Entities
{
    public abstract class Entity
    {
        public virtual int Id { get; protected set; }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo))
                return true;

            if (compareTo == null)
                return false;

            if (IsTransient() || compareTo.IsTransient())
                return false;

            return Id == compareTo.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        protected bool Equals(Entity other)
        {
            return Equals((object)other);
        }

        public virtual bool IsTransient()
        {
            return Id == 0;
        }
    }
}
