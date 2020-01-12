using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using devWebFeed.Model;
using Newtonsoft.Json;
using Plugin.Connectivity;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace devWebFeed
{
    public partial class FeedPage : ContentPage
    {
        // This handles the Web data request
        private HttpClient _client = new HttpClient();
        public FeedPage()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            OnGetList("2020");
        }

        protected async void OnGetList(string year)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                try
                {
                    string Url = $"https://devwebfeed.appspot.com/posts/{year}";
                    postsLV.BeginRefresh();
                    var content = await _client.GetStringAsync(Url);
                    List<Post> listOfPosts = JsonConvert.DeserializeObject<List<Post>>(content);

                    listOfPosts
                        .Where(post => post.submitted == DateTime.Today)
                        .ToList()
                        .ForEach(post => post.color = "Orange");


                    ObservableCollection<Post> OcOfPosts = new ObservableCollection<Post>(listOfPosts);
                    postsLV.EndRefresh();

                    postsLV.ItemsSource = OcOfPosts;

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
            await Browser.OpenAsync(myObject.ToString(), new BrowserLaunchOptions
            {
                LaunchMode = BrowserLaunchMode.SystemPreferred,
                TitleMode = BrowserTitleMode.Show,
                PreferredToolbarColor = Color.AliceBlue,
                PreferredControlColor = Color.Violet
            });
        }

        void YearSelected(object sender, EventArgs e)
        {
            //Method call every time when picker selection changed.
            var selectedValue = YearPicker.Items[YearPicker.SelectedIndex];
            OnGetList(selectedValue);
        }
    }
}
