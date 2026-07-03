using AssetManagementSystem.Domain.Interfaces;

namespace AssetManagementSystem.Infrastructure.Repositories;

public interface Repository<T> : IRepository<T> where T : class
{
    
}