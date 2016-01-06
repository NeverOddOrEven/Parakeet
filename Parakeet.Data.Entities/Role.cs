namespace Parakeet.Data.Entities
{
    public class Role : IEntity
    {
        public virtual long? Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }
}
