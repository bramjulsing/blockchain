using Newtonsoft.Json;
using System;

namespace BlockchainProgram
{
    class Program
    {
        static void DisplayActions()
        {
            Console.WriteLine("Select an action:");
            Console.WriteLine("===============================");
            Console.WriteLine("1. Add a transaction");
            Console.WriteLine("2. Process pending transactions");
            Console.WriteLine("3. Display Blockchain");
            Console.WriteLine("4. Display balance");
            Console.WriteLine("5. Exit");
            Console.WriteLine("===============================\n");
        }
        static void Main(string[] args)
        {

            Blockchain coin74 = new Blockchain();
            coin74.Difficulty = 1;

            Console.WriteLine("\nCoin74 blockchain initialized.\n");
            
            int selection = 0;
            while (selection != 5)
            {
                switch (selection)
                {
                    case 1:
                        Console.WriteLine("Please enter the sender's name:");
                        string senderName = Console.ReadLine();
                        Console.WriteLine("Please enter the receiver's name:");
                        string receiverName = Console.ReadLine();
                        Console.WriteLine("Please enter the amount:");
                        string amount = Console.ReadLine();
                        coin74.SubmitTransaction(new Transaction(senderName, receiverName, int.Parse(amount)));
                        Console.WriteLine("Transaction added.\n");
                        break;
                    case 2:
                        Console.WriteLine("Please enter the miner's name:");
                        string minerName = Console.ReadLine();
                        coin74.ProcessPendingTransactions(minerName);
                        Console.WriteLine("Transactions processed. New block added to the chain.");
                        Console.WriteLine($"{minerName} rewarded with {coin74.Reward} coin74.\n");
                        break;
                    case 3:
                        Console.WriteLine("Blockchain:");
                        Console.WriteLine($"{JsonConvert.SerializeObject(coin74, Formatting.Indented)}\n");
                        break;
                    case 4:
                        Console.WriteLine("Please enter the participant's name:");
                        string participantName = Console.ReadLine();
                        Console.WriteLine($"{participantName}'s balance: {coin74.GetBalance(participantName)}.\n");
                        break;
                }

                DisplayActions();
                string action = Console.ReadLine();
                selection = int.Parse(action);
            }
        }
    }
}