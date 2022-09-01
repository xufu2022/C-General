namespace _04_LoadSaveValidate.ExceptionClasses;

public class XmlValidationException : XmlSchemaValidationException
{
    public XmlValidationException(string message, ValidationEventArgs e) : base(message)
    {
        EventArg = e;
    }

    public ValidationEventArgs EventArg { get; set; }
}