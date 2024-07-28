﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDatasets
{
    public class DeserializedClass
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Image
        {
            public int width { get; set; }
            public int height { get; set; }
        }

        public class Prediction
        {
            public double x { get; set; }
            public double y { get; set; }
            public double width { get; set; }
            public double height { get; set; }
            public double confidence { get; set; }
            public string @class { get; set; }
            public int class_id { get; set; }
            public string detection_id { get; set; }
        }

        public class Root
        {
            public string inference_id { get; set; }
            public double time { get; set; }
            public Image image { get; set; }
            public List<Prediction> predictions { get; set; }
        }

    }
}
