using APISenac.Data.DataContracts;
using APISenac.Services.Interfaces;
using APISenac.Models;

namespace APISenac.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        protected readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<T> _repository; // Repositório genérico para a entidade T

        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<T>(); // Obtém o repositório específico para a entidade
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync(); // Inclui salvar mudanças e confirmar transação
            return entity;
        }

        public async Task<T> UpdateAsync(Guid id, T updatedEntity)
        {
            // Localizar a entidade existente no banco
            var existingEntity = await _unitOfWork.GetRepository<T>().GetByIdAsync(id);
            if (existingEntity == null)
                return null; // Ou lançar uma exceção, se preferir

            // Atualizar os valores da entidade existente
            _unitOfWork.GetRepository<T>().Update(updatedEntity);

            // Salvar as mudanças no banco
            await _unitOfWork.CommitAsync();

            return updatedEntity;
        }

        public virtual async Task<bool> InactiveAsync(Guid id)
        {
            // Recupera a entidade pelo ID
            T entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            // Usando reflexão para buscar a propriedade 'Active' e alterá-la para false
            var activeProperty = typeof(T).GetProperty("Active");
            if (activeProperty != null && activeProperty.CanWrite)
            {
                activeProperty.SetValue(entity, false); // Define o campo 'Active' como falso
            }
            else
            {
                // Se a propriedade 'Active' não existir ou não for gravável, retorna false
                return false;
            }

            // Atualiza a entidade e persiste a alteração
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            return true;
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

