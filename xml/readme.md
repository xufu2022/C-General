# Free XSD Schema Generator

    <link>www.freeformatter.com/xsdgenerator.htm</link>

xsd product.xsd /c 

# System.Xml.Linq

NameSpace

- Classes for working with XML
- XDocument class : Complete XML document
- XElement class : Single or multiple elements
- XDeclaration
- XAttribute

## Accessing Nodes in an XDocument object

- XDocument.Root property : Access to all elements in document
- Descendants() : Collection of all elements

- Create new XML documents using…
    - XDocument
    - XElement
    - XComment
    - XAttribute

- Use Parse() method to load an XML string

# Load and Save XML Documents

- Load XML Files

    - Use XDocument.Load()
    - Use XElement.Load()

- Display first node using FirstNode Property
- Differences between XDocument and XElement

- Writing to Disk
    - Use XDocument.Save()
    - Create new document using XmlWriter and save to disk
    - Add formatting using XmlWriterSettings
    - Put data into DataSet, save using WriteXml() and WriteXmlSchema()

- XML Generator
https://github.com/PaulDSheriff/PDSC-Tools


## Validating XML

- Load an XDocument
- Create a XmlSchemaSet and add XsdFile path/name
- Create a ValidationEventHandler
- Call doc.Validate()

# Query and Aggregate XML Using XPath

- Learn to use XPath queries
- Read nodes
- Filter nodes
- Create collection of C# objects from XML
- Aggregate nodes
    - Count, sum, minimum, maximum, average

## XPath Queries

Language used to navigate and select nodes
- Similar to finding folders on a hard drive

        // Returns a list of XElement objects
        doc.XPathSelectElements("/Products/Product")

- Filter using XPath

    // Enclose name of element='value' in square brackets
    elem.XPathSelectElement("/Product[ProductID='706']")

## XPath Functions

- last(): Goes to the last node in the collection
- position(): Keeps track of the current position as you query nodes

### Get Specific Nodes

        # Enclose XML function in square brackets
        elem.XPathSelectElement("/Product[last()]")

## XPath Queries Against Attribute-Based XML

- Retrieve attribute-based XML

        Use GetAttrAs<T> extension method
        Select specific node(s) using attributes

## Aggregation

- XPath Functions That Return a Value

        count() Counts total number of nodes
        sum() Sums the value in a set of nodes

- XPath Functions That Return a Value

    - Load XML document
    - Create a XPathNavigator object
    - Call nav.Evaluate() method

- Min and Max
    - No XPath functions
    - Use not(), /preceding-sibling and /following-sibling

- XPath queries are terse, but concise
- Many XPath functions to help query
- XPath functions help aggregate data
    - Sometimes you must get creative to perform calculations such as min/max

# Query XML Documents Using LINQ to XML

## LINQ to XML

- Special LINQ syntax for XML
- Easier to read than XPath
- Simpler than XPath
- More functionality than XPath


        XElement elem = XElement.Load(XmlFileName);
        List<XElement> list;

        // Write Query Here
        list = (from prod in elem.Elements("Product")
            select prod).ToList();

        foreach (XElement product in list)
        {
            Console.WriteLine(
            product.Element("Name").Value);
        }

## Data Aggregation

- Methods for all Count(), Sum(), Min(), Max() and Average()

# Store and Restore .NET Objects as XML

## XML Serialization

- Storing application state for restoring later
- Store a collection of objects
- Caching data locally instead of reading from a database

Use XmlSerializer class

- Serialize to a stream(Ex. memory, file, etc.)
- Deserialize from stream back to a .NET object

## XML Extension Methods

- Create generic **Serialize<T>**
- Create generic **Deserialize<T>**

### Extension methods

- XmlRoot("name", Namespace)
- XmlAttribute("name")
- XmlIgnore
- XmlElement("name")

### Data Contract Serializer

- Must mark properties to serialize with [DataMember]
- Can serialize private properties
- Serializes properties in alphabetical order
- Does not support XML attributes

### BinaryFormatter

- Can serialize private properties
- Little to no control over serialization
- Not portable to other systems other than .NET
- Not secure 
- Marked as obsolete

# Caching Frequently Used Data in XML

Read From SQL Server

- Check if local XML file exists
- Use Entity Framework to get data
- Serialize EF collection
- Write serialized data to XML file

## Detect Changes

- Detect when data changes on SQL Server
- Number of rows in table
- Last updated date

- Must have a "last modified date" field on your table
- Always update the last modified date
- Get maximum last modified date from XML file and database table
- Get total number of rows from XML file and database table

- Only update periodically
- Only cache infrequently changed data