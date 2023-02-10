using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using SixLabors.ImageSharp.Formats.Webp;
using Image = SixLabors.ImageSharp.Image;

namespace WebpToPngConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input directory path (the directory where the program is run)
            string inputDirectory = Directory.GetCurrentDirectory();

            // Output directory path (a subfolder in the current directory)
            string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "output");

            // Create the output directory if it doesn't exist
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all WebP images in the input directory
            string[] webpFiles = Directory.GetFiles(inputDirectory, "*.webp");

            foreach (string webpFile in webpFiles)
            {
                // Load the WebP image
                using (Image image = Image.Load(webpFile, new WebpDecoder()))
                {
                    // Get the output file path
                    string outputFile = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(webpFile) + ".png");

                    // Save the image as a PNG
                    image.Save(outputFile, new PngEncoder());
                }
            }
        }
    }
}
