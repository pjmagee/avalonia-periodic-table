using System.Text.Json.Serialization;

namespace PeriodicTable.Models;

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public class YearDiscoveredConverter : JsonConverter<string>
{
    public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Number)
        {
            return reader.GetInt32().ToString();
        }

        if (reader.TokenType == JsonTokenType.String)
        {
            return reader.GetString();
        }
        throw new JsonException("Invalid token type for YearDiscovered");
    }

    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
    {
        if (int.TryParse(value, out int intValue))
        {
            writer.WriteNumberValue(intValue);
        }
        else
        {
            writer.WriteStringValue(value);
        }
    }
}

[JsonSerializable(typeof(Element))]
public class Element
{
    public int AtomicNumber { get; set; }
    public string Symbol { get; set; }
    public string Name { get; set; }
    public double? AtomicMass { get; set; }
    public string CPKHexColor { get; set; }
    public string ElectronConfiguration { get; set; }
    public double? Electronegativity { get; set; }
    public double? AtomicRadius { get; set; }
    public double? IonizationEnergy { get; set; }
    public double? ElectronAffinity { get; set; }
    public string OxidationStates { get; set; }
    public string StandardState { get; set; }
    public double? MeltingPoint { get; set; }
    public double? BoilingPoint { get; set; }
    public double? Density { get; set; }
    public string GroupBlock { get; set; }

    [JsonConverter(typeof(YearDiscoveredConverter))]
    public string YearDiscovered { get; set; }
    public GridPosition GridPosition { get; set; }
}

[JsonSerializable(typeof(GridPosition))]
public class GridPosition
{
    [JsonPropertyName("row")]
    public int Row { get; set; }

    [JsonPropertyName("col")]
    public int Col { get; set; }
}
