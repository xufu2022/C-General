using System.Xml.Linq;
using _04_LoadSaveValidate.HelperClasses;

namespace _04_LoadSaveValidate.ViewModels;

/// <summary>
/// Demos of loading an XML document using XDocument and XElement classes
/// </summary>
public class LoadingViewModel {
    public LoadingViewModel() {
        XmlFileName = FileNameHelper.ProductsFile;
    }

    private readonly string XmlFileName;

    #region LoadUsingXDocument Method
    /// <summary>
    /// Use the Load() method of the XDocument class
    /// </summary>
    public XDocument LoadUsingXDocument() {
        // TODO: Write your code here
        XDocument doc = XDocument.Load(new XmlFilePath.FilePath().GetXmlPath("Products.xml"));

        // Display XDocument
        Console.WriteLine(doc);

        return doc;
    }
    #endregion

    #region LoadUsingXElement Method
    /// <summary>
    /// Use the Load() method of the XElement class
    /// </summary>
    public XElement LoadUsingXElement() {
        // TODO: Write your code here
        XElement elem = XElement.Load(new XmlFilePath.FilePath().GetXmlPath("Products.xml"));

        // Display XElement
        Console.WriteLine(elem);

        return elem;
    }
    #endregion

    #region GetFirstNodeUsingXDocument Method
    /// <summary>
    /// Use the FirstNode property after loading an XML file using XDocument.Load()
    /// </summary>
    public string GetFirstNodeUsingXDocument() {
        XDocument doc = XDocument.Load(XmlFileName);
        string value = string.Empty;

        // TODO: Write your code here
        if(doc.FirstNode !=null)
         value = doc.FirstNode.ToString();
        // Display Value
        Console.WriteLine(value);

        return value;
    }
    #endregion

    #region GetFirstNodeUsingXElement Method
    /// <summary>
    /// Use the FirstNode property after loading an XML file using XElement.Load()
    /// </summary>
    public string GetFirstNodeUsingXElement() {
        XElement elem = XElement.Load(XmlFileName);
        string value = string.Empty;

        var xnode = elem.FirstNode;
        if (xnode != null)
            value = xnode.ToString();

        // Display Value
        Console.WriteLine(value);

        return value;
    }
    #endregion
}