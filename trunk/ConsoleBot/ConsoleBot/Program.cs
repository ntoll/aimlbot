using System;
using AIMLbot;

namespace ConsoleBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Bot myBot = new Bot();
            User myUser = new User("consoleUser", myBot);
            myBot.loadAIMLFromFiles();
            while (true)
            {
                Console.Write("You: ");
                string input = Console.ReadLine();
                if (input.ToLower() == "quit")
                {
                    break;
                }
                else
                {
                    Request r = new Request(input, myUser, myBot);
                    Result res = myBot.Chat(r);
                    Console.WriteLine("Bot: " + res.Output);
                }
            }
        }
    }
}
