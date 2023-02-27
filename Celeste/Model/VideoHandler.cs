using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using ScottPlot.Plottable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Celeste.Model
{
    public class Video
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Url { get; set; }

        public System.Drawing.Image Thumbnail { get; set; }

        public override string ToString()
        {
            return Title;
        }


    }
    public class VideoHandler
    {
        public List<Video> SearchVideos(string query)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyCSpZJjZ6hCqd-ieIbdjZlf509V_9kQaIo",
                ApplicationName = "Celeste"
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = query; // Replace with your search query.
            searchListRequest.MaxResults = 10;

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
                        Title = searchResult.Snippet.Title
                    });
                }

            }


            return videos;
        }


    }


}
