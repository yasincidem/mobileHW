using System;
using System.Collections.Generic;

namespace devWebFeed.Model
{
    public class Extra
    {
        public string twitter_handle { get; set; }
        public string facebook_handle { get; set; }
        public string instagram_handle { get; set; }
        public string wechat_handle { get; set; }
        public string patreon_handle { get; set; }
        public string youtube_url { get; set; }
        public string linkedin_url { get; set; }
        public string spotify_url { get; set; }
        public string google_url { get; set; }
        public string url1 { get; set; }
        public string url2 { get; set; }
        public string url3 { get; set; }
    }

    public class LookingFor
    {
        public bool sponsors { get; set; }
        public bool guests { get; set; }
        public bool cohosts { get; set; }
        public bool cross_promotion { get; set; }
    }

    public class Episode
    {
        public string id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public object pub_date_ms { get; set; }
        public string audio { get; set; }
        public int audio_length_sec { get; set; }
        public string listennotes_url { get; set; }
        public string image { get; set; }
        public string thumbnail { get; set; }
        public bool maybe_audio_invalid { get; set; }
        public string listennotes_edit_url { get; set; }
        public bool explicit_content { get; set; }
    }

    public class PodcastDetail
    {
        public string id { get; set; }
        public string title { get; set; }
        public string publisher { get; set; }
        public string image { get; set; }
        public string thumbnail { get; set; }
        public string listennotes_url { get; set; }
        public int total_episodes { get; set; }
        public bool explicit_content { get; set; }
        public string description { get; set; }
        public int itunes_id { get; set; }
        public string rss { get; set; }
        public long latest_pub_date_ms { get; set; }
        public long earliest_pub_date_ms { get; set; }
        public string language { get; set; }
        public string country { get; set; }
        public string website { get; set; }
        public Extra extra { get; set; }
        public bool is_claimed { get; set; }
        public string email { get; set; }
        public LookingFor looking_for { get; set; }
        public List<int> genre_ids { get; set; }
        public List<Episode> episodes { get; set; }
        public long next_episode_pub_date { get; set; }
    }
}
