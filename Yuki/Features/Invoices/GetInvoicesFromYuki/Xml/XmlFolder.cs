namespace Yuki.Features.Invoices.GetInvoicesFromYuki.Xml;

[XmlRoot(ElementName = "Folder")]
public class XmlFolder
{
    [XmlAttribute(AttributeName = "ID")] public int ID { get; set; }

    [XmlText] public string Text { get; set; }
}