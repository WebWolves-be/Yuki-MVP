namespace Yuki.Features.Invoices.Yuki.Xml;

[XmlRoot(ElementName = "Tab")]
public class XmlTab
{
    [XmlAttribute(AttributeName = "ID")] public int ID { get; set; }

    [XmlText] public string Text { get; set; }
}