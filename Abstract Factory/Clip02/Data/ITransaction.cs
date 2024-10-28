namespace Demo.Clip02.Data
{
    public interface ITransaction
    {
        void Commit();
        void Rollback();
    }
}