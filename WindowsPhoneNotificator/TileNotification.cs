using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace WindowsPhoneNotificator
{
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("A08BB60C-9F2B-4A60-99C6-6E3E47085794")]
    [ComVisible(true)]
    [XmlRoot(ElementName = "Notification", Namespace = "WPNotification")]
    public class TileNotification : Notification, ITileNotification
    {
        public TileNotification()
        {
            Tile = new Tile();
        }

        public Tile Tile { get; set; }
    }
}