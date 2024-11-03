namespace AbstractFactory.Data
{
    public interface IConnection
    {
        void Connect(string connectionString);
        void Disconnect();
        object Execute(ICommand command, ITransaction transaction);
    }
}