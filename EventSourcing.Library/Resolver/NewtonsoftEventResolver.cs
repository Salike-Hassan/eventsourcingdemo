using EventSourcing.Library.Metadata;
using EventStore.ClientAPI;
using Newtonsoft.Json;
using QuadPay.Domain.Core;
using System.Text;

namespace EventSourcing.Library.Resolver;

public class NewtonsoftEventResolver : IEventResolver
{
    private static readonly Encoding JsonEncoding = new UTF8Encoding(false);


    private static readonly JsonSerializerSettings SerializerSettings = new JsonSerializerSettings
    {
        TypeNameHandling = TypeNameHandling.None,
        Formatting = Formatting.Indented,
        NullValueHandling = NullValueHandling.Include,
    };

    private readonly JsonSerializer serializer;
    private readonly IEnumerable<IMetadataResolver> headerResolvers;

    public NewtonsoftEventResolver()
    {
        this.serializer = JsonSerializer.Create(SerializerSettings);
    }

    public EventData Resolve(object @event, params KeyValuePair<string, string>[] extraHeaders)
    {
        var eventId = Guid.NewGuid();
        var eventType = @event.GetType();
        var data = this.Serialize(@event);
        var metadata = this.Serialize(extraHeaders);

        return new EventData(eventId, eventType.Name, true, data, metadata);
    }

    public Event Resolve(ResolvedEvent @event)
    {
        var eventType = @event.GetType();

        if (eventType == null)
        {
            return null;
        }

        var value = this.Deserialize<Event>(@event.Event.Data, eventType);

        if (value != null)
        {
            value.Version = @event.Event.EventNumber;

            value.Timestamp = DateTimeOffset.FromUnixTimeMilliseconds(@event.Event.CreatedEpoch);
        }

        return value;
    }

    public IDictionary<string, string> ResolveMetadata(ResolvedEvent @event)
    {
        if (@event.Event?.Metadata == null)
        {
            return null;
        }

        return this.Deserialize<Dictionary<string, string>>(@event.Event.Metadata);
    }

    public T Deserialize<T>(byte[] data, Type type = null)
        where T : class
    {
        if (type == null)
        {
            type = typeof(T);
        }

        using var memoryStream = new MemoryStream(data);
        using var streamReader = new StreamReader(memoryStream, JsonEncoding);
        using var jsonReader = new JsonTextReader(streamReader);
        return this.serializer.Deserialize(jsonReader, type) as T;
    }

    public byte[] Serialize(object value)
    {

        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream, JsonEncoding))
        {
            using var jsonWriter = new JsonTextWriter(streamWriter);
            this.serializer.Serialize(jsonWriter, value);
        }

        return memoryStream.ToArray();
    }
}

