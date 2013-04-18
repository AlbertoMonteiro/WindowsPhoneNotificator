using System.Net;

namespace WindowsPhoneNotificator
{
    public interface IWindowsPhoneNotificationResponse
    {
        string NotificationStatus { get; set; }
        string ChannelStatus { get; set; }
        string DeviceStatus { get; set; }
        HttpWebResponse Response { get; set; }
    }
}