using APISenac.Data.DataContracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APISenac.Services.Interfaces;
using APISenac.Models;

namespace APISenac.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
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

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();
            return true;
        }
    }
}
