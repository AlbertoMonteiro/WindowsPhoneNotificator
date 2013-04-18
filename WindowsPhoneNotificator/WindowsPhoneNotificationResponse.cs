using System.Net;
using System.Runtime.InteropServices;

namespace WindowsPhoneNotificator
{
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("9CE6CED2-B8B2-422F-9023-CA8C53958FB8")]
    [ComVisible(true)]
    public class WindowsPhoneNotificationResponse : IWindowsPhoneNotificationResponse
    {
        public string NotificationStatus { get; set; }
        public string ChannelStatus { get; set; }
        public string DeviceStatus { get; set; }
        public HttpWebResponse Response { get; set; }
    }
}