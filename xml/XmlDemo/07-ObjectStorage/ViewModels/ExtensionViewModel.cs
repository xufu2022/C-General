using _07_ObjectStorage.EntityClasses;
using _07_ObjectStorage.HelperClasses;

namespace _07_ObjectStorage.ViewModels {
  public class ExtensionViewModel {
    public ExtensionViewModel() {
            // TODO: MODIFY YOUR FILE LOCATION
            XmlFileName = new XmlFilePath.FilePath().GetXmlPath("Products.xml");
        }

    private readonly string XmlFileName;

    #region SerializeProduct Method
    /// <summary>
    /// Serialize object using extension method
    /// </summary>
    public string SerializeProduct() {
      string value = string.Empty;

      // Create a New Product Object
      Product prod = new()
      {
        ProductID = 999,
        Name = "A New Product",
        ProductNumber = "NEW-999",
        Color = "White",
        StandardCost = 10,
        ListPrice = 20,
        Size = "Medium",
        ModifiedDate = Convert.ToDateTime("01-01-2022")
      };

            // TODO: Serialize the object
            value = prod.Serialize<Product>();

            // Write to File
            File.WriteAllText(XmlFileName, value);

      // Display XML
      Console.WriteLine(value);

      return value;
    }
    #endregion

    #region DeserializeProduct Method
    /// <summary>
    /// Deserialize XML using extension method
    /// </summary>
    public Product DeserializeProduct() {
      Product prod = new();
      string value = string.Empty;

            // TODO: Read from File
            value = File.ReadAllText(XmlFileName);

            // TODO: Deserialize the object
            prod = prod.Deserialize<Product>(value);

            // Display Product
            Console.WriteLine(prod);

      return prod;
    }
    #endregion
  }
}
