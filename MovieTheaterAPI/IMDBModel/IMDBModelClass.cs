using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace IMDBModel
{
    // Thanks to https://json2csharp.com/ for making this for us.
    // Root myDeserializedClass = JsonSerializer.Deserialize<IMDBModelClass>(myJsonResponse);
    public class Meta
    {
        [JsonPropertyName("operation")]
        public string Operation { get; set; }

        [JsonPropertyName("requestId")]
        public string RequestId { get; set; }

        [JsonPropertyName("serviceTimeMs")]
        public double ServiceTimeMs { get; set; }
    }

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

    public class Role
    {
        [JsonPropertyName("character")]
        public string Character { get; set; }

        [JsonPropertyName("characterId")]
        public string CharacterId { get; set; }
    }

    public class Principal
    {
        [JsonPropertyName("disambiguation")]
        public string Disambiguation { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("legacyNameText")]
        public string LegacyNameText { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("characters")]
        public List<string> Characters { get; set; }

        [JsonPropertyName("endYear")]
        public int EndYear { get; set; }

        [JsonPropertyName("episodeCount")]
        public int EpisodeCount { get; set; }

        [JsonPropertyName("roles")]
        public List<Role> Roles { get; set; }

        [JsonPropertyName("startYear")]
        public int StartYear { get; set; }

        [JsonPropertyName("billing")]
        public int? Billing { get; set; }

        [JsonPropertyName("attr")]
        public List<string> Attr { get; set; }

        [JsonPropertyName("as")]
        public string As { get; set; }
    }

    public class Cast
    {
        [JsonPropertyName("billing")]
        public int Billing { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("characters")]
        public List<string> Characters { get; set; }

        [JsonPropertyName("roles")]
        public List<Role> Roles { get; set; }

        [JsonPropertyName("endYear")]
        public int? EndYear { get; set; }

        [JsonPropertyName("episodeCount")]
        public int? EpisodeCount { get; set; }

        [JsonPropertyName("startYear")]
        public int? StartYear { get; set; }
    }

    public class Summary
    {
        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("characters")]
        public List<string> Characters { get; set; }

        [JsonPropertyName("displayYear")]
        public string DisplayYear { get; set; }
    }

    public class Crew
    {
        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("job")]
        public string Job { get; set; }
    }

    public class KnownFor
    {
        [JsonPropertyName("cast")]
        public List<Cast> Cast { get; set; }

        [JsonPropertyName("summary")]
        public Summary Summary { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("titleType")]
        public string TitleType { get; set; }

        [JsonPropertyName("year")]
        public int Year { get; set; }

        [JsonPropertyName("crew")]
        public List<Crew> Crew { get; set; }
    }

    public class ParentTitle
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("titleType")]
        public string TitleType { get; set; }

        [JsonPropertyName("year")]
        public int Year { get; set; }

        [JsonPropertyName("image")]
        public Image Image { get; set; }
    }

    public class Result
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("image")]
        public Image Image { get; set; }

        [JsonPropertyName("runningTimeInMinutes")]
        public int RunningTimeInMinutes { get; set; }

        [JsonPropertyName("nextEpisode")]
        public string NextEpisode { get; set; }

        [JsonPropertyName("numberOfEpisodes")]
        public int NumberOfEpisodes { get; set; }

        [JsonPropertyName("seriesStartYear")]
        public int SeriesStartYear { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("titleType")]
        public string TitleType { get; set; }

        [JsonPropertyName("year")]
        public int Year { get; set; }

        [JsonPropertyName("principals")]
        public List<Principal> Principals { get; set; }

        [JsonPropertyName("legacyNameText")]
        public string LegacyNameText { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("seriesEndYear")]
        public int? SeriesEndYear { get; set; }

        [JsonPropertyName("akas")]
        public List<string> Akas { get; set; }

        [JsonPropertyName("knownFor")]
        public List<KnownFor> KnownFor { get; set; }

        [JsonPropertyName("parentTitle")]
        public ParentTitle ParentTitle { get; set; }

        [JsonPropertyName("previousEpisode")]
        public string PreviousEpisode { get; set; }

        [JsonPropertyName("episode")]
        public int? Episode { get; set; }

        [JsonPropertyName("season")]
        public int? Season { get; set; }
    }

    public class IMDBModelClass
    {
        [JsonPropertyName("@meta")]
        public Meta Meta { get; set; }

        [JsonPropertyName("@type")]
        public string Type { get; set; }

        [JsonPropertyName("query")]
        public string Query { get; set; }

        [JsonPropertyName("results")]
        public List<Result> Results { get; set; }

        [JsonPropertyName("types")]
        public List<string> Types { get; set; }
    }
}

