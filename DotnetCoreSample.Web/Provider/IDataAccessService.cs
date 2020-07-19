using System.Collections.Generic;

namespace DotnetCore.Platform.DataAccess
{
    public interface IDataAccessService
    {
        IEnumerable<T> GetAll<T>();

        void Query();

        int GetCount();
    }
}