using System.IO;
using System.Net;
using System.Text;
using System.Xml.Serialization;

namespace WindowsPhoneNotificator
{
    public class WindowsPhoneNotification
    {
        private XmlSerializerNamespaces namespaces;
        private HttpWebRequest request;

        public WindowsPhoneNotification(string urlToNotify)
        {
            namespaces = new XmlSerializerNamespaces();
            namespaces.Add("wp", "WPNotification");
            BuildRequest(urlToNotify);
        }

        public WindowsPhoneNotification(Notification notification, string httpNotification)
            : this(httpNotification)
        {
            Notification = notification;
        }

        protected Notification Notification { get; set; }

        private void BuildRequest(string urlToNotify)
        {
            request = (HttpWebRequest)WebRequest.Create(urlToNotify);
            request.Method = "POST";

            request.ContentType = "text/xml";
            request.Headers.Add("X-WindowsPhone-Target", "token");
            request.Headers.Add("X-NotificationClass", "1");
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

        public WindowsPhoneNotificationResponse SendNotification()
        {
            var xml = GetXml();
            byte[] message = Encoding.Default.GetBytes(xml);
            request.ContentLength = message.Length; 
            using (var stream = request.GetRequestStream())
            {
                stream.Write(message, 0, message.Length);
                stream.Close();
            }

            var response = (HttpWebResponse)request.GetResponse();

            return new WindowsPhoneNotificationResponse
            {
                NotificationStatus = response.Headers["X-NotificationStatus"],
                ChannelStatus = response.Headers["X-SubscriptionStatus"],
                DeviceStatus = response.Headers["X-DeviceConnectionStatus"],
            };
        }
    }
}