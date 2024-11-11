namespace Yuki.Features.Invoices.Yuki.Xml;

[XmlRoot(ElementName = "Document")]
public class XmlDocument
{
    [XmlElement(ElementName = "Subject")] public string Subject { get; set; }

    [XmlElement(ElementName = "DocumentDate")]
    public DateTime DocumentDate { get; set; }

    [XmlElement(ElementName = "Amount")] public double Amount { get; set; }

    [XmlElement(ElementName = "Folder")] public XmlFolder Folder { get; set; }

    [XmlElement(ElementName = "Tab")] public XmlTab Tab { get; set; }

    [XmlElement(ElementName = "Type")] public int Type { get; set; }

    [XmlElement(ElementName = "TypeDescription")]
    public string TypeDescription { get; set; }

    [XmlElement(ElementName = "FileName")] public string FileName { get; set; }

    [XmlElement(ElementName = "ContentType")]
    public string ContentType { get; set; }

    [XmlElement(ElementName = "FileSize")] public int FileSize { get; set; }

    [XmlElement(ElementName = "ContactName")]
    public string ContactName { get; set; }

    [XmlElement(ElementName = "Created")] public DateTime Created { get; set; }

    [XmlElement(ElementName = "Creator")] public string Creator { get; set; }

    [XmlElement(ElementName = "Modified")] public DateTime Modified { get; set; }

    [XmlElement(ElementName = "Modifier")] public string Modifier { get; set; }

    [XmlAttribute(AttributeName = "ID")] public string ID { get; set; }

    [XmlText] public string Text { get; set; }

    [XmlElement(ElementName = "VATAmount")]
    public double VatAmount { get; set; }
}