using System.Xml.Serialization;

namespace WindowsPhoneNotificator
{
    [XmlRoot(ElementName = "Notification", Namespace = "WPNotification")]
    public class ToastNotification : Notification
    {
        public Toast Toast { get; set; }
    }
}