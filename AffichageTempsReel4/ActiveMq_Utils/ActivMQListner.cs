﻿using Apache.NMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Apache.NMS.ActiveMQ;

namespace ActiveMq_Utils
{
    public class ActivMQListner
    {
        public event msgHandler eventMsg;
        public delegate void msgHandler(ActivMQListner l, ITextMessage msg);

        private string user;
        private string pwd;
        private string host;
        private string port;
        private string topic;

        public ActivMQListner(string  user, string pwd, string host, string port, string topic)
        {
            this.user = user;
            this.pwd = pwd;
            this.host = host;
            this.port = port;
            this.topic = topic;
        }
        public  void start()
        {
            Console.WriteLine("Starting up Listener.");

            String user = env("ACTIVEMQ_USER", this.user);
            String password = env("ACTIVEMQ_PASSWORD", this.pwd);
            String host = env("ACTIVEMQ_HOST", this.host);
            int port = Int32.Parse(env("ACTIVEMQ_PORT", this.port));
            String destination = this.topic;
            //arg(args, 0, "Info_Transport");

            String brokerUri = "activemq:tcp://" + host + ":" + port + "?transport.useLogging=true";
            Uri uri = new Uri(brokerUri);

            //NMSConnectionFactory factory = new NMSConnectionFactory(uri);
            IConnectionFactory factory = new Apache.NMS.ActiveMQ.ConnectionFactory(uri);

            IConnection connection = factory.CreateConnection(user, password);
            connection.Start();
            ISession session = connection.CreateSession(AcknowledgementMode.AutoAcknowledge);
            IDestination dest = session.GetTopic(destination);

            IMessageConsumer consumer = session.CreateConsumer(dest);
            DateTime start = DateTime.Now;
             
            Console.WriteLine("Waiting for messages...");

            while (true)
            {
                try
                {


                    IMessage msg = consumer.Receive();
                    if (msg is ITextMessage)
                    {
                        ITextMessage txtMsg = msg as ITextMessage;
                        String body = txtMsg.Text;
                        // Console.WriteLine("Message " + body);
                        if (eventMsg != null)
                            eventMsg(this, txtMsg);

                    }
                    else
                    {
                        Console.WriteLine("Unexpected message type: " + msg.GetType().Name);
                    }



                }
                catch (Exception ex)
                {

                    Console.WriteLine("Exception ..." + ex.Message);
                }

            }
             
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

        private static String arg(String[] args, int index, String defaultValue)
        {
            if (index < args.Length)
            {
                return args[index];
            }
            return defaultValue;
        }
    }
}
