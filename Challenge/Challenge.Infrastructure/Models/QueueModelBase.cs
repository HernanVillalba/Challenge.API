using Newtonsoft.Json;
using System.Text;

namespace Challenge.Infrastructure.Models
{
    public abstract class QueueModelBase
    {
        protected QueueModelBase() { }

        public string ToJson() => JsonConvert.SerializeObject(this);

        public StringContent Serialize() => new(ToJson(), Encoding.UTF8, "application/json");
    }
}