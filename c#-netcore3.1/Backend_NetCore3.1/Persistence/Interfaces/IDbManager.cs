using System.Data.Common;

namespace Persistence.Interfaces
{
    public interface IDbManager
    {
        DbConnection GetConnection();
    }
}
