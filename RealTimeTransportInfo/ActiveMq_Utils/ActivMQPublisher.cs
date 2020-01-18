using Apache.NMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveMq_Utils
{
    public class ActivMQPublisher
    {

        private string user;
        private string pwd;
        private string host;
        private string port;
        private string topic;

        public ActivMQPublisher(string user, string pwd, string host, string port, string topic)
        {
            this.user = user;
            this.pwd = pwd;
            this.host = host;
            this.port = port;
            this.topic = topic;
        }
        public void sendMsg(string msg)
        {
            String user = env("ACTIVEMQ_USER", this.user);
            String password = env("ACTIVEMQ_PASSWORD", this.pwd);
            String host = env("ACTIVEMQ_HOST", this.host);
            int port = Int32.Parse(env("ACTIVEMQ_PORT", this.port));
            String destination = this.topic;

 
         
            //String body = "";
            //for (int i = 0; i < size; i++)
            //{
            //    body += DATA[i % DATA.Length];
            //}

            String brokerUri = "activemq:tcp://" + host + ":" + port;
            Uri uri = new Uri(brokerUri);
            IConnectionFactory factory = new Apache.NMS.ActiveMQ.ConnectionFactory(uri);

            IConnection connection = factory.CreateConnection(user, password);
            connection.Start();
            ISession session = connection.CreateSession(AcknowledgementMode.AutoAcknowledge);
            IDestination dest = session.GetTopic(destination);
            IMessageProducer producer = session.CreateProducer(dest);
            producer.DeliveryMode = MsgDeliveryMode.NonPersistent;

            producer.Send(session.CreateTextMessage(msg));

             
            connection.Close();
        }

        private static String env(String key, String defaultValue)
        {
            String rc = System.Environment.GetEnvironmentVariable(key);
            if (rc == null)
            {
                return defaultValue;
            }
            return rc;
        }

      
    }
    }

