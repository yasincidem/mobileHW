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
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace devWebFeed
{
    public partial class PodcastPage : ContentPage
    {
        private HttpClient _client = new HttpClient();
        ObservableCollection<Item> OcOfPodcasts;
        public PodcastPage()
        {
            InitializeComponent();
            On<iOS>().SetUseSafeArea(true);
            OnGetList();

        }

        protected async void OnGetList()
        {
            string Url = $"https://www.listennotes.com/endpoints/v1/playlist/fetch_items/?playlist_uuid=01cd89e710c9412090bca31de02beae0&item_type=2&sort_type=recent_added_first";
            if (CrossConnectivity.Current.IsConnected)
            {
                try
                {
                    podcastsLV.BeginRefresh();
                    var content = await _client.GetStringAsync(Url);
                    Playlist playlistObj = JsonConvert.DeserializeObject<Playlist>(content);
                    List<Item> listOfPodcasts = playlistObj.items;
                    OcOfPodcasts = new ObservableCollection<Item>(listOfPodcasts);
                    podcastsLV.ItemsSource = OcOfPodcasts;
                    podcastsLV.EndRefresh();

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
            await Navigation.PushAsync(new PodcastDetailPage(myObject.ToString()));
            //await CrossMediaManager.Current.Play(myObject.ToString());
        }
    }
}
