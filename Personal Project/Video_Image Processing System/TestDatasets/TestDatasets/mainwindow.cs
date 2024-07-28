using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Threading.Tasks;
//using System.Web.UI.WebControls;
using System.Windows.Forms;
using TestDatasets;

public class MainWindow : Form
{
    private ComboBox modelComboBox;
    private Button selectVideoButton;
    private TextBox videoPathTextBox;
    private Button selectOutputButton;
    private TextBox outputFolderTextBox;
    private ComboBox frameRateComboBox;
    private Button processButton;
    private Button analyseButton;
    private Label logoBox;

    // Set model endpoints
    static readonly string model_endpoint1 = "nano-by-stephan-sturges/1"; //vehicel detection...
    static readonly string model_endpoint2 = "traffic_management-4/5";  //vehicle detection mAP 83.8% Precision 84.0% Recall 75.7%, trained with 4722 images
    static readonly string model_endpoint3 = "vehicle-detection-r4roy/5"; //vehicle detection with mAP 94.1% Precision 89.8% Recall 88.4%, trained with 4157 images
    static readonly string model_endpoint4 = "detectionbike/1"; //bicycle detection with  mAP 96.4% Precision 93.3% Recall 90.7%, trained with 3913 images.
    static readonly string model_endpoint5 = "combined-ouuwm/3"; //animal detection with  mAP 72.1% Precision 74.1% Recall 65.1%, trained with 4553 images
    static readonly string model_endpoint6 = "wild-animals-and-fire-detection/1"; //Wild Animals and Fire Detection with  mAP 88.3% Precision 89.6% Recall 82.1%, trained with 7000 images.

    public MainWindow()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        // Set up the form
        this.Text = "Video/Image Processing System";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Size = new System.Drawing.Size(425, 325);
        this.BackColor = Color.LightBlue;
        this.FormBorderStyle = FormBorderStyle.FixedSingle;

        // Model ComboBox
        modelComboBox = new ComboBox
        {
            BackColor = Color.LightBlue,
            Width = 50,
            Dock = DockStyle.Top,
            DropDownStyle = ComboBoxStyle.DropDown
        };
        modelComboBox.Items.AddRange(new string[] { "traffic 1", "traffic 2", "traffic 3", "bicycle", "animal", "wild animals / fire detection" });
        modelComboBox.SelectedIndex = 0; // Set default selection

        ToolTip tooltip1 = new ToolTip();
        tooltip1.SetToolTip(modelComboBox, "Choose your model..");

        // Video Path TextBox and Button
        videoPathTextBox = new TextBox { Dock = DockStyle.Top, ReadOnly = true, BackColor = Color.AntiqueWhite };
        
        ToolTip tooltip2 = new ToolTip();
        tooltip2.SetToolTip(videoPathTextBox, "Your video output path..");

        selectVideoButton = new Button
        {
            Text = "Select Video/Image",
            BackColor = Color.LightBlue,
            Dock = DockStyle.Top
        };
        selectVideoButton.Click += SelectVideoButton_Click;

        // Output Folder TextBox and Button
        outputFolderTextBox = new TextBox { Dock = DockStyle.Top, ReadOnly = true, BackColor = Color.AntiqueWhite};

        ToolTip tooltip3 = new ToolTip();
        tooltip3.SetToolTip(outputFolderTextBox, "Your output folder path..");

        selectOutputButton = new Button
        {
            Text = "Select Output Folder",
            BackColor = Color.LightBlue,
            Dock = DockStyle.Top
        };
        selectOutputButton.Click += SelectOutputButton_Click;

        // Frame Rate ComboBox
        frameRateComboBox = new ComboBox
        {
            Text = "Select your Frame Rate (in seconds)",
            BackColor = Color.LightBlue,
            Dock = DockStyle.Top,
            DropDownStyle = ComboBoxStyle.DropDown
        };
        frameRateComboBox.Items.AddRange(new string[] { "1", "2", "5", "10" });
        frameRateComboBox.SelectedIndex = 0; // Set default selection

        ToolTip tooltip4 = new ToolTip();
        tooltip4.SetToolTip(frameRateComboBox, "Choose your frame rate..");

