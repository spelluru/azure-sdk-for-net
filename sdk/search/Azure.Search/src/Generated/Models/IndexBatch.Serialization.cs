// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.Search.Models
{
    public partial class IndexBatch : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("value");
            writer.WriteStartArray();
            foreach (var item in Actions)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }
        internal static IndexBatch DeserializeIndexBatch(JsonElement element)
        {
            IndexBatch result = new IndexBatch();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
                {
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        result.Actions.Add(IndexAction.DeserializeIndexAction(item));
                    }
                    continue;
                }
            }
            return result;
        }
    }
}
