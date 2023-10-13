namespace WebApi.Models.Abstract
{
    public interface IEntity
    {
        public int Id { get; set; }
        public DateTime CratedAt { get; set; }
    }
}
