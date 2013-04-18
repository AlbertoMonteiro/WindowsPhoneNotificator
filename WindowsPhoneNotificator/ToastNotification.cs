using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace WindowsPhoneNotificator
{
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("A4311EA5-F3F6-4FED-B0A7-168DFC44F770")]
    [ComVisible(true)]
    [XmlRoot(ElementName = "Notification", Namespace = "WPNotification")]
    public class ToastNotification : Notification, IToastNotification
    {
        public ToastNotification()
        {
            Toast = new Toast();
        }
        public Toast Toast { get; set; }
    }
}