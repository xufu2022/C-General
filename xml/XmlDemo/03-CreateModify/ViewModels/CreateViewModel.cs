using System.Xml;

namespace _03_CreateModify.ViewModels;

/// <summary>
/// Demos showing various methods for creating new XML documents and nodes
/// </summary>
public class CreateViewModel {
    #region CreateEmptyDocument Method
    /// <summary>
    /// Write code to build a new XML document that is empty
    /// </summary>
    public XDocument CreateEmptyDocument() {
        // TODO: Write your code here
        XDocument doc = new XDocument(
            new XDeclaration("1.0","utf-8","yes"),
            new XComment("Product Information"),
            new XElement("Products"));


        // Display the Document
        Console.WriteLine(doc);

        return doc;
    }
    #endregion

    #region CreateProductDocument Method
    /// <summary>
    /// Write code to build a new XML document with a new product element
    /// </summary>
    public XDocument CreateProductDocument() {
        // TODO: Write your code here
        XDocument doc = new(
            new XDeclaration("1.0", "utf-8", "yes"),
            new XComment("Product Information"),
            new XElement("Products",
                new XElement("Product",
                    new XElement("ProductID", "1"),
                    new XElement("Name", "Bicycle Helmet"),
                    new XElement("ProductNumber", "HELM-01"),
                    new XElement("Color", "White"),
                    new XElement("StandardCost", "24.49"),
                    new XElement("ListPrice", "89.99"),
                    new XElement("Size", "Medium"))
            )
        ); 

        // Display the Document
        Console.WriteLine(doc);

        return doc;
    }
    #endregion

    #region CreateProductDocumentWithAttributes Method
    /// <summary>
    /// Write code to build a new XML document with a new product element and attributes
    /// </summary>
    public XDocument CreateProductDocumentWithAttributes() {
        // TODO: Write your code here
        XDocument doc = new(
            new XDeclaration("1.0", "utf-8", "yes"),
            new XComment("Product Information"),
            new XElement("Products",
                new XElement("Product",
                    new XAttribute("ProductID", "1"),
                    new XElement("Name", "Bicycle Helmet"),
                    new XElement("ProductNumber", "HELM-01"),
                    new XElement("Color", "White"),
                    new XElement("StandardCost", "24.49"),
                    new XElement("ListPrice", "89.99"),
                    new XElement("Size", "Medium"))
            )
        );

        // Display the Document
        Console.WriteLine(doc);

        return doc;
    }
    #endregion

    #region CreateNestedXmlDocument Method
    /// <summary>
    /// Write code to create a nested XML document
    /// </summary>
    public XDocument CreateNestedXmlDocument() {
        // TODO: Write your code here
        XDocument doc = new(
            new XDeclaration("1.0", "utf-8", "yes"),
            new XComment("Product Information"),
            new XElement("Products",
                new XElement("Product",
                    new XAttribute("ProductID", "1"),
                    new XElement("Name", "Bicycle Helmet"),
                    new XElement("Sales",
                        new XElement("SalesDetail",
                            new XAttribute("SalesOrderID", "1"),
                            new XElement("OrderDate", Convert.ToDateTime("10/1/2021")))
                    )
                )
            )
        );

        // Display the Document
        Console.WriteLine(doc);

        return doc;
    }
    #endregion

    #region ParseStringIntoXDocument Method
    /// <summary>
    /// Create an XML string and parse that into an XML document using XDocument
    /// </summary>
    public XDocument ParseStringIntoXDocument() {
        string xml = @"<Products>
                      <Product>
                        <ProductID>706</ProductID>
                        <Name>HL Road Frame - Red, 58</Name>
                        <ProductNumber>FR-R92R-58</ProductNumber>
                        <Color>Red</Color>
                        <StandardCost>1059.3100</StandardCost>
                        <ListPrice>1500.0000</ListPrice>
                        <Size>58</Size>
                      </Product>
                      <Product>
                        <ProductID>707</ProductID>
                        <Name>Sport-100 Helmet, Red</Name>   
                        <Color>Red</Color>
                        <StandardCost>13.0800</StandardCost>
                        <ListPrice>34.9900</ListPrice>
                        <Size />
                      </Product>
                    </Products>";

        // Create XML Document using Parse()
        XDocument doc = XDocument.Parse(xml);

        // Display XML Document
        Console.WriteLine(doc);

        return doc;
    }
    #endregion

    #region ParseStringIntoXElement Method
    /// <summary>
    /// Create an XML string and parse that into an XML document using XElement
    /// </summary>
    public XElement ParseStringIntoXElement() {
        string xml = XmlStringHelper.CreateProductXmlString();

        // Create XML Document using Parse()
        XElement elem = XElement.Parse(xml);

        // Display XML Document
        Console.WriteLine(elem);

        return elem;
    }
    #endregion
}