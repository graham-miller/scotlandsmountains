using System;
using ScotlandsMountains.Domain;

namespace ScotlandsMountains.Web.Models
{
    public class ClassificationModel
    {
        public ClassificationModel()
        {
            throw new NotSupportedException("Parameterless constructor required by Json.NET but shouldn't be used otherwise");
        }

        public ClassificationModel(Classification entity)
        {
            Name = entity.Name;
        }

        public string Name { get; set; }
    }
}