// Create instance of view model

using _06_LINQ_XML.ViewModels;

ElementViewModel vm = new();
AttributeViewModel avm = new();
AggregateViewModel agv = new();
// Call Sample Method
// ElementViewModel Samples
// --------------------------------------------------
//vm.GetAllXDocument(); // - When loading an XML document using XDocument, you use Descendants() to get all product nodes
//vm.GetAllXElement(); // - When loading an XML document using XElement, you use Elements() to get all product nodes
// 
//vm.WhereClause(); // - Write a LINQ query to get a set of orders using a where clause from the XML file
// 
// vm.OrderBy(); // - Write a LINQ query to get all products ordering by Color, ListPrice
// vm.
// vm.AddToClass(); // - Write a LINQ query to get all elements and build a collection of Product objects
// vm.
// vm.Join(); // - Write code load two XML files to join products and orders and create a new XML document with a different shape.
// vm.
// vm.GetSalesWithDetails(); // - Write a LINQ query to only get those sales orders that have details
// vm.GetSalesLineTotalGreaterThan(); // - Write a LINQ query to only get those orders that have a LineTotal > $800
// vm.
// vm.
// vm.AttributeViewModel Samples
// --------------------------------------------------
//avm.GetAll(); // - Write a LINQ query to get all Products and display the attribute values
//// GetAllUsingExtensionMethod(); // - Write a LINQ query to get all products and display the attribute values using //the extension method GetAttrAs()
//avm.GetASingleNode(); // - Write a LINQ query to get a single product and display the attribute values
//avm.OrderBy(); // - Write a LINQ query to order the products by Color, then by ListPrice
// 
// 
// AggregateViewModel Samples
// --------------------------------------------------
 agv.Count(); // - Write a LINQ query to count all elements in an XML document
 agv.Sum(); // - Write a LINQ query to sum all LineTotal element values in an XML document
 agv.Average(); // - Write a LINQ query to find the average value of all LineTotal element values in an XML document
 agv.Minimum(); // - Write a LINQ query to find the minimum value of all LineTotal element values in an XML document

// Stop console to view results
Console.ReadKey();
