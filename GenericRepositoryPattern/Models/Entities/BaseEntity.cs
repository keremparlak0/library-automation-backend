using WebApi.Models.Abstract;

namespace WebApi.Models.Entities
{
    public class BaseEntity : IEntity
    {
        public int Id { get; set; }
        public DateTime CratedAt { get; set; } = DateTime.Now;
    }
}
