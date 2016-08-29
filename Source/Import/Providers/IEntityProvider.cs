using System.Collections.Generic;
using ScotlandsMountains.Domain;

namespace ScotlandsMountains.Import.Providers
{
    public interface IEntityProvider<T> where T : Entity
    {
        IList<T> GetAll();
        T GetByDobihId(string dobihId);
    }
}