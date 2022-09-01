namespace XmlFilePath
{
    public class FilePath
    {
        public string GetXmlPath(string filePath)
        {
            //string path=Directory.GetCurrentDirectory();
            return $"../../../../xml/{filePath}";
        }

    }
}