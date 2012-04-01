using System.Xml.Serialization;

namespace WindowsPhoneNotificator
{
    [XmlRoot(ElementName = "Notification", Namespace = "WPNotification")]
    public class TileNotification : Notification
    {
        public Tile Tile { get; set; }
    }
}