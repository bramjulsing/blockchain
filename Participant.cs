namespace BlockchainProgram
{
    public class Participant{
        public string Name { get; set; }
        public int Balance { get; set; }

        public Participant(string name){
            Name = name;
            Balance = 0;
        }
    }
}