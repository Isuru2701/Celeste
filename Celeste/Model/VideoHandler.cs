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

namespace Celeste.Model
{
    public class Video
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Url { get; set; }


        public Thumbnail Thumbnail { get; set; }

        public override string ToString()
        {
            return Title;
        }


    }
    public class VideoHandler
    {
        public List<string> AllowedChannels = new List<string> { "UCkJEpR7JmS36tajD34Gp4VA" };

        /// <summary>
        /// Returns a list of videos of type video. Returns empty list if query was empty
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public List<Video> SearchVideos(string query)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "AIzaSyCSpZJjZ6hCqd-ieIbdjZlf509V_9kQaIo",
                ApplicationName = "Celeste"
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = query; // Replace with your search query.
            searchListRequest.MaxResults = 5;

            var rand = new Random();
            //get 2 videos from each channel
            int perchannel = 2;
            var selectedChannelIds = AllowedChannels.OrderBy(x => rand.Next()).Take(perchannel);



            List<Video> videos = new List<Video> { };
            // Call the search.list method to retrieve results matching the specified query term.
            foreach (var channelId in selectedChannelIds)
            {
                searchListRequest = youtubeService.Search.List("snippet");
                searchListRequest.ChannelId = channelId;
                searchListRequest.MaxResults = perchannel;

                var searchListResponse = searchListRequest.Execute();

                if (searchListResponse.Items.Count > 0)
                {
                    foreach (var searchResult in searchListResponse.Items)
                    {
                        if (searchResult.Id.Kind == "youtube#video")
                        {
                            var video = new Video
                            {
                                Title = searchResult.Snippet.Title,
                                Id = searchResult.Id.VideoId,
                                Thumbnail = searchResult.Snippet.Thumbnails.Default__
                            };

                            videos.Add(video);
                        }
                    }

                }
            }
            return videos;

        }

    }
}
