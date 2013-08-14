using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Serialization;

namespace WindowsPhoneNotificator
{
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("D9C3E9C9-C4A8-422A-8F78-C0A9C45D1670")]
    [ComVisible(true)]
    public class WindowsPhoneNotification : IWindowsPhoneNotification
    {
        private readonly XmlSerializerNamespaces namespaces;
        private HttpWebRequest request;

        public WindowsPhoneNotification()
        {
            namespaces = new XmlSerializerNamespaces();
            namespaces.Add("wp", "WPNotification");
        }

        public WindowsPhoneNotification(string urlToNotify)
            : this()
        {
            UrlToNotify = urlToNotify;
        }

        public WindowsPhoneNotification(Notification notification, string httpNotification)
            : this(httpNotification)
        {
            Notification = notification;
        }

        public string UrlToNotify { get; set; }

        public Notification Notification { get; set; }

        public WindowsPhoneNotificationResponse SendNotification()
        {
            BuildRequest(UrlToNotify);
            string xml = GetXml();
            byte[] message = Encoding.Default.GetBytes(xml);
            request.ContentLength = message.Length;
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(message, 0, message.Length);
                stream.Close();
            }

            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                return CreateResponse(response);

            }
            catch (WebException exception)
            {
                return CreateResponse(exception.Response);
            }
        }

        private static WindowsPhoneNotificationResponse CreateResponse(WebResponse response)
        {
            var httpWebResponse = (HttpWebResponse) response;
            return new WindowsPhoneNotificationResponse
            {
                NotificationStatus = httpWebResponse.Headers["X-NotificationStatus"],
                ChannelStatus = httpWebResponse.Headers["X-SubscriptionStatus"],
                DeviceStatus = httpWebResponse.Headers["X-DeviceConnectionStatus"],
                StatusCode = httpWebResponse.StatusCode,
                Response = httpWebResponse
            };
        }

        private void BuildRequest(string urlToNotify)
        {
            request = (HttpWebRequest)WebRequest.Create(urlToNotify);
            request.Method = "POST";

            request.ContentType = "text/xml";
            if (Notification is TileNotification)
            {
                request.Headers.Add("X-WindowsPhone-Target", "token");
                request.Headers.Add("X-NotificationClass", "1");
            }
            else if (Notification is ToastNotification)
            {
                request.Headers.Add("X-WindowsPhone-Target", "toast");
                request.Headers.Add("X-NotificationClass", "2");
            }
        }

        private string GetXml()
        {
            var serializer = new XmlSerializer(Notification.GetType());
            string retorno;
            using (var ms = new MemoryStream())
            {
                serializer.Serialize(ms, Notification, namespaces);
                ms.Seek(0, SeekOrigin.Begin);
                using (var stream = new StreamReader(ms))
                    retorno = stream.ReadToEnd();
            }
            return retorno;
        }
    }
}