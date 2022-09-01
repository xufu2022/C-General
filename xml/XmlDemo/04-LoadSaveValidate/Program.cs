// See https://aka.ms/new-console-template for more information
// Create instance of view model
using _04_LoadSaveValidate.ViewModels;

LoadingViewModel vm = new();
SaveViewModel sv = new();
ValidateViewModel vv = new();
// Call Sample Method
//LoadingViewModel Samples
//--------------------------------------------------
//vm.LoadUsingXDocument(); //- Use the Load() method of the XDocument class
//vm.LoadUsingXElement(); // Use the Load() method of the XElement class
//vm.GetFirstNodeUsingXDocument();// - Use the FirstNode property after loading an XML file using XDocument.Load()
//vm.GetFirstNodeUsingXElement();// - Use the FirstNode property after loading an XML file using XElement.Load()
//
//
//SaveViewModel Samples
//--------------------------------------------------
//sv.SaveUsingXDocument(); // - Write code to save an XML document to disk using XDocument.Save()
//sv.SaveUsingXmlWriter(); // - Create XML document and save to disk using the XmlWriter class
//sv.XmlWriterFormattingSave(); // - Create XML document and save to disk using the XmlWriter class. Use the XmlWriterSettings object to specify formatting for the XML
//sv.DataSetSave(); // - Put data into a DataSet object from a SQL database, then write the XML and XSD to disk using the WriteXml() and WriteXmlSchema() methods
//
//
//ValidateViewModel Samples
//--------------------------------------------------
vv.ValidateXml(); // - Write code to validate XML using an XSD file
//vv.ValidateXmlWithError(); // - Write code to create an invalid node, then validate the XML using an XSD file


// Stop console to view results
Console.ReadKey();
