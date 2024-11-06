namespace AbstractFactory.Data
{
    public interface IConnection
    {
        void Connect();
        void Disconnect();
        object Execute(ICommand command, ITransaction transaction);
        /// <summary>
        /// This is Factory method
        /// </summary>
        /// <returns></returns>
        ITransaction BeginTransaction(); 
    }
}