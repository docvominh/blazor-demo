using System.Text.Json;
using System.Text.Json.Serialization;

namespace TheWeatherLibrary.Components.Weather.Services;

public class WeatherApiDateTimeConverter : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateTime.ParseExact(reader.GetString()!, "yyyy-MM-dd H:mm", null);
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("yyyy-MM-dd H:mm"));
    }
}