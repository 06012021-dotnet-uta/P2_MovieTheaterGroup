using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace IMDBModel
{
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class I
    {
        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("width")]
        public int Width { get; set; }
    }

    public class V
    {
        [JsonPropertyName("i")]
        public I I { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("l")]
        public string L { get; set; }

        [JsonPropertyName("s")]
        public string S { get; set; }
    }

    public class D
    {
        [JsonPropertyName("i")]
        public I I { get; set; }

        [JsonPropertyName("id")]
        public string MovieId { get; set; }

        [JsonPropertyName("l")]
        public string L { get; set; }

        [JsonPropertyName("q")]
        public string Q { get; set; }

        [JsonPropertyName("rank")]
        public int Rank { get; set; }

        [JsonPropertyName("s")]
        public string S { get; set; }

        [JsonPropertyName("v")]
        public List<V> V { get; set; }

        [JsonPropertyName("vt")]
        public int Vt { get; set; }

        [JsonPropertyName("y")]
        public int Y { get; set; }

        [JsonPropertyName("yr")]
        public string Yr { get; set; }
    }

    public class IMDBModelClass
    {
        [JsonPropertyName("d")]
        public List<D> D { get; set; }

        [JsonPropertyName("q")]
        public string Q { get; set; }

        [JsonPropertyName("v")]
        public int V { get; set; }
    }


}
