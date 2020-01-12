using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using Newtonsoft.Json;
using Plugin.Connectivity;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace devWebFeed
{
    public partial class TrendingPage : ContentPage
    {
        // This handles the Web data request
        private HttpClient _client = new HttpClient();
        ObservableCollection<Repository> OcOfRepositories;
        public TrendingPage()
        {
            InitializeComponent();
            On<iOS>().SetUseSafeArea(true);
            OnGetList("", "daily", "en");
        }

        protected async void OnGetList(string language, string since, string local)
        {
            string Url = $"https://github-trending-api.now.sh/repositories?language={language}&since={since}&spoken_language_code={local}";
            if (CrossConnectivity.Current.IsConnected)
            {
                try
                {
                    repositoriesLV.BeginRefresh();
                    var content = await _client.GetStringAsync(Url);
                    List<Repository> listOfRepositories = JsonConvert.DeserializeObject<List<Repository>>(content);
                    OcOfRepositories = new ObservableCollection<Repository>(listOfRepositories);
                    repositoriesLV.ItemsSource = OcOfRepositories;
                    repositoriesLV.EndRefresh();

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

        void LanguageSelected(object sender, EventArgs e)
        {
            //Method call every time when picker selection changed.
            var selectedValue = LanguagePicker.Items[LanguagePicker.SelectedIndex];
            OnGetList(selectedValue, "daily", "en");
        }

        void SinceSelected(object sender, EventArgs e)
        {
            //Method call every time when picker selection changed.
            var selectedValue = SincePicker.Items[SincePicker.SelectedIndex];
            OnGetList(LanguagePicker.Items[LanguagePicker.SelectedIndex], selectedValue, "en");
        }

        //void LocalSelected(object sender, EventArgs e)
        //{
        //    //Method call every time when picker selection changed.
        //    var selectedValue = LocalPicker.Items[LocalPicker.SelectedIndex];
        //    OnGetList(LanguagePicker.Items[LanguagePicker.SelectedIndex], "daily", selectedValue);
        //}
    }
}
