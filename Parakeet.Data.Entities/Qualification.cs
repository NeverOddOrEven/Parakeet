namespace Parakeet.Data.Entities
{
    public class Qualification : IEntity
    {
        public virtual long? Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual bool Enabled { get; set; }
    }
}
