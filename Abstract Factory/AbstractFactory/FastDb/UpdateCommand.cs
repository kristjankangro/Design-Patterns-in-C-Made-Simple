namespace Demo.AbstractFactory.FastDb
{
    public class UpdateCommand : Command<int>
    {
        public UpdateCommand(string commandText) : base(commandText)
        {
        }

        public override int Execute(Transaction transaction) => 2;
    }
}