using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using ScottPlot.Plottable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http;

namespace Celeste.Model
{
    public class Video
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Url { get; set; }

        public Thumbnail Thumbnail { get; set; }
        
    }
    public class APIHandler
    {
        /// <summary>
        /// Returns a list of videos of type video. Returns empty list if query was empty. Remember,the just append the id to the standard watch url to get the link to the video.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public List<Video> SearchVideos(string query)
        {
            try
            {
                var youtubeService = new YouTubeService(new BaseClientService.Initializer()
                {
                    ApiKey = "****" //GET YO OWN KEY >:(,
                    ApplicationName = "Celeste"
                });

                var searchListRequest = youtubeService.Search.List("snippet");
                searchListRequest.Q = query; // Replace with your search query.
                searchListRequest.ChannelId = "UCkJEpR7JmS36tajD34Gp4VA"; //channel Id for psych2go
                searchListRequest.MaxResults = 12;

                // Call the search.list method to retrieve results matching the specified query term.
                var searchListResponse = searchListRequest.Execute();

                var videos = new List<Video>();
                foreach (var searchResult in searchListResponse.Items)
                {
                    if (searchResult.Id.Kind == "youtube#video")
                    {
                        videos.Add(new Video
                        {
                            Id = searchResult.Id.VideoId,
                            Title = WebUtility.HtmlDecode(searchResult.Snippet.Title),
                            Author = searchResult.Snippet.ChannelTitle,
                            Thumbnail = searchResult.Snippet.Thumbnails.Default__,
                        }
                        );
                    }
                }
                return videos;
            }
            catch (Exception)
            {
                throw new Exception("API_HANDLIER: ERROR");
            }

            
        }
    }

}
