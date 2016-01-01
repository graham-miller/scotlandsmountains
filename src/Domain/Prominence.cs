using System;
using System.Linq.Expressions;

namespace ScotlandsMountains.Domain
{
    public class Prominence
    {
        public virtual Height Drop { get; set; }

        private MeasuredFromFeature _measuredFromFeature;
        private MeasuredFromCol _measuredFromCol;

        public virtual MeasuredFrom MeasuredFrom
        {
            get { return (MeasuredFrom)_measuredFromCol ?? _measuredFromFeature; }
            set
            {
                var measuredFrom = value as MeasuredFromCol;
                if (measuredFrom == null)
                    _measuredFromFeature = (MeasuredFromFeature)value;
                else
                    _measuredFromCol = (MeasuredFromCol)value;
            }
        }

        /// <summary>
        /// Provides access to private fields required by NHibernate
        /// <see cref="https://github.com/jagregory/fluent-nhibernate/wiki/Mapping-private-properties#nested-expression-exposition-class"/>
        /// </summary>
        public static class Expressions
        {
            public static readonly Expression<Func<Prominence, MeasuredFromFeature>> MeasuredFromFeature = x => x._measuredFromFeature;
            public static readonly Expression<Func<Prominence, MeasuredFromCol>> MeasuredFromCol = x => x._measuredFromCol;
        }   
    }
}