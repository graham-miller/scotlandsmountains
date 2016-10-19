using ScotlandsMountains.Domain;

namespace ScotlandsMountains.Web.Server.Models
{
    public class EntityModel
    {
        public EntityModel(Entity entity)
        {
            Id = entity.Id;
            Name = entity.Name;
        }

        public string Id { get; set; }
        public string Name { get; set; }
    }
}
