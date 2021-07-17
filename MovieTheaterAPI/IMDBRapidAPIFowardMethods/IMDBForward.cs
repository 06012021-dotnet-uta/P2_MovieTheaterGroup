using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using MapperClasses;
using System.Net.Http.Json;
using IMDBModel;

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
                RequestUri = new Uri($"https://imdb8.p.rapidapi.com/auto-complete?q={searchformovie}"),
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
                if (body.D.Count() > 0)
                {
                    foreach (var movie in body.D)
                    {
                        if (movie.Q == "feature")
                        {
                            IMDBMapAdmin movieselected = new();
                            movieselected.MovieID = movie.MovieId;
                            movieselected.Title = movie.L;
                            movieselected.Actors = movie.S.Split(',');
                            if (movie.I != null)
                            {
                                movieselected.Image = movie.I.ImageUrl;
                            }
                            movielist.Add(movieselected);
                        }
                    }
                }
                return movielist;
            }
        }

        public async Task<List<IMDBMapAdmin>> IMDBMovieIDAsync(string searchformovie)
        {
            var client = new HttpClient();
            List<IMDBMapAdmin> movielist = new();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://imdb8.p.rapidapi.com/title/get-videos?tconst={searchformovie}&limit=25&region=US"),
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
                if (body.D.Count() > 0)
                {
                    foreach (var movie in body.D)
                    {
                        if (movie.Q == "feature")
                        {
                            IMDBMapAdmin movieselected = new();
                            movieselected.MovieID = movie.MovieId;
                            movieselected.Title = movie.L;
                            movieselected.Actors = movie.S.Split(',');
                            if (movie.I != null)
                            {
                                movieselected.Image = movie.I.ImageUrl;
                            }
                            movielist.Add(movieselected);
                        }
                    }
                }
                return movielist;
            }
        }
    }
}
