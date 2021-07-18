using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace IMDBModelID
{
    // Thanks to https://json2csharp.com/ for making this for us.
    // Root myDeserializedClass = JsonSerializer.Deserialize<IMDBModelClassID>(myJsonResponse);
    public class Image
    {
        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("width")]
        public int Width { get; set; }
    }

    public class Title
    {
        [JsonPropertyName("@type")]
        public string Type { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("image")]
        public Image Image { get; set; }

        [JsonPropertyName("runningTimeInMinutes")]
        public int RunningTimeInMinutes { get; set; }

        [JsonPropertyName("title")]
        public string Titled { get; set; }

        [JsonPropertyName("titleType")]
        public string TitleType { get; set; }

        [JsonPropertyName("year")]
        public int Year { get; set; }
    }

    public class US
    {
        [JsonPropertyName("certificate")]
        public string Certificate { get; set; }

        [JsonPropertyName("certificateNumber")]
        public int CertificateNumber { get; set; }

        [JsonPropertyName("ratingReason")]
        public string RatingReason { get; set; }

        [JsonPropertyName("ratingsBody")]
        public string RatingsBody { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }
    }

    public class Certificates
    {
        [JsonPropertyName("US")]
        public List<US> US { get; set; }
    }

    public class Ratings
    {
        [JsonPropertyName("canRate")]
        public bool CanRate { get; set; }

        [JsonPropertyName("rating")]
        public double Rating { get; set; }

        [JsonPropertyName("ratingCount")]
        public int RatingCount { get; set; }

        [JsonPropertyName("topRank")]
        public int TopRank { get; set; }
    }

    public class PlotOutline
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }
    }

    public class PlotSummary
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }
    }

    public class IMDBModelClassID
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("title")]
        public Title Title { get; set; }

        [JsonPropertyName("certificates")]
        public Certificates Certificates { get; set; }

        [JsonPropertyName("ratings")]
        public Ratings Ratings { get; set; }

        [JsonPropertyName("genres")]
        public List<string> Genres { get; set; }

        [JsonPropertyName("releaseDate")]
        public string ReleaseDate { get; set; }

        [JsonPropertyName("plotOutline")]
        public PlotOutline PlotOutline { get; set; }

        [JsonPropertyName("plotSummary")]
        public PlotSummary PlotSummary { get; set; }
    }

}
