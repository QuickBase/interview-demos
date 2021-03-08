using System.Linq;

namespace Persistence.Interfaces
{
    public interface IDataRepository
    {
        T GetById<T>(int id) where T : DataModelBase;
    }
}
