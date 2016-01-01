using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Text;
using ScotlandsMountains.Data.Configurations;
using ScotlandsMountains.Data.Conventions;
using ScotlandsMountains.Domain.Entities;
using ScotlandsMountains.Domain.Entities.Maps;

namespace ScotlandsMountains.Data
{
    public interface IScotlandsMountainsContext
    {
        IDbSet<Country> Countries { get; }
        IDbSet<Classification> Classifications { get; }
        IDbSet<Region> Regions { get; }
        IDbSet<Mountain> Mountains { get; }

        int SaveChanges();
    }

    public class ScotlandsMountainsContext : DbContext, IScotlandsMountainsContext
    {
        public ScotlandsMountainsContext() : base("ScotlandsMountains") { }

        public ScotlandsMountainsContext(string connectionString) : base(connectionString) { }

        public IDbSet<Country> Countries { get { return Set<Country>(); } }

        public IDbSet<Classification> Classifications { get { return Set<Classification>(); } }

        public IDbSet<Region> Regions { get { return Set<Region>(); } }

        public IDbSet<Map> Maps { get { return Set<Map>(); } }

        public IDbSet<Mountain> Mountains { get { return Set<Mountain>(); } }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException exception)
            {
                throw FormattedEntityValidationErrors(exception);
            }
        }

        private static DbEntityValidationException FormattedEntityValidationErrors(DbEntityValidationException exception)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Entity validation failed:");

            foreach (var failure in exception.EntityValidationErrors)
            {
                stringBuilder.AppendLine(String.Format("{0} failed validation", failure.Entry.Entity.GetType()));
                
                foreach (var error in failure.ValidationErrors)
                    stringBuilder.AppendLine(String.Format("- {0} : {1}", error.PropertyName, error.ErrorMessage));
            }

            throw new DbEntityValidationException(stringBuilder.ToString(), exception);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(typeof (MountainConfiguration).Assembly);
            modelBuilder.Conventions.AddFromAssembly(typeof(ForeignKeyNameConvention).Assembly);
        }

        public ObjectContext ObjectContext { get { return ((IObjectContextAdapter)this).ObjectContext; } }
    }
}
