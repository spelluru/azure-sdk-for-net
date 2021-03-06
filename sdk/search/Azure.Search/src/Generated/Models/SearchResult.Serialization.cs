// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Search.Models
{
    public partial class SearchResult : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Score != null)
            {
                writer.WritePropertyName("@search.score");
                writer.WriteNumberValue(Score.Value);
            }
            if (Highlights != null)
            {
                writer.WritePropertyName("@search.highlights");
                writer.WriteStartObject();
                foreach (var item in Highlights)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStartArray();
                    foreach (var item0 in item.Value)
                    {
                        writer.WriteStringValue(item0);
                    }
                    writer.WriteEndArray();
                }
                writer.WriteEndObject();
            }
            foreach (var item in this)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteObjectValue(item.Value);
            }
            writer.WriteEndObject();
        }
        internal static SearchResult DeserializeSearchResult(JsonElement element)
        {
            SearchResult result = new SearchResult();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("@search.score"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Score = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("@search.highlights"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.Highlights = new Dictionary<string, ICollection<string>>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        ICollection<string> value = new List<string>();
                        foreach (var item in property0.Value.EnumerateArray())
                        {
                            value.Add(item.GetString());
                        }
                        result.Highlights.Add(property0.Name, value);
                    }
                    continue;
                }
                result.Add(property.Name, property.Value.GetObject());
            }
            return result;
        }
    }
}
