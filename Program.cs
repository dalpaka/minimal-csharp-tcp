using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;

namespace serverHoster
{
    class Program
    {
        IEnumerable<char> avaiable__port = "367567";
        static void Main(string[] args)
        {
            Console.Title = "ServerHoster";
            Server.Start(100, 756);
            Console.ReadKey();
        }
    }
}
