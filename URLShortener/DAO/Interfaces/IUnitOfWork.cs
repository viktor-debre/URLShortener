namespace URLShortener.DAO.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }

        IURLRepository URLs { get; }

        int Save();
    }
}
