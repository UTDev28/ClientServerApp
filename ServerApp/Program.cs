//This is our server

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics; //allows us to use process
using System.Net;

namespace ServerApp
{
    class Program
    {
        static void Main(String[] args)
        {

            //Calls the itms in TempServer.CS file
            TempServer TempServer = new TempServer();
            TempServer.LoadFiles();

            Console.WriteLine("Welcome to Kevin's Joke/Conspiracy Server");
            Console.WriteLine("----------------------------------------");

            //while (true)
            //{
            //    Console.WriteLine("type q to quite");
            //    string userInput = Console.ReadLine(); //takes the users input

            //    if (userInput == "q")
            //    {
            //        break;
            //    }
            //    Console.WriteLine($"Joke: {TempServer.GetRandomJoke}"); //Appends the random joke from the GetRandomJoke method to the output message
            //    Console.WriteLine($"Conspiracy: {TempServer.GetRandomConspiracy}"); //Appends the random conspiracy from the GetRandomConspiracy method to the output message

            //}

            //allows the server to run at the same time
            Process process = new Process();
            process.StartInfo.FileName = @"C:\Users\kreid\source\repos\ClientServerApp\ClientApp\bin\Debug\ClientApp.exe";
            process.Start();

            //we want to start the server and start listening for requests
            SynchronousSocketListener ssl = new SynchronousSocketListener();
            ssl.StartListening();
        }
    }
}
