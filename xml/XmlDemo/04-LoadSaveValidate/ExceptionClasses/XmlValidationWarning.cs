namespace _04_LoadSaveValidate.ExceptionClasses;

public class XmlValidationWarning : XmlSchemaValidationException
{
    public XmlValidationWarning(string message, ValidationEventArgs e) : base(message)
    {
        EventArg = e;
    }

    public ValidationEventArgs EventArg { get; set; }
}