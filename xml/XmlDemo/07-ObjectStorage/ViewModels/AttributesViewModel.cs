using _07_ObjectStorage.EntityClasses;
using _07_ObjectStorage.HelperClasses;

namespace _07_ObjectStorage.ViewModels {
  public class AttributesViewModel {
    public AttributesViewModel() {
      // TODO: MODIFY YOUR FILE LOCATION
      XmlFileName = new XmlFilePath.FilePath().GetXmlPath("ProductWithAttributes.xml");
    }

    private readonly string XmlFileName;

    #region SerializeProduct Method
    /// <summary>
    /// Add [Xml*] attributes to ProductWithAttributes class to help control serialization
    /// Also use Serialize extension method to perform the serialization
    /// </summary>
    public string SerializeProduct() {
      string value = string.Empty;

      // Create a New Product Object
      ProductWithAttributes prod = new()
      {
        ProductID = 999,
        Name = "A New Product",
        ProductNumber = "NEW-999",
        Color = null,  // This element will not be in the XML
        StandardCost = 10,
        ListPrice = 20,
        Size = null    // This element will be in the XML
      };

      value = prod.Serialize<ProductWithAttributes>();


            // Write to File
            File.WriteAllText(XmlFileName, value);

      // Display XML
      Console.WriteLine(value);

      return value;
    }
    #endregion

    #region DeserializeProduct Method
    /// <summary>
    /// Deserialize Element/Attribute-based XML into ProductWithAttributes object
    /// Also use Deserialize extension method to perform the Deserialization
    /// </summary>
    public ProductWithAttributes DeserializeProduct() {
      ProductWithAttributes prod = new();
      string value = string.Empty;

            // TODO: Read from File
            value = File.ReadAllText(XmlFileName);

            // TODO: Deserialize the product
            prod = prod.Deserialize<ProductWithAttributes>(value);

            // Display Product
            Console.WriteLine(prod);

      return prod;
    }
    #endregion
  }
}
