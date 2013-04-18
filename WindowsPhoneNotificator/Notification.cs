using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace WindowsPhoneNotificator
{
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("D8BB9310-1EAF-4FF8-B421-9E3EE7301927")]
    [ComVisible(true)]
    [XmlRoot(ElementName = "Notification", Namespace = "WPNotification")]
    public abstract class Notification : INotification
    {
         
    }
}