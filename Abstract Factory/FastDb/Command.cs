using AbstractFactory.Data;

namespace AbstractFactory.FastDb
{
    public abstract class Command<T> : ICommand
    {
        private string CommandText;

        public Command(string commandText)
        {
            CommandText = commandText;
        }

        public abstract T Execute(Transaction transaction);
    }
}