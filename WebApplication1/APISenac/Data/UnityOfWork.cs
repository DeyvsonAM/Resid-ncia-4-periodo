



using System.Data;
using APISenac.Data;
using APISenac.Data.DataContracts;
using APISenac.Models;
using Microsoft.EntityFrameworkCore.Storage;

public class UnitOfWork : IUnitOfWork
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
        ProfileRepository = new Repository<BDProfile>(_context);
        UserRepository = new Repository<User>(_context);
        CustomAtributeRepository = new Repository<CustomAtribute>(_context);
        ProfilePermissionRepository = new Repository<ProfilePermission>(_context);
    }

    // Repositórios
    public IRepository<ProfilePermission> ProfilePermissionRepository { get; }
    public IRepository<Permission> PermitionRepository { get; }
    public IRepository<Sistema> SistemaRepository { get; }
    public IRepository<BDProfile> ProfileRepository { get; }
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
        if (_currentTransaction != null)
        {
            await _currentTransaction.CommitAsync();
            _currentTransaction.Dispose();
            _currentTransaction = null;  // Limpa a transação
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Desfaz a transação atual (não faz nada se não existir transação).
    /// </summary>
    public async Task RollbackAsync()
    {
        if (_currentTransaction != null)
        {
            await _currentTransaction.RollbackAsync();
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
            // Caso não exista uma transação, cria uma transação automaticamente
            ForceBeginTransaction();
        }

        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public void Commit()
    {
        throw new NotImplementedException();
    }

    public void RollbackTransaction()
    {
        throw new NotImplementedException();
    }

    public void SetIsolationLevel(IsolationLevel isolationLevel)
    {
        throw new NotImplementedException();
    }
}
