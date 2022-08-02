using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

/// <summary>
/// Sets up a listener to get the request from the client, then response to that request.
/// </summary>
namespace ServerApp
{
    internal class SynchronousSocketListener
    {
        TempServer tempServer;
        TcpListener tcpListener;

        const int PORT = 11000;
        const string SERVER_ADDRESS = "127.0.0.1"; //local IP address assigned to SERVER_ADDRESS

        public SynchronousSocketListener()
        {
            tempServer = new TempServer(); //creates new tempServer

            tempServer.LoadFiles();
        }
        //method that listens to the request
        public void StartListening()
        {
            IPAddress iPAddress = IPAddress.Parse(SERVER_ADDRESS); //parses the IP Address string
            tcpListener = new TcpListener(iPAddress, PORT);


            tcpListener.Start(); //starts the listener 

            Respond(); 
        }
        //method that responds to the request
        public void Respond()
        {
            Socket socket;

            //The loop will allow multiple requests before the server shuts down
            while (true)
            {
                try
                {
                    //save the tcp connection between the client and server as a socket connection
                    //a socket connection can save various protocols, making it versatile
                    socket = tcpListener.AcceptSocket();
                    //access the data stream between the client and server

                   //TcpClient tcp = tcpListener.AcceptTcpClient();

                    NetworkStream ns = new NetworkStream(socket);

                    StreamWriter writer = new StreamWriter(ns);
                    StreamReader reader = new StreamReader(ns);

                    //it forces an immediate write to the data stream
                    writer.AutoFlush = true;

                    string clientRequest = reader.ReadLine(); //takes input and saves it as client request

                    if(clientRequest.ToUpper() == "joke")
                    {
                        //send response back to client 
                        string joke = tempServer.GetRandomJoke();

                        //send joke back to client 
                        writer.WriteLine($"Joke: {joke}");

                    }
                    else if (clientRequest.ToUpper() == "CONSPIRACY")
                    {
                        //send response back to client
                        string conspiracy = tempServer.GetRandomConspiracy();

                        //send joke back to client
                        writer.WriteLine($"Conspiracy: {conspiracy}");
                    }
                    else
                    {
                        //displays the clients request back to the client
                        writer.WriteLine($"Could not process request: {clientRequest}");
                    }
  

                    //check the request
                    //respond to the request
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
