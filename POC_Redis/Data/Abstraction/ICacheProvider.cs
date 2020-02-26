using System.Threading.Tasks;

namespace POC_Redis.Data.Abstraction
{
    public interface ICacheProvider
    {
        void SaveData(string data);

        Task<CacheData> GetValue();
    }
}
