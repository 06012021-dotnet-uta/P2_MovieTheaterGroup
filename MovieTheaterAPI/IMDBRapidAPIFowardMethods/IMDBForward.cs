using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using MapperClasses;
using System.Net.Http.Json;
using IMDBModel;
using IMDBModelID;

namespace IMDBRapidAPIFowardMethods
{
    public class IMDBForward : IIMDBForward
    {
        string auth = "097660fff6mshbf3bbda085b3705p15078ajsn26fe42704123";
        string thirdparty = "imdb8.p.rapidapi.com";
        public async Task<List<IMDBMapAdmin>> IMDBMovieTitleAsync(string searchformovie)
        {
            var client = new HttpClient();
            List<IMDBMapAdmin> movielist = new();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://imdb8.p.rapidapi.com/title/find?q={searchformovie}"),
                Headers =
                {
                    { "x-rapidapi-key", $"{auth}" },
                    { "x-rapidapi-host", $"{thirdparty}" },
                },
            };
            using (var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadFromJsonAsync<IMDBModelClass>();
                //var alsobody = await response.Content.ReadAsStringAsync();
                //dynamic stuff = JsonSerializer.Deserialize<dynamic>(body);
                if (body.Results.Count > 0)
                {
                    foreach (var movie in body.Results)
                    {
                        if (movie.TitleType == "movie")
                        {
                            IMDBMapAdmin movieselected = new();
                            movieselected.Actors = new List<string>();
                            movieselected.MovieID = movie.Id;
                            movieselected.Title = movie.Title;
                            movieselected.runtime = movie.RunningTimeInMinutes;
                            if (movie.Principals.Count() > 0)
                            {
                                foreach (var actor in movie.Principals)
                                {
                                    if (actor.Name != null)
                                    {
                                        movieselected.Actors.Add(actor.Name);
                                    }
                                }
                            }
                            if (movie.Image != null)
                            {
                                movieselected.Image = movie.Image.Url;
                            }
                            movielist.Add(movieselected);
                        }
                    }
                }
                return movielist;
            }
        }
        public async Task<IMDBMapAdmin> IMDBMovieIDAsync(string searchformovie)
        {
            var client = new HttpClient();
            IMDBMapAdmin movie = new();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://imdb8.p.rapidapi.com/title/get-overview-details?tconst={searchformovie}&currentCountry=US"),
                Headers =
                {
                    { "x-rapidapi-key", $"{auth}" },
                    { "x-rapidapi-host", $"{thirdparty}" },
                },
            };
            using (var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadFromJsonAsync<IMDBModelClassID>();
                //var alsobody = await response.Content.ReadAsStringAsync();
                //dynamic stuff = JsonSerializer.Deserialize<dynamic>(body);
                if (body.Id != null)
                {
                    if (body.PlotSummary != null)
                    {
                        movie.Summary = body.PlotSummary.Text;
                    }               
                }
                return movie;
            }
        }
    }
}
