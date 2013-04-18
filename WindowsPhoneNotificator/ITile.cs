using System.Xml.Serialization;

namespace WindowsPhoneNotificator
{
    public interface ITile
    {
        [XmlElement(Namespace = "WPNotification")]
        string BackgroundImage { get; set; }

        [XmlElement(Namespace = "WPNotification")]
        int Count { get; set; }

        [XmlElement(Namespace = "WPNotification")]
        string Title { get; set; }

        [XmlElement(Namespace = "WPNotification")]
        string BackBackgroundImage { get; set; }

        [XmlElement(Namespace = "WPNotification")]
        string BackTitle { get; set; }

        [XmlElement(Namespace = "WPNotification")]
        string BackContent { get; set; }
    }
}