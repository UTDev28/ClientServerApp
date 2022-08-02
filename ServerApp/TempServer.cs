using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// This server loads the data from jokes.txt and conspiracies.txt. 
/// Listens to a request from the client
/// Response to the clients request
/// </summary>
namespace ServerApp
{
    public class TempServer
    {
        Random rand = new Random();
        string[] jokes;
        string[] conspiracies;
        const string JOKE_FILE = "jokes.txt";
        const string CONSP_FILE = "conspiracies.txt";

        public TempServer()
        {
              
        }
        public void LoadFiles()
        {
            try
            {
                jokes = File.ReadAllLines(JOKE_FILE); //Reads the file adn assigns it to jokes
                conspiracies = File.ReadAllLines(CONSP_FILE); //Reads the file adn assigns it to conspiracies
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Gets a random joke from the joke
        public string GetRandomJoke()
        {
            return jokes[rand.Next(jokes.Length)]; //Couns the jokes in the array and chooses a random one
        }

        //Gets a random conspiracy
        public string GetRandomConspiracy()
        {
            return conspiracies[rand.Next(conspiracies.Length)];
        }

    }
}
