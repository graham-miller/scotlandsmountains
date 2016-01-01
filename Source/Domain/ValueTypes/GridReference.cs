using System;
using System.Text.RegularExpressions;

namespace ScotlandsMountains.Domain.ValueTypes
{
    public class GridReference
    {
        public GridReference() { }

        public GridReference(string gridReference)
        {
            if (gridReference == null) throw new ArgumentNullException("gridReference", "GridReference construction argument cannot be null.");

            if (!IsValidGridReference(gridReference)) throw new ArgumentException("GridReference construction argument must be in the format \"[S|T|N|H|O][A-Z, not I]9999999999\".");

            Letters = gridReference.Substring(0, 2);
            Eastings = gridReference.Substring(2, 5);
            Northings = gridReference.Substring(7, 5);
        }

        public virtual string Letters { get; private set; }
        public virtual string Eastings { get; private set; }
        public virtual string Northings { get; private set; }

        private bool IsValidGridReference(string gridReference)
        {
            var regex = new Regex(@"^[S,T,N,H,O][A,B,C,D,E,F,G,H,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z][0-9]{10}\z");
            return regex.Match(gridReference).Success;
        }
    }
}
