namespace _03_CreateModify.ViewModels;

/// <summary>
/// Demos of how to add, edit and delete nodes from an XML document
/// </summary>
public class AddEditDeleteViewModel
{
    #region AddNewNode Method
    /// <summary>
    /// Write code to create a new XElement object and add it to an existing XML document
    /// </summary>
    public XDocument AddNewNode()
    {
        // Get a Product XML string
        string xml = XmlStringHelper.CreateProductXmlString();
        // Create XML Document using Parse()
        XDocument doc = XDocument.Parse(xml);

        // TODO: Create a new XElement object to add
        XElement elem =
            new XElement("Product",
                new XElement("ProductID", "745"),
                new XElement("Name", "HL Mountain Frame"),
                new XElement("ProductNumber", "FR-M94B-48"),
                new XElement("Color", "Black"),
                new XElement("StandardCost", "699.09"),
                new XElement("ListPrice", "1349.6000"),
                new XElement("Size", "48")
            );

        // TODO: Add the new XElement object to the root
        doc.Root.Add(elem);

        // Display Document
        Console.WriteLine(doc);

        return doc;
    }
    #endregion

    #region UpdateNode Method
    /// <summary>
    /// Write code to retrieve a single node from a document, edit some elements, then display the changed elements
    /// </summary>
    public XElement UpdateNode()
    {
        // Get a Product XML string
        string xml = XmlStringHelper.CreateProductXmlString();
        // Create XML Document using Parse()
        XDocument doc = XDocument.Parse(xml);

        // TODO: Get the First product element
        XElement elem = doc.Root!.Descendants().FirstOrDefault()!;
        if (elem != null)
        {
            // Modify some of the node values
            elem.Element("Name").Value = "CHANGED PRODUCT";
            elem.Element("ListPrice").Value = "999.99";
        }
        // TODO: Display the Changed Element
        Console.WriteLine(doc);

        return elem;
    }
    #endregion

    #region DeleteNode Method
    /// <summary>
    /// Write code to locate a specific node, then delete that node from the XML document
    /// </summary>
    public XElement DeleteNode()
    {
        // Get a Product XML string
        string xml = XmlStringHelper.CreateProductXmlString();
        // Create XML Document using Parse()
        XDocument doc = XDocument.Parse(xml);

        // TODO: Get the First product element
        XElement elem = doc.Root.Descendants().FirstOrDefault();
        if (elem != null)
        {
            // Delete the node
            elem.Remove();
        }
        // Display Document
        Console.WriteLine(doc);

        return elem;
    }
    #endregion
}