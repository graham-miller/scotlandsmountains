using ScotlandsMountains.Domain.Entities;
using System.Linq;

namespace ScotlandsMountains.Web.Models
{
    public class Result
    {
        private Result() { }

        public static Result Create(Mountain mountain)
        {
            return new Result
            {
                Key = mountain.Key,
                Name = mountain.Name,
                Height = $"{mountain.Height.Metres.ToString("#,##0")}m ({mountain.Height.Feet.ToString("#,##0")}ft)",
                Classification = string.Join(", ", mountain.Classifications.Select(x => x.Name))
            };
        }

        public string Key { get; private set; }
        public string Name { get; private set; }
        public string Height { get; private set; }
        public string Classification { get; private set; }
    }
}
