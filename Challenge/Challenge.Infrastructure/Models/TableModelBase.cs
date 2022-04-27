using Azure;
using Azure.Data.Tables;

namespace Challenge.Infrastructure.Models
{
    public abstract class TableModelBase : ITableEntity
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}