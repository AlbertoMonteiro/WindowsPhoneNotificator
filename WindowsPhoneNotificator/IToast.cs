using System.Xml.Serialization;

namespace WindowsPhoneNotificator
{
    public interface IToast
    {
        [XmlElement(Namespace = "WPNotification")]
        string Text1 { get; set; }

        [XmlElement(Namespace = "WPNotification")]
        string Text2 { get; set; }

        [XmlElement(ElementName = "Param", Namespace = "WPNotification")]
        string PathToOpen { get; set; }
    }
}