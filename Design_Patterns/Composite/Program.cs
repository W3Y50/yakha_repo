namespace Composite;

class Program
{
    static void Main(string[] args)
    {
        {
            // Create a new directory for the course
            Directory designpatterns = new Directory("training");

            // Create a new file for the course content and add it to the design patterns directory
            File content = new File("content", "Timo");
            designpatterns.Add(content);

            // Create a new directory to store video files
            Directory videos = new Directory("videos");
            Directory pics = new Directory("pics");

            // Add the videos directory to the video course directory
            designpatterns.Add(videos);
            designpatterns.Add(pics);

            // Create video files and add them to the videos directory
            File video1 = new File("video1", "Timo");
            File video2 = new File("video2", "Timo");
            videos.Add(video1);
            videos.Add(video2);

            File pic1 = new File("pic1", "Timo");
            File pic2 = new File("pic2", "Timo");
            videos.Add(pic1);
            videos.Add(pic2);

            // Print the contents of the video course directory
            designpatterns.Print();


            // Wait for a key press before closing the console
            Console.ReadKey();
        }
    }
}

