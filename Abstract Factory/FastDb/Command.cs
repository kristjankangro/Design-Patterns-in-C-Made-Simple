using AbstractFactory.Data;

namespace AbstractFactory.FastDb
{
    public abstract class Command<TResult> : ICommand
    {
        private string CommandText { get; }

        public abstract TResult Execute(Transaction transaction);

        protected Command(string commandText)
        {
            this.CommandText = commandText;
        }
    }
}