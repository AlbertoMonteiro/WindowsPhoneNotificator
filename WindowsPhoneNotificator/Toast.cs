using System.Xml.Serialization;

namespace WindowsPhoneNotificator
{
    [XmlRoot(ElementName = "Notification", Namespace = "WPNotification")]
    public class Toast
    {
        [XmlElement(Namespace = "WPNotification")]
        public string Text1 { get; set; }
        [XmlElement(Namespace = "WPNotification")]
        public string Text2 { get; set; }
        [XmlElement(ElementName = "Param",Namespace = "WPNotification")]
        public string PathToOpen { get; set; }
    }
}