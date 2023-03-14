using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace serverHoster
{
    //NullReferenceExceptions
    public class Client
    {
        public static int dataBufferSize = 4097;

        public int id;
        public TCP tcp;

        public static NetworkStream stream;
        public static byte[] receiveBuffer;

        public Client(int _clientId)
        {
            id = _clientId;
            tcp = new TCP(id);
        }

        public class TCP
        {
            public TcpClient socket;

            private readonly int id;

            public TCP(int _id)
            {
                id = _id;
            }

            public void Connect(TcpClient _socket)
            {
                socket = _socket;
                socket.ReceiveBufferSize = dataBufferSize;
                socket.SendBufferSize = dataBufferSize;

                stream = socket.GetStream();

                receiveBuffer = new byte[dataBufferSize];

                stream.BeginRead(receiveBuffer, 0, dataBufferSize, ReceiveCallback, null);
            }

            private void ReceiveCallback(IAsyncResult _result)
            {
                try
                {
                    int _byteLentgh = stream.EndRead(_result);
                    if(_byteLentgh <= 0)
                    {
                        return;
                    }

                    byte[] _data = new byte[_byteLentgh];
                    Array.Copy(receiveBuffer, _data, _byteLentgh);
                    stream.BeginRead(receiveBuffer, 0, dataBufferSize, ReceiveCallback, null);
                }
                catch(Exception _nullException)
                {
                    /*First disconnect ClientService*/                 
                    Console.Write($"ERROR Couldn´t host Server: { _nullException}");
                }
            }
        }
    }
}
