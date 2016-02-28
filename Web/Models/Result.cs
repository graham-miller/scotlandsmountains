using ScotlandsMountains.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                Height = string.Format("{0}m ({1}ft)", mountain.Height.Metres.ToString("#,##0"), mountain.Height.Feet.ToString("#,##0")),
                Classification = string.Join(", ", mountain.Classifications.Select(x => x.Name))
            };
        }

        public string Key { get; private set; }
        public string Name { get; private set; }
        public string Height { get; private set; }
        public string Classification { get; private set; }
    }
}
