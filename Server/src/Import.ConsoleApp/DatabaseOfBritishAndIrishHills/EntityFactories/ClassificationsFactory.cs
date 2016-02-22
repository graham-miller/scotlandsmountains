using System.Collections.Generic;
using ScotlandsMountains.Domain.Entities;

namespace ScotlandsMountains.Import.ConsoleApp.DatabaseOfBritishAndIrishHills.EntityFactories
{
    public class ClassificationsFactory
    {
        public ClassificationsFactory(HashIds hashIds)
        {
            Classifications = new List<Classification>
            {
                new Classification {Key = hashIds.Next(), Name = Classification.Munro},
                new Classification {Key = hashIds.Next(), Name = Classification.MunroTop},
                new Classification {Key = hashIds.Next(), Name = Classification.Corbett},
                new Classification {Key = hashIds.Next(), Name = Classification.CorbettTop},
                new Classification {Key = hashIds.Next(), Name = Classification.Graham},
                new Classification {Key = hashIds.Next(), Name = Classification.GrahamTop},
                new Classification {Key = hashIds.Next(), Name = Classification.Murdo},
                new Classification {Key = hashIds.Next(), Name = Classification.Donald},
                new Classification {Key = hashIds.Next(), Name = Classification.DonaldDewey},
                new Classification {Key = hashIds.Next(), Name = Classification.HighlandFive}
            };
        }

        public IList<Classification> Classifications { get; internal set; }
    }
}
