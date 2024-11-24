using APISenac.Data.DataContracts;
using APISenac.Models;
using System.Data;
using Microsoft.EntityFrameworkCore.Storage;
using IUnitOfWork = APISenac.Data.DataContracts.IUnitOfWork;



namespace APISenac.Data
{
    public class UnitOfWork : APISenac.Data.DataContracts.IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Dictionary<Type, object> _repositories = new();
         private IDbContextTransaction _currentTransaction;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;

            // Inicializando os repositórios com o contexto do banco de dados
            PermitionRepository = new Repository<Permission>(_context);
            SistemaRepository = new Repository<Sistema>(_context);
            ProfileRepository = new Repository<Profile>(_context);
            UserRepository = new Repository<User>(_context);
            CustomAtributeRepository = new Repository<CustomAtribute>(_context);
        }

        // Repositórios
        public IRepository<Permission> PermitionRepository { get; }
        public IRepository<Sistema> SistemaRepository { get; }
        public IRepository<Profile> ProfileRepository { get; }
        public IRepository<User> UserRepository { get; }
        public IRepository<CustomAtribute> CustomAtributeRepository { get; }
        public IRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof(T);

            // Verifica se já existe um repositório para a entidade
            if (!_repositories.ContainsKey(type))
            {
                // Cria uma nova instância do repositório e armazena no dicionário
                var repository = new Repository<T>(_context);
                _repositories[type] = repository;
            }

            return (IRepository<T>)_repositories[type];
        }

         /// <summary>
        /// Força o início de uma nova transação.
        /// </summary>
       public void ForceBeginTransaction()
{
    // Verifica se há uma transação ativa
    if (_currentTransaction != null)
    {
        // Faz rollback na transação ativa antes de descartá-la
        _currentTransaction.Rollback();
        _currentTransaction.Dispose();
    }

    // Inicia uma nova transação e armazena a transação ativa na variável
    _currentTransaction = _context.Database.BeginTransaction();
}

        /// <summary>
        /// Confirma a transação atual (não faz nada se não existir transação).
        /// </summary>
        public async Task CommitAsync()
{
    if (_context.Database.CurrentTransaction != null)
    {
        await _context.Database.CurrentTransaction.CommitAsync();
    }
    await _context.SaveChangesAsync();
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
        throw new NotImplementedException();
    }

    public void Dispose()
        {
            _context.Dispose();
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