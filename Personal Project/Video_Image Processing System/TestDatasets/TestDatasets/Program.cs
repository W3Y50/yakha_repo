using System.IO;
using System.Threading.Tasks;
using static TestDatasets.Processing;
using System.Windows.Forms;
using System.Linq;
using Newtonsoft.Json;
using static TestDatasets.DeserializedClass;
using System.Collections.Generic;
using System.Drawing;
using System;


namespace TestDatasets
{
    internal class Program
    {
        [STAThread] // Ensure STA mode is set
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());

            /*
            var extractor = new VideoFrameExtractor();
            
            //FilePicker für Videos einbauen ... 
            extractor.ExtractFrames("testvideo1.mp4", "C:\\Users\\Nutzer\\source\\repos\\TestDatasets\\videooutputs");

            //Get all extracted image files from the specified folder
            string[] imagePaths = Directory.GetFiles(@"C:\Users\Nutzer\source\repos\TestDatasets\videooutputs", "*.*", SearchOption.TopDirectoryOnly)
                                           .Where(s => s.EndsWith(".jpg") || s.EndsWith(".jpeg") || s.EndsWith(".png") || s.EndsWith(".bmp"))
                                           .ToArray();


            Processing proc = new Processing();

            //show all images with random draws
            foreach (var imagePath in imagePaths)
            {
                //Einzelne Frames/Images untersuchen lassen
               // proc.ProcessImage(imagePath);
                Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(proc.ProcessImage(imagePath));
                // die Coordinaten und was es ist als Json ausgeben lassen und einzeichenen, 
                // text was es ist und x sowie y an imageeditor übergeben...
                // eine logik implementieren die es ermöglicht eine Liste von Coordinaten zü übergen und
                // in dem jeweiligen Bild einzuzeichnen...
                List<Prediction> coordinates = myDeserializedClass.predictions;

                Application.Run(new ImageEditor(imagePath, coordinates, myDeserializedClass.time.ToString(), myDeserializedClass.predictions.Count));
                
            }*/


            //Application.Run(new MultiImageDisplay());



            //Dinge Ordnen...
            //Step 1 Video auswählen
            //Step 2 Video in Frames Zerteilen
            //Step 3 Frames per Api untersuchen lassen
            //

        }
    }
    
}
