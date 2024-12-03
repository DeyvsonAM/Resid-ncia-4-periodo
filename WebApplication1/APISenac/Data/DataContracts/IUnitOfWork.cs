using APISenac.Models;
using System.Data;




namespace APISenac.Data.DataContracts


{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Permission> PermitionRepository { get; }
        IRepository<Sistema> SistemaRepository { get; }
        IRepository<BDProfile> ProfileRepository { get; }
        IRepository<User> UserRepository { get; }
        IRepository<CustomAtribute> CustomAtributeRepository { get; }
        IRepository<T> GetRepository<T>() where T : class;
        IRepository<ProfilePermission> ProfilePermissionRepository { get; }

        void ForceBeginTransaction();

        /// <summary>
        /// Commits the current transaction (does nothing when none exists).
        /// </summary>
        Task CommitAsync();

        /// <summary>
        /// Commits the current transaction
        /// </summary>
        void Commit();

        /// <summary>
        /// Rolls back the current transaction (does nothing when none exists).
        /// </summary>
        void RollbackTransaction();

        /// <summary>
        /// Saves changes to database, previously opening a transaction
        /// only when none exists. The transaction is opened with isolation
        /// level set in Unit of Work before calling this method.
        /// </summary>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// Sets the isolation level for new transactions.
        /// </summary>
        /// <param name="isolationLevel"></param>
        void SetIsolationLevel(IsolationLevel isolationLevel);

        Task RollbackAsync();


    }
}

