namespace minimalProject.Core.Domains.User
{
    public class IpDetect
    {
        public int Id { get; set; }
        public string ip { get; set; }
        public string type { get; set; }
        public string continent_code { get; set; }
        public string continent_name { get; set; }

        public string country_code { get; set; }
        public string country_name { get; set; }
        public string region_code { get; set; }
        public string region_name { get; set; }
        public string city { get; set; }
        public string zip { get; set; }

        public double latitude { get; set; }
        public double longitude { get; set; }
        //"location":{
        //   "geoname_id":5125771,
        //   "capital":"Washington D.C.",
        //   "languages":[
        //      {
        //         "code":"en",
        //         "name":"English",
        //         "native":"English"
        //      }
        //   ],
        public string country_flag { get; set; }
        public string country_flag_emoji { get; set; }
        public string country_flag_emoji_unicode { get; set; }
        public string calling_code { get; set; }
        public bool is_eu { get; set; }
    }
}
