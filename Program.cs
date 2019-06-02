using System;
using Newtonsoft.Json;

namespace BlockchainProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            var startTime = DateTime.Now;

            Blockchain digicoin = new Blockchain();
            digicoin.Difficulty = 2;
            digicoin.AddBlock(new Block(DateTime.Now, null, "{sender:Elon,receiver:Marc,amount:10}"));  
            digicoin.AddBlock(new Block(DateTime.Now, null, "{sender:Marc,receiver:Elon,amount:5}"));  
            digicoin.AddBlock(new Block(DateTime.Now, null, "{sender:Marc,receiver:Elon,amount:5}"));  
            
            var endTime = DateTime.Now;

            Console.WriteLine(JsonConvert.SerializeObject(digicoin, Formatting.Indented));
            Console.WriteLine($"Duration: {endTime - startTime}");
            Console.WriteLine($"Is Chain Valid: {digicoin.IsValid()}");
        }
    }
    
}