        // Process Button
        processButton = new Button
        {
            Text = "Process Video/Image per Frame.",
            BackColor = Color.LightBlue,
            Dock = DockStyle.Top
        };
        processButton.Click += ProcessButton_Click;

        // Process Button
        analyseButton = new Button
        {
            Text = "Analyze Video/Image at once",
            BackColor = Color.LightBlue,
            Dock = DockStyle.Top
        };
       
        analyseButton.Click += AnalyzeButton_Click;

        logoBox = new Label
        {
            Image = Image.FromFile("C:\\Users\\Nutzer\\source\\repos\\TestDatasets\\TestDatasets\\logo1.png"),
            BackColor = Color.LightBlue,
            Dock = DockStyle.Fill,
        };

        // Add controls to the form
        this.Controls.Add(analyseButton);
        this.Controls.Add(processButton);
        this.Controls.Add(frameRateComboBox);
        this.Controls.Add(selectOutputButton);
        this.Controls.Add(outputFolderTextBox);
        this.Controls.Add(selectVideoButton);
        this.Controls.Add(videoPathTextBox);
        this.Controls.Add(modelComboBox);
        this.Controls.Add(logoBox);

        logoBox.BringToFront();
    }

    private void SelectVideoButton_Click(object sender, EventArgs e)
    {
        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            //openFileDialog.Filter = "Video Files|*.mp4;*.avi;*.mov;*.mkv|All Files|*.*";
            openFileDialog.Filter = "Video Files|*.mp4;*.avi;*.mov;*.mkv|Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                videoPathTextBox.Text = openFileDialog.FileName;
            }
        }
    }

    private void SelectOutputButton_Click(object sender, EventArgs e)
    {
        using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                outputFolderTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }
    }

    private bool Check_Imputs()
    {
        string selectedModel = modelComboBox.SelectedItem.ToString();
        string videoPath = videoPathTextBox.Text;
        string outputFolder = outputFolderTextBox.Text;
        string frameRate = frameRateComboBox.SelectedItem.ToString();

        if (string.IsNullOrEmpty(selectedModel) || string.IsNullOrEmpty(videoPath) || string.IsNullOrEmpty(outputFolder) || string.IsNullOrEmpty(frameRate))
        {
            MessageBox.Show("Please select all values", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        // Implement your processing logic here
        DialogResult result = MessageBox.Show($"Processing video with:\nModel: {selectedModel}\nVideo Path: {videoPath}\nOutput Folder: {outputFolder}\nFrame Rate: {frameRate}", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        // Handle the user's response
        if (result == DialogResult.Yes)
        {
            return true;

        }
        else if (result == DialogResult.No)
        {
            return false;
        }

        return false;
    }
    private void ProcessButton_Click(object sender, EventArgs e)
    {
        Run_Processing(true); //analyze per frame
    }

    private void AnalyzeButton_Click(object sender, EventArgs e) 
    {
        Run_Processing(false); //analyse the whole video at once

    }

    private async void Run_Processing(bool perFrame)
    {
        string selectedModel = modelComboBox.SelectedItem.ToString();
        string videoPath = videoPathTextBox.Text;
        string outputFolder = outputFolderTextBox.Text;
        string frameRate = frameRateComboBox.SelectedItem.ToString();
        string model = "";

        // Handle the user's response
        if (Check_Imputs() == true)
        {
            switch(selectedModel)                        
            {
                case "traffic 1":
                    model = model_endpoint1;
                    break;
                case "traffic 2":
                    model = model_endpoint2;
                    break;
                case "traffic 3":
                    model = model_endpoint3;
                    break;
                case "bicycle":
                    model = model_endpoint4;
                    break;
                case "animal":
                    model = model_endpoint5;
                    break;
                case "wild animals / fire detection":
                    model = model_endpoint6;
                    break;
                default:
                    model = model_endpoint1;
                    break;
            }
            
            //beginn to proceed the video...
            Processing proc = new Processing();

            try
            {
                await Task.Run(() => proc.ProcessVideo(videoPath, outputFolder, selectedModel, int.Parse(frameRate), perFrame, model)); //add framerate an the modell
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
