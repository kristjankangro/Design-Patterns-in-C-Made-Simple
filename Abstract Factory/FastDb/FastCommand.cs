using AbstractFactory.Data;

namespace AbstractFactory.FastDb
{
    abstract class FastCommand<TResult> : ICommand
    {
        private string CommandText { get; }

        public abstract TResult Execute(FastTransaction transaction);

        protected FastCommand(string commandText)
        {
            this.CommandText = commandText;
        }
    }
}