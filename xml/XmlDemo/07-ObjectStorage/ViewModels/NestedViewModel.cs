using _07_ObjectStorage.EntityClasses;
using _07_ObjectStorage.HelperClasses;
using _07_ObjectStorage.RepositoryClasses;

namespace _07_ObjectStorage.ViewModels {
  public class NestedViewModel {
    public NestedViewModel() {
            // TODO: MODIFY YOUR FILE LOCATION
            XmlFileName = new XmlFilePath.FilePath().GetXmlPath("Products.xml");
        }

    private readonly string XmlFileName;

    #region SerializeProductSales Method
    /// <summary>
    /// Serialize a nested object to XML
    /// </summary>
    public string SerializeProductSales() {
      ProductSales prod = ProductSalesRepository.Get();
      string value = string.Empty;

            // TODO: Serialize the object
            value = prod.Serialize<ProductSales>();

            // TODO: Write to File
            File.WriteAllText(XmlFileName, value);

            // Display Product
            Console.WriteLine(value);

      return value;
    }
    #endregion

    #region DeserializeProductSales Method
    /// <summary>
    /// Deserialize XML with nested elements back into a C# class
    /// </summary>
    public ProductSales DeserializeProductSales() {
      ProductSales prod = new();
      string value;

      // Read from File
      value = File.ReadAllText(XmlFileName);

            // TODO: Deserialize the object
            prod = prod.Deserialize<ProductSales>(value);

            // Display Product
            Console.WriteLine(prod);

      return prod;
    }
    #endregion
  }
}
