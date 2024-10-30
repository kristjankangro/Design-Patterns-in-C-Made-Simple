using Demo.Clip01.Data;

namespace Demo.AbstractFactory.FastDb
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