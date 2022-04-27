namespace Challenge.Infrastructure.Configurations;

public class HttpConfiguration
{
    public virtual string UrlBase { get; set; }

    public HttpConfiguration() { }
}

[AttributeUsage(AttributeTargets.Property)]
public class Endpoint : Attribute
{
    public string Name { get; set; }

    public Endpoint(string name = null)
    {
        Name = name;
    }
}