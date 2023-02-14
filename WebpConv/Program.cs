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
            // Input directory.
            string Input = Directory.GetCurrentDirectory();
            // Output directory.
            string Output = Path.Combine(Directory.GetCurrentDirectory(), "output");
            // Create the output directory if it's not found.
            if (!Directory.Exists(Output))
            {
                Directory.CreateDirectory(Output);
            }
            // Get all Webp images in the input dir.
            string[] webpFiles = Directory.GetFiles(Input, "*.webp");

            foreach (string webpFile in webpFiles)
            {
                // Load the Webp image.
                using (Image image = Image.Load(webpFile, new WebpDecoder()))
                {
                    // Get the output file path
                    string OutputFile = Path.Combine(Output, Path.GetFileNameWithoutExtension(webpFile) + ".png");

                    // Save the image as a PNG
                    image.Save(OutputFile, new PngEncoder());
                }
            }
        }
    }
}
