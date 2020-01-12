using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using devWebFeed.Model;
using MediaManager;
using Newtonsoft.Json;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace devWebFeed
{
    public partial class PodcastDetailPage : ContentPage
    {
        private HttpClient _client = new HttpClient();
        public PodcastDetailPage(string channel_uuid)
        {
            InitializeComponent();
            OnGetList(channel_uuid);
        }

        protected async void OnGetList(string channel_uuid)
        {
            string Url = $"https://listen-api.listennotes.com/api/v2/podcasts/{channel_uuid}?sort=recent_first";
            if (CrossConnectivity.Current.IsConnected)
            {
                try
                {
                    episodesLV.BeginRefresh();
                    _client.DefaultRequestHeaders.Add("X-ListenAPI-Key", "693b1ec7d6a8489bbf99a16859b7c5eb");
                    var content = await _client.GetStringAsync(Url);
                    PodcastDetail playlistObj = JsonConvert.DeserializeObject<PodcastDetail>(content);
                    List<Episode> listOfEpisodes= playlistObj.episodes;
                    ObservableCollection<Episode> OcOfEpisodes = new ObservableCollection<Episode>(listOfEpisodes);
                    episodesLV.ItemsSource = OcOfEpisodes;
                    episodesLV.EndRefresh();

                }
                catch (Exception ey)
                {
                    Debug.WriteLine("" + ey);
                }
            }
        }

        async void Handle_Tapped(object sender, EventArgs e)
        {
            var args = (TappedEventArgs)e;
            var myObject = args.Parameter;
            await CrossMediaManager.Current.Play(myObject.ToString());
        }
    }
}
