//using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

//using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static TestDatasets.DeserializedClass;

namespace TestDatasets
{

    public class ImageEditor : Form
    {
        private PictureBox pictureBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button nextButton;
        private Bitmap originalImage;
        private string outputUrl;
        private System.Windows.Forms.ListBox detectionListbox;

        public ImageEditor(string imagePath, string outputURl, List<Prediction> coordinates, string time, int detectedObj)
        {
            outputUrl = outputURl;
            // Initialisiere die Form
            this.Text = imagePath.Substring(imagePath.LastIndexOf("\\") + 1) + $" / @time: {time}" + $" / detected objects: {detectedObj}";
            this.Size = new System.Drawing.Size(800, 600);
            this.BackColor = Color.LightBlue;

            // Erstelle die Listbox
            detectionListbox = new System.Windows.Forms.ListBox
            {
                BackColor = Color.AntiqueWhite,
                Dock = DockStyle.Top,
            };
            this.Controls.Add(detectionListbox);

            Processing proc = new Processing();
            //detectionListbox.Items.Add(proc.CountUniqueElements(coordinates));
            foreach (var el in proc.CountUniqueElements(coordinates))
            {
                detectionListbox.Items.Add(el);
            }

            // Erstelle die PictureBox
            pictureBox = new PictureBox
            {
                BackColor = Color.LightBlue,
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.Zoom//.StretchImage
            };
            this.Controls.Add(pictureBox);

            // Erstelle den Speichern-Button
            saveButton = new System.Windows.Forms.Button
            {
                Text = "Save picture",
                Dock = DockStyle.Top
            };
            saveButton.Click += SaveButton_Click;
            this.Controls.Add(saveButton);
           
            // Initialize Next Button
            nextButton = new System.Windows.Forms.Button
            {
                Text = "Next",
                Dock = DockStyle.Top,
            };
            nextButton.Click += NextButton_Click;
            this.Controls.Add(nextButton);

            LoadImage(imagePath, coordinates);

            this.FormClosing += (sender, e) =>
            {
                // Hier können Sie Code ausführen, bevor die Anwendung geschlossen wird
                // Zum Beispiel können Sie den Benutzer fragen, ob er sicher ist, dass er die Anwendung schließen möchte
                if (e.CloseReason == CloseReason.UserClosing && this.ActiveControl.Text == "")
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to close the application?", "Confirm", MessageBoxButtons.YesNo);
                    if (result == DialogResult.No)
                    {
                        e.Cancel = true; // Verhindert das Schließen der Anwendung
                    }
                    else
                    {
                        Application.Restart(); //startet die Anweidung neu und man gelangt zum Hauptmenue
   
                    }
                }
            };
        }

         private void LoadImage(string imagePath, List<Prediction> coordinates)
         {

             using (MemoryStream memoryStream = new MemoryStream())
             {
                 // Bild laden und in den MemoryStream schreiben
                 using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                 {
                     fs.CopyTo(memoryStream);
                 }

                 // Setze die Position des MemoryStreams zurück
                 memoryStream.Position = 0;

                 // Lade das Bild aus dem MemoryStream
                 originalImage = new Bitmap(memoryStream);
                 pictureBox.Image = originalImage;

                 // Beispiel für eine Bearbeitung (z.B. Text hinzufügen)
                 using (Graphics graphics = Graphics.FromImage(originalImage))
                 {
                    DrawDynamicRectangles(coordinates, graphics);
                }
             }

         }

        private void DrawDynamicRectangles(List<Prediction> coordinates, Graphics graphic)
        {
            foreach (var rect in coordinates)
            {
                graphic.DrawRectangle(Pens.Red, (float)rect.x, (float)rect.y, (float)rect.width, (float)rect.height);
                //graphic.DrawString(rect.@class.ToString(), new Font("Arial", 8), Brushes.Red, new PointF((float)rect.x, (float)rect.x - 5));
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Save() 
        {
            string outputPath = outputUrl + @"\detectedObjects\" + Guid.NewGuid() + @"\modified_image.jpg"; // Pfad zum Speichern anpassen

            // Überprüfen, ob das Verzeichnis existiert
            string directoryPath = Path.GetDirectoryName(outputPath);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Bild speichern
            try
            {
                originalImage.Save(outputPath, ImageFormat.Jpeg);
                Processing proc = new Processing();
                List<string> listBoxItems = detectionListbox.Items.Cast<string>().ToList();
                proc.SaveListToXml(listBoxItems, outputPath.Substring(0,outputPath.LastIndexOf("\\")));
                MessageBox.Show("Bild erfolgreich gespeichert!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Speichern des Bildes: {ex.Message}");
            }

            //auch hier noch die detectierten daten des bildes als xml speichern...

        }

        /*static List<string> FindUniqueElements(List<string> list)
        {
            // Verwende ein HashSet, um die einzigartigen Elemente zu speichern
            HashSet<string> UniqueElements = new HashSet<string>(list);

            // Konvertiere das HashSet zurück in eine Liste
            return new List<string>(UniqueElements);
        }*/

    }
}
