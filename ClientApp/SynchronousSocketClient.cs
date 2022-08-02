using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClientApp
{
    public class SynchronousSocketClient
    {
        const int SERVER_PORT = 11000;
        const string IP_ADDRESS = "127.0.0.1";


        //Sends a string request to the server
        public string ContactServer(string request)
        {
            string responseString = "";

            try
            {
                TcpClient tcpClient = new TcpClient();
                tcpClient.Connect(IPAddress.Parse(IP_ADDRESS), SERVER_PORT);//Convert string to IP address
                NetworkStream networkStream = tcpClient.GetStream(); //Allows synchronous listening

                StreamReader streamReader = new StreamReader(networkStream); //new instance of StreamReader
                StreamWriter streamWriter = new StreamWriter(networkStream); //new instance of StreamWritter

                streamWriter.AutoFlush = true; //Makes sure to flush out previous requests
                streamWriter.WriteLine(request);
                responseString = streamReader.ReadLine();
                networkStream.Close(); //Closes the network stream 
                tcpClient.Close(); //Closes TCP client
            }
            catch(Exception ex)
            {
                responseString = ex.Message;//If there is an error, it will be displayed as the string variable responseString
            }
            return responseString;
        }
    }
}
