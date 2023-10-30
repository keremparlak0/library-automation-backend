using Models.Entities.Contracts;

namespace Models.Entities
{
    public class BaseEntity : IEntity
    {
        public int Id { get; set; }
        public DateTime CratedAt { get; set; } = DateTime.Now;
    }
}
