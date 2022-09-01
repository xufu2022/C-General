using _05_XPath.ViewModels;
using _05_XPath;

ElementViewModel vm = new();
AttributeViewModel av = new();
AggregateViewModel agv = new();
//vm.GetAllXDocument(); // - Write an XPath query to get all product elements using the XDocument class
//vm.GetAllXElement(); // - Write an XPath query to get all product elements using the XElement class
//vm.GetAllWithErrors(); // - Write an XPath query to load all products and show what happens when there is a null vm.element
//vm.GetASingleNode(); // - Write an XPath query to get a single product from the XML document
//vm.GetACollectionOfNodes(); // - Write an XPath query to get a set of products where an element's value matches a vm.criteria
//vm.GetLastNode(); // - Write an XPath query to get the last node in the document
//vm.GetFirstThreeNodes(); // - Write an XPath query to get the first three nodes in the document
// vm.AddToClass(); // - Write an XPath query to get some nodes and build a collection of Product objects
//
//
//AttributeViewModel Samples
//--------------------------------------------------
//av.GetAll(); // - Write an XPath query to get all Products and display the attribute values
//av.GetASingleNode(); // - Write an XPath query to get a single product and display the attribute values
//av.GetACollectionOfNodes(); // - Write an XPath query to search for a specific attribute value
//
//
//AggregateViewModel Samples
//--------------------------------------------------
agv.Count(); // - Write an XPath query to count all sales order details
agv.Sum(); // - Write an XPath query to provide a sum of all values in the LineTotal element
agv.Average(); // - Write an XPath query to provide the average value of all LineTotal elements
//agv.Minimum(); // - Write an XPath query to provide the minimum value of all LineTotal elements
//agv.Maximum(); // - Write an XPath query to provide the maximum value of all LineTotal elements

// Stop console to view results
Console.ReadKey();