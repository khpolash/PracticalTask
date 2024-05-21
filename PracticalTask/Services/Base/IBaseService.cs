using System.Linq.Expressions;

namespace PracticalTask.Services.Base;

public interface IBaseService<T, TViewModel> : IDisposable
    where T : class
    where TViewModel : class
{
    IQueryable<T> GetAll();
    IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeProperties);
    Task<List<TViewModel>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);
    Task<List<TViewModel>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
    Task<List<TViewModel>> GetAllAsync();
    Task<List<TViewModel>> GetAllAsync(Expression<Func<T, bool>> predicate = null);
    Task<TViewModel> GetByIdAsync(int? id);
    Task<TViewModel> FirstOrDefaultAsync(int? id);
    Task<TViewModel> FirstOrDefaultAsync(long? id, params Expression<Func<T, object>>[] includeProperties);
    Task<TViewModel> InsertAsync(TViewModel model);
    Task<TViewModel> UpdateAsync(TViewModel model);
    Task<TViewModel> UpdateAsync(int id, TViewModel model);
    Task<TViewModel> DeleteAsync(int id);
}