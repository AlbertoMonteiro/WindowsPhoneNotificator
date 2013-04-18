namespace WindowsPhoneNotificator
{
    public interface IWindowsPhoneNotification
    {
        string UrlToNotify { get; set; }
        Notification Notification { get; set; }
        WindowsPhoneNotificationResponse SendNotification();
    }
}