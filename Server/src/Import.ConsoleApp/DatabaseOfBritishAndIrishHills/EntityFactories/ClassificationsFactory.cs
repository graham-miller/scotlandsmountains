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
                new Classification {Name = Classification.Munro},
                new Classification {Name = Classification.MunroTop},
                new Classification {Name = Classification.Corbett},
                new Classification {Name = Classification.CorbettTop},
                new Classification {Name = Classification.Graham},
                new Classification {Name = Classification.GrahamTop},
                new Classification {Name = Classification.Murdo},
                new Classification {Name = Classification.Donald},
                new Classification {Name = Classification.DonaldDewey},
                new Classification {Name = Classification.HighlandFive}
            };
        }

        public IList<Classification> Classifications { get; internal set; }
    }
}
