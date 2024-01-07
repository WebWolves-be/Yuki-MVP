namespace Yuki.Features.Invoices.GetInvoicesFromYuki.Xml;

[XmlRoot(ElementName = "Documents")]
public class XmlDocuments
{
    [XmlElement(ElementName = "Document")] public List<XmlDocument> Document { get; set; }

    // [XmlAttribute(AttributeName="xmlns")] 
    // public object Xmlns { get; set; } 

    [XmlText] public string Text { get; set; }
}