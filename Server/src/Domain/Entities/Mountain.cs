using ScotlandsMountains.Domain.ValueTypes;

namespace ScotlandsMountains.Domain.Entities
{
    public class Mountain : Entity
    {
        public string DobihId { get; set; }
        public string Name { get; set; }

        public Height Height { get; set; }

        public Location Location { get; set; }
    }
}
