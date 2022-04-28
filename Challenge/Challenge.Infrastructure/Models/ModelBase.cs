using Newtonsoft.Json;
using System.Text;

namespace Challenge.Infrastructure.Models;

public abstract class ModelBase
{
    public ModelBase() { }

    public string ToJson() => JsonConvert.SerializeObject(this);
    public StringContent Serialize() => new(ToJson(), Encoding.UTF8, "application/json");
}
