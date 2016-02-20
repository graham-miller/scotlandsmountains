using System.Collections.Generic;
using ScotlandsMountains.Domain.Entities;

namespace ScotlandsMountains.Import.ConsoleApp.DatabaseOfBritishAndIrishHills.EntityFactories
{
    public class ClassificationsFactory
    {
        public ClassificationsFactory()
        {
            Classifications = new List<Classification>
            {
                new Classification {Name = Domain.Constants.Classifications.Munro},
                new Classification {Name = Domain.Constants.Classifications.MunroTop},
                new Classification {Name = Domain.Constants.Classifications.Corbett},
                new Classification {Name = Domain.Constants.Classifications.CorbettTop},
                new Classification {Name = Domain.Constants.Classifications.Graham},
                new Classification {Name = Domain.Constants.Classifications.GrahamTop},
                new Classification {Name = Domain.Constants.Classifications.Murdo},
                new Classification {Name = Domain.Constants.Classifications.Donald},
                new Classification {Name = Domain.Constants.Classifications.DonaldDewey},
                new Classification {Name = Domain.Constants.Classifications.HighlandFive}
            };
        }

        public IList<Classification> Classifications { get; internal set; }
    }
}
