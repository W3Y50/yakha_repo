using System;
using System.IO;
using System.Drawing;
using System.Net;
using System.Net.Http;
using System.Text;
//using System.Diagnostics;
using MediaToolkit;
using MediaToolkit.Model;
using MediaToolkit.Options;
using System.Windows.Media.Imaging;
using System.Drawing.Imaging;
using Newtonsoft.Json;
using static TestDatasets.DeserializedClass;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Collections;

namespace TestDatasets
{
    internal class Processing
    {
        static readonly HttpClient client = new HttpClient();
        static readonly string apiKey = "wCQgFndcuy7wJAd4Ityo";
        public string ProcessImage(string imageURl, string model_endpoint)
        {
            // this code sucessfull inference a image
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("----------------------Start inference---------------------------");

            byte[] imageArray = System.IO.File.ReadAllBytes(imageURl);
            string encoded = Convert.ToBase64String(imageArray);
            byte[] data = Encoding.ASCII.GetBytes(encoded);
            string api_key = apiKey; // Your API Key
            //string model_endpoint = "nano-by-stephan-sturges/1"; // Set model endpoint

            // Construct the URL
            string uploadURL =
                    "https://detect.roboflow.com/" + model_endpoint + "?api_key=" + api_key
                + "&name=" + imageURl;

            // Service Request Config
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            // Configure Request
            WebRequest request = WebRequest.Create(uploadURL);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            // Write Data
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            // Get Response
            string responseContent = null;
            using (WebResponse response = request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader sr99 = new StreamReader(stream))
                    {
                        responseContent = sr99.ReadToEnd();
                    }
                }
            }

            Console.WriteLine(responseContent);
            Console.WriteLine("-------------------------------------------------");
            return (responseContent);
        }

        public async void ProcessVideo(string videoURl, string outputURl, string selectedModel, int frameRate, bool perFrame, string model)
        {

            var extractor = new VideoFrameExtractor();
            List<List<string>> wholeVideoDetects = new List<List<string>>();
            //FilePicker für Videos einbauen ... 
            //extractor.ExtractFrames("testvideo1.mp4", "C:\\Users\\Nutzer\\source\\repos\\TestDatasets\\videooutputs");
            extractor.ExtractFrames(videoURl, outputURl, frameRate);

            //Get all extracted image files from the output folder
            string[] imagePaths = Directory.GetFiles(outputURl, "*.*", SearchOption.TopDirectoryOnly)
                                           .Where(s => s.EndsWith(".jpg") || s.EndsWith(".jpeg") || s.EndsWith(".png") || s.EndsWith(".bmp"))
                                           .ToArray();


            Processing proc = new Processing();

            //show all images with random draws
            foreach (var imagePath in imagePaths)
            {

                //Einzelne Frames/Images untersuchen lassen
                // proc.ProcessImage(imagePath);
                Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(proc.ProcessImage(imagePath, model));
                // die Coordinaten und was es ist als Json ausgeben lassen und einzeichenen, 
                // text was es ist und x sowie y an imageeditor übergeben...
                // eine logik implementieren die es ermöglicht eine Liste von Coordinaten zü übergen und
                // in dem jeweiligen Bild einzuzeichnen...
                List<Prediction> coordinates = myDeserializedClass.predictions;

                // an der Stelle einen Bool machen ob per frame analysiert werden soll oder nicht?
                if (perFrame == true)
                {
                    Application.Run(new ImageEditor(imagePath, outputURl, coordinates, myDeserializedClass.time.ToString(), myDeserializedClass.predictions.Count));
                }
                else
                {
                    wholeVideoDetects.Add(CountUniqueElements(coordinates));
                    // wenn nicht umgehen und alle presictions analysieren ...und die unterschiedlichen elemente 
                    // zählen und ausgeben -anschließend als xml speichern.
                }

            }

            if (perFrame == false) 
            {
                StringBuilder sb = new StringBuilder();
                int i = 0;
                foreach (var item in wholeVideoDetects)
                {
                    i++;
                    sb.AppendLine("Frame " + i + ": ");

                    foreach (var itempiece in item)
                    {
                        sb.AppendLine(itempiece.ToString());
                    }

                    sb.AppendLine(" " );
                }

                CustomMessageBox csmsgBox = new CustomMessageBox(sb.ToString(), "Video/image detections:", MessageBoxButtons.YesNo);

                DialogResult result = csmsgBox.ShowDialog();

                // Handle the user's response
                if (result == DialogResult.Yes)
                {

                    List<string> stringList = sb.ToString()
                            .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                            .ToList();

                    proc.SaveListToXml(stringList, outputURl + @"\detectedObjects\" + Guid.NewGuid() + @"\AllDetectedObjects");
                    MessageBox.Show("Xml saved!");
                }

            }
        }


        public class VideoFrameExtractor
        {
            public void ExtractFrames(string inputFilePath, string outputDirectory, int frameRate)
            {
                // Ensure the output directory exists
                if (!Directory.Exists(outputDirectory))
                {
                    Directory.CreateDirectory(outputDirectory);
                }
                else
                { 
                    Directory.Delete(outputDirectory, true);
                    Directory.CreateDirectory(outputDirectory);
                }

                var inputFile = new MediaFile { Filename = inputFilePath };
                var engine = new Engine();

                // Get video metadata to determine duration
                engine.GetMetadata(inputFile);

                // Calculate the total duration in seconds
                int totalDurationInSeconds = (int)inputFile.Metadata.Duration.TotalSeconds;
                
                // Extract a frame like overgiven framerate e.g. every 5 seconds
                for (int i = 0; i <= totalDurationInSeconds; i += frameRate)
                {
                    var outputFile = new MediaFile { Filename = Path.Combine(outputDirectory, $"frame_{i:D4}.jpg") };

                    // Use GetThumbnail to extract a frame at the specified time (in seconds)
                    var options = new ConversionOptions { Seek = TimeSpan.FromSeconds(i) };
                    engine.GetThumbnail(inputFile, outputFile, options);
                }
            }         

        }

        public List<string> CountUniqueElements(List<Prediction> predList)
        {

            List<string> detectionList = new List<string>();
            Dictionary<int, string> detectionDict = new Dictionary<int, string>();
            Dictionary<string, int> elementCount = new Dictionary<string, int>();
            List<string> returnList = new List<string>();
            int i = 0;

            // Füge Elemente zur Detection-Liste und -Dictionary hinzu
            foreach (var element in predList)
            {
                detectionList.Add(element.@class);
                detectionDict.Add(i, element.@class);
                i++;
            }

            // Finde einzigartige Elemente
            HashSet<string> uniqueElements = new HashSet<string>(detectionList);

            // Zähle die Vorkommen der einzigartigen Elemente
            foreach (var uniqueElement in uniqueElements)
            {
                int count = 0;
                foreach (var dicElement in detectionDict.Values)
                {
                    if (dicElement == uniqueElement)
                    {
                        count++;
                    }
                }
                elementCount[uniqueElement] = count;
                returnList.Add($"{uniqueElement}: {count} times");
            }

            return returnList;
        }

        public void SaveListToXml<T>(List<T> list, string filePath)
        {
            // Ensure the output directory exists
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            else
            {
               // Directory.Delete(filePath, true);
                //Directory.CreateDirectory(filePath);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            using (FileStream stream = new FileStream(filePath + "\\myList.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(stream, list);
            }
        
        }

    }
}
