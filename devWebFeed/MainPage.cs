using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace devWebFeed
{

    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            this.Children.Add(new FeedPage() { Title = "Feed" });
            this.Children.Add(new TrendingPage() { Title = "Trending" });
            this.Children.Add(new PodcastPage() { Title = "Podcast" });
        }
    }
}
