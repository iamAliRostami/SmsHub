﻿namespace SmsHub.Core.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> ListAllAsync();
       // Task AddAsync(T entity);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity); 
        Task DeleteAsync(Guid id);
        Task<IReadOnlyList<T>> GetPagedReponseAsync(int page, int size);
    }
}
