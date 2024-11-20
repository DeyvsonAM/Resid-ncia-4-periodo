using APISenac.Data.DataContracts;
using APISenac.Models;

namespace APISenac.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;

            // Inicializando os repositórios com o contexto do banco de dados
            PermitionRepository = new Repository<Permition>(_context);
            SistemaRepository = new Repository<Sistema>(_context);
            ProfileRepository = new Repository<Profile>(_context);
            UserRepository = new Repository<User>(_context);
            CustomAtributeRepository = new Repository<CustomAtribute>(_context);
        }

        // Repositórios
        public IRepository<Permition> PermitionRepository { get; }
        public IRepository<Sistema> SistemaRepository { get; }
        public IRepository<Profile> ProfileRepository { get; }
        public IRepository<User> UserRepository { get; }
        public IRepository<CustomAtribute> CustomAtributeRepository { get; }

         /// <summary>
        /// Força o início de uma nova transação.
        /// </summary>
        public void ForceBeginTransaction()
        {
            if (_currentTransaction == null)
            {
                _currentTransaction = _context.Database.BeginTransaction(_isolationLevel);
            }
        }

        /// <summary>
        /// Confirma a transação atual (não faz nada se não existir transação).
        /// </summary>
        public async Task CommitAsync()
        {
            if (_currentTransaction != null)
            {
                await _context.SaveChangesAsync();
                await _currentTransaction.CommitAsync();
                await _currentTransaction.DisposeAsync();
                _currentTransaction = null;
            }
        }

        /// <summary>
        /// Confirma a transação atual.
        /// </summary>
        public void Commit()
        {
            if (_currentTransaction != null)
            {
                _context.SaveChanges();
                _currentTransaction.Commit();
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }

        /// <summary>
        /// Desfaz a transação atual (não faz nada se não existir transação).
        /// </summary>
        public void RollbackTransaction()
        {
            if (_currentTransaction != null)
            {
                _currentTransaction.Rollback();
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }

        /// <summary>
        /// Salva alterações no banco de dados, abrindo previamente uma transação
        /// apenas quando não existe uma. A transação é aberta com o nível de isolamento
        /// configurado antes da chamada deste método.
        /// </summary>
        public async Task<int> SaveChangesAsync()
        {
            if (_currentTransaction == null)
            {
                ForceBeginTransaction();
            }

            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Define o nível de isolamento para novas transações.
        /// </summary>
        /// <param name="isolationLevel">O nível de isolamento desejado.</param>
        public void SetIsolationLevel(IsolationLevel isolationLevel)
        {
            _isolationLevel = isolationLevel;
        }
    }

    public interface IUnitOfWork
    {
        void ForceBeginTransaction();
        Task CommitAsync();
        void Commit();
        void RollbackTransaction();
        Task<int> SaveChangesAsync();
        void SetIsolationLevel(IsolationLevel isolationLevel);
    }
}