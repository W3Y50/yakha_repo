using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace ClassLibrary
{

    // SeismicEventModel myDeserializedClass = JsonConvert.DeserializeObject<SeismicEventModel>(myJsonResponse);
    public class Data
    {
        public string type { get; set; }
        public Geometry geometry { get; set; }
        public string id { get; set; }
        public Properties properties { get; set; }
    }

    public class Geometry
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
    }

    public class Properties
    {
        public string source_id { get; set; }
        public string source_catalog { get; set; }
        public DateTime lastupdate { get; set; }
        public DateTime time { get; set; }
        public string flynn_region { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public double depth { get; set; }
        public string evtype { get; set; }
        public string auth { get; set; }
        public double mag { get; set; }
        public string magtype { get; set; }
        public string unid { get; set; }
    }

    public class SeismicEventModel
    {
        public string action { get; set; }
        public Data data { get; set; }
    }

}


