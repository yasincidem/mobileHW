using System;
using System.Collections.Generic;

namespace devWebFeed.Model
{
    public class ExtraUrls
    {
        public string twitter { get; set; }
        public string url1 { get; set; }
        public string facebook { get; set; }
        public string url1_simple { get; set; }
    }

    public class ExtraUrls2
    {
        public string twitter { get; set; }
        public string url1 { get; set; }
        public string facebook { get; set; }
        public string url1_simple { get; set; }
    }

    public class Channel
    {
        public string title { get; set; }
        public string channel_uuid { get; set; }
        public string channel_image { get; set; }
        public string channel_image_big { get; set; }
        public string absolute_url { get; set; }
        public ExtraUrls2 extra_urls { get; set; }
        public string author { get; set; }
        public bool is_claimed { get; set; }
    }

    public class LatestEpisode
    {
        public string title { get; set; }
        public string episode_uuid { get; set; }
        public string absolute_url { get; set; }
        public string pub_date_humanized { get; set; }
        public string audio_play_url { get; set; }
        public string audio_play_url_extension { get; set; }
        public string audio { get; set; }
        public string audio_length_humanized { get; set; }
        public object updated_at_ms { get; set; }
        public object pub_date_ms { get; set; }
        public string pub_date_pretty { get; set; }
        public bool has_transcript { get; set; }
        public string episode_image { get; set; }
        public Channel channel { get; set; }
    }

    public class Item2
    {
        public string uuid { get; set; }
        public string channel_uuid { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string author { get; set; }
        public string channel_image { get; set; }
        public string channel_image_big { get; set; }
        public string website { get; set; }
        public int itunes_id { get; set; }
        public string source_url { get; set; }
        public object last_build_date_ms { get; set; }
        public string absolute_url { get; set; }
        public string rss { get; set; }
        public ExtraUrls extra_urls { get; set; }
        public bool is_claimed { get; set; }
        public bool explicit_content { get; set; }
        public string embed_url { get; set; }
        public object latest_episode_pub_date_ms { get; set; }
        public int episode_count { get; set; }
        public LatestEpisode latest_episode { get; set; }
    }

    public class AddedBy
    {
        public int id { get; set; }
        public string username { get; set; }
        public string full_name { get; set; }
        public bool has_email { get; set; }
    }

    public class Item
    {
        public int id { get; set; }
        public int playlist_item_type { get; set; }
        public Item2 item { get; set; }
        public object updated_at_ms { get; set; }
        public object created_at_ms { get; set; }
        public string created_at_humanized { get; set; }
        public string updated_at_humanized { get; set; }
        public int added_by_id { get; set; }
        public AddedBy added_by { get; set; }
    }

    public class Playlist
    {
        public List<Item> items { get; set; }
        public bool is_my_own_list { get; set; }
        public int item_type { get; set; }
        public int total { get; set; }
    }
}
