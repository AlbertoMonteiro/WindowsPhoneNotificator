using System;
using System.Xml.Serialization;

namespace WindowsPhoneNotificator
{
    [XmlRoot(ElementName = "Tile", Namespace = "WPNotification")]
    public class Tile
    {
        private int count;

        [XmlElement(Namespace = "WPNotification")]
        public string BackgroundImage { get; set; }

        [XmlElement(Namespace = "WPNotification")]
        public int Count
        {
            get { return count; }
            set
            {
                if (value > 99)
                    throw new ArgumentException("Maximum value for count is 99");
                if (value < 1)
                    throw new ArgumentException("Minimum value for count is 99");
                count = value;
            }
        }

        [XmlElement(Namespace = "WPNotification")]
        public string Title { get; set; }

        [XmlElement(Namespace = "WPNotification")]
        public string BackBackgroundImage { get; set; }

        [XmlElement(Namespace = "WPNotification")]
        public string BackTitle { get; set; }

        [XmlElement(Namespace = "WPNotification")]
        public string BackContent { get; set; }
    }
}