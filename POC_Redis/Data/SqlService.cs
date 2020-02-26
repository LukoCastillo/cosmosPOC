using POC_Redis.Data.Abstraction;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace POC_Redis.Data
{
    public class SqlService : ICacheProvider
    {
        public POCDBContext _context;
        public SqlService(POCDBContext context)
        {
            _context = context;
        }

        public void SaveData(string data)
        {
            _context.KeyValues.Add(new KeyValue { Key = "key1", Value = data });
            _context.SaveChanges();
        }

        public Task<CacheData> GetValue()
        {
            var stopwatch = Stopwatch.StartNew();
            var key =  _context.KeyValues.Where(item => item.Key.Equals("Key1")).FirstOrDefault();
            stopwatch.Stop();
            var result = new CacheData()
            {
                key = "key1",
                value = key.Value,
                time = stopwatch.Elapsed.ToString()
            };
            return Task.FromResult(result);
        }
    }
}
