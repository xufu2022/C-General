// Create instance of view model
using _07_ObjectStorage.ViewModels;

SerializeViewModel vm = new();
FormatViewModel fv = new();
ExtensionViewModel evm=new ();
AttributesViewModel avm =new ();
NestedViewModel nvm =new ();
DataContractViewModel dvm =new ();
BinaryViewModel bvm =new ();
// Call Sample Method
// vm.SerializeViewModel Samples
// vm.--------------------------------------------------
//vm.SerializeProduct(); // - Use XmlSerializer and StringWriter
//vm.DeserializeProduct(); // - Use XmlSerializer and MemoryStream to deserialize an XML document into a Product object

// vm.FormatViewModel Samples
// vm.--------------------------------------------------
//fv.SerializeProduct(); // - Serialize a Product object using XmlSerializer, MemoryStream, XmlWriter and XmlWriterSettings to format the XML
//fv.DeserializeProduct(); // - Deserialize formatted XML into a Product object using XmlSerializer and MemoryStream

// vm.ExtensionViewModel Samples
// vm.--------------------------------------------------
//evm.SerializeProduct(); // - Serialize a Product object using an extension method
//evm.DeserializeProduct(); // - Deserialize XML into a Product object using an extension method

// vm.AttributesViewModel Samples
// vm.--------------------------------------------------
avm.SerializeProduct(); // - Add [Xml*] attributes to ProductWithAttributes class to help control serialization. Also use Serialize() extension method.
avm.DeserializeProduct(); // - Deserialize Element/Attribute-based XML into ProductWithAttributes object. Also use Deserialize() extension method.

// vm.NestedViewModel Samples
// vm.--------------------------------------------------
nvm.SerializeProductSales(); // - Serialize a nested object to XML
nvm.DeserializeProductSales(); // - Deserialize XML with nested elements back into a C# class

// vm.DataContractViewModel
// vm.--------------------------------------------------
dvm.SerializeProduct(); // - Add [Data*] attributes to ProductWithDataContract class to control serialization using the DataContractSerializer class
dvm.DeserializeProduct(); // - Deserialize XML into a ProductWithDataContract object using the [Data*] attributes

// vm.BinaryViewModel
// vm.--------------------------------------------------
// vm.Using the BinaryFormatter
// vm.Add [Serializable] to classes
// vm.Will store and restore private variables
// vm.This formatter is marked as obsolete and will be removed sometime in the future
// vm.It is considered an insecure feature
 bvm.SerializeProduct(); // - Use BinaryFormatter class to serialize and object. NOTE: This class is marked as Obsolete, so try not to use it
 bvm.DeserializeProduct(); // - Use BinaryFormatter class to deserialize text from an XML file and create a new object. NOTE: This class is marked as Obsolete, so try not to use it

// Stop console to view results
Console.ReadKey();
