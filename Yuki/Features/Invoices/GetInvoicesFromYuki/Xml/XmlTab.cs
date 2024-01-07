namespace Yuki.Features.Invoices.GetInvoicesFromYuki.Xml;

[XmlRoot(ElementName = "Tab")]
public class XmlTab
{
    [XmlAttribute(AttributeName = "ID")] public int ID { get; set; }

    [XmlText] public string Text { get; set; }
}