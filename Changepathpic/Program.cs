using System;
using System.IO;
using HtmlAgilityPack;

class Program
{
    static void Main()
    {
        Console.Write("Provide the full path of the original HTML file: ");
        string inputPath = Console.ReadLine();

        Console.Write("How many images should I change? ");
        int count = int.Parse(Console.ReadLine());

        Console.Write("Give the old path you want to replace. (e.g. https://assets.nb.org/nb/2024/images/6o-sunedrio-gia-to-forologiko-dikaio/): ");
        string oldPath = Console.ReadLine();

        Console.Write("Give the new path you want.(e.g. https://assets.nb.org/nb/2025/images/3o-women-in-law/): ");
        string newBasePath = Console.ReadLine();

        // Ensure both paths end with slash
        if (!oldPath.EndsWith("/")) oldPath += "/";
        if (!newBasePath.EndsWith("/")) newBasePath += "/";

        var doc = new HtmlDocument();
        doc.Load(inputPath);

        var pictures = doc.DocumentNode.SelectNodes("//picture");

        if (pictures == null || pictures.Count == 0)
        {
            Console.WriteLine("Dont Find <picture> tags.");
            return;
        }

        int replacedCount = 0;

        for (int i = 0; i < pictures.Count && replacedCount < count; i++)
        {
            string filename = $"{replacedCount + 1:00}.jpg";
            string newSrc = newBasePath + filename;

            var source = pictures[i].SelectSingleNode(".//source");
            var img = pictures[i].SelectSingleNode(".//img");

            bool updated = false;

            if (source != null && source.GetAttributeValue("srcset", "").StartsWith(oldPath))
            {
                source.SetAttributeValue("srcset", newSrc);
                updated = true;
            }

            if (img != null && img.GetAttributeValue("src", "").StartsWith(oldPath))
            {
                img.SetAttributeValue("src", newSrc);
                updated = true;
            }

            if (updated)
                replacedCount++;
        }

        string outputPath = Path.Combine(Path.GetDirectoryName(inputPath), "updated.html");
        doc.Save(outputPath);

        Console.WriteLine($"Replaced {replacedCount} images.");
        Console.WriteLine($"The new file saved: {outputPath}");
    }
}

