using Newtonsoft.Json;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Challenge.Infrastructure.Models
{
    public class RequestModelBase
    {
        public IDictionary<string, string> ToHeader([CallerMemberName] string callerMemberName = null)
        {
            var headers = new Dictionary<string, string>();

            headers.TryAdd(nameof(callerMemberName), callerMemberName);

            var props = GetType().GetProperties();

            foreach (PropertyInfo prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);

                foreach (object attr in attrs)
                {
                    if (attr is Header header)
                    {
                        string key = header.Name ?? prop.Name;

                        string value = prop.GetValue(this)?.ToString();

                        headers.Add(key, value);
                    }
                }
            }

            return headers;
        }

        public string ToRoute(string url)
        {
            var args = new List<string>();

            var props = GetType().GetProperties();

            foreach (PropertyInfo prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);

                foreach (object attr in attrs)
                {
                    if (attr is Route route)
                    {
                        int? position = route.Position;

                        string value = prop.GetValue(this)?.ToString();

                        args.Insert(position ?? args.Count, value);
                    }
                }
            }

            return string.Format(url, args.ToArray()); ;
        }

        public IDictionary<string, string> ToQuery()
        {
            var queries = new Dictionary<string, string>();

            var props = GetType().GetProperties();

            foreach (PropertyInfo prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);

                foreach (object attr in attrs)
                {
                    if (attr is Query query)
                    {
                        string key = query.Name ?? prop.Name;

                        string value = query.ToString(prop.GetValue(this));

                        queries.Add(key, value);
                    }
                }
            }

            return queries;
        }

        public string ToJson() => JsonConvert.SerializeObject(this);
        public StringContent Serialize() => new(ToJson(), Encoding.UTF8, "application/json");
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class Query : Attribute
    {
        public string Name { get; set; }
        public string Format { get; set; }

        public Query(string name = null, string format = "yyyy-MM-ddTHH:mm:ssZ")
        {
            Name = name;
            Format = format;
        }

        public string ToString(object obj)
        {
            if (obj is not null)
            {
                if (obj.GetType() == typeof(DateTimeOffset))
                {
                    return ((DateTimeOffset)obj).ToString(Format);
                }

                if (obj.GetType() == typeof(DateTime))
                {
                    return ((DateTime)obj).ToString(Format);
                }

                if (obj.GetType() != typeof(string) && obj.GetType().GetInterfaces().Any(i => i.IsGenericType &&
                    i.GetGenericTypeDefinition() == typeof(IEnumerable<>)))
                {
                    return string.Join(',', (IEnumerable<object>)obj);
                }
            }

            return obj?.ToString();
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class Route : Attribute
    {
        public int? Position { get; set; }

        public Route(int position = -1)
        {
            Position = position == -1 ? null : position;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class Header : Attribute
    {
        public string Name { get; set; }

        public Header(string name = null)
        {
            Name = name;
        }
    }
}