namespace AbstractFactory.FastDb.Commands
{
    class DeleteCommand : FastCommand<int>
    {
        public DeleteCommand(string commandText) : base(commandText)
        {
        }

        public override int Execute(FastTransaction transaction) => 1;
    }
}