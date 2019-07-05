namespace BlockchainProgram
{
    public class Transaction
    {
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public int Amount { get; set; }
        // Participant From { get; set; }
        // Participant To { get; set; }

        public Transaction(string fromAddress, string toAddress, int amount)
        {
            FromAddress = fromAddress;
            ToAddress = toAddress;
            Amount = amount;
        }

        // public Transaction(Participant fromParticipant, Participant toParticipant, int amount)
        // {
        //     From = fromParticipant;
        //     To = toParticipant;
        //     Amount = amount;
        // }
        // public void Execute()
        // {
        //     From.Balance =- Amount;
        //     To.Balance += Amount;
        // }
    }
}