using System.Runtime.InteropServices;
using System.Xml.Serialization;

namespace WindowsPhoneNotificator
{
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("A83EBFB2-474E-4AB1-B22B-474937513236")]
    [ComVisible(true)]
    [XmlRoot(ElementName = "Notification", Namespace = "WPNotification")]
    public class Toast : IToast
    {
        public Toast()
        {
            
        }

        [XmlElement(Namespace = "WPNotification")]
        public string Text1 { get; set; }
        [XmlElement(Namespace = "WPNotification")]
        public string Text2 { get; set; }
        [XmlElement(ElementName = "Param",Namespace = "WPNotification")]
        public string PathToOpen { get; set; }
    }
}