using Newtonsoft.Json;
using System.Text;

namespace Challenge.Infrastructure.Models
{
    public abstract class BlobModelBase
    {
        public BlobModelBase() { }

        public string ToJson() => JsonConvert.SerializeObject(this);
        public MemoryStream Serialize() => new(Encoding.UTF8.GetBytes(ToJson()));
    }
}