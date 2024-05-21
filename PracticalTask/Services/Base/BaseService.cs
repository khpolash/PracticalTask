using AutoMapper.QueryableExtensions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PracticalTask.Collections;
using PracticalTask.DbConnection;
using System.Linq.Expressions;

namespace PracticalTask.Services.Base;

public class BaseService<T, TViewModel> : IBaseService<T, TViewModel> where T : class where TViewModel : class
{
    private readonly PracticalTaskDbContext _context;
    private readonly DbSet<T> entities;
    private readonly IMapper _mapper;

    public BaseService(PracticalTaskDbContext context, IMapper mapper)
    {
        _context = context;
        entities = _context.Set<T>();
        _mapper = mapper;
    }

    public IQueryable<T> GetAll()
    {
        return entities;
    }

    public IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = entities;
        query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        return query;
    }
    public async Task<List<TViewModel>> GetAllAsync()
    {
        var entityList = await entities.ToListAsync();
        return _mapper.Map<List<TViewModel>>(entityList);
    }
    public async Task<List<TViewModel>> GetAllAsync(Expression<Func<T, bool>> predicate = null)
    {
        var query = entities.AsQueryable();
        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        var list = await query.ToListAsync();
        return _mapper.Map<List<TViewModel>>(list);
    }

    public async Task<List<TViewModel>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = entities;
        query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        var entityList = await query.ToListAsync();
        return _mapper.Map<List<TViewModel>>(entityList);
    }
    public async Task<List<TViewModel>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = entities;
        query = query.Where(predicate);
        query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        var entityList = await query.ToListAsync();
        return _mapper.Map<List<TViewModel>>(entityList);
    }

    public async Task<TViewModel> GetByIdAsync(int? id)
    {
        var entity = await entities.FindAsync(id);
        return _mapper.Map<TViewModel>(entity);
    }
    public async Task<TViewModel> FirstOrDefaultAsync(int? id)
    {
        var entity = await entities.FindAsync(id);
        return _mapper.Map<TViewModel>(entity);
    }

    public async Task<TViewModel> FirstOrDefaultAsync(long? id, params Expression<Func<T, object>>[] includeProperties)
    {
        IQueryable<T> query = entities;
        query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        var entity = await query.FirstOrDefaultAsync(e => EF.Property<long>(e, "Id") == id);
        return _mapper.Map<TViewModel>(entity);
    }


    public async Task<TViewModel> InsertAsync(TViewModel model)
    {
        var entity = _mapper.Map<T>(model);
        await entities.AddAsync(entity);
        await _context.SaveChangesAsync();
        return _mapper.Map<TViewModel>(entity);
    }

    public async Task<TViewModel> UpdateAsync(TViewModel model)
    {
        var entity = _mapper.Map<T>(model);
        entities.Update(entity);
        await _context.SaveChangesAsync();
        return _mapper.Map<TViewModel>(entity);
    }

    public async Task<TViewModel> UpdateAsync(int id, TViewModel model)
    {
        var data = await entities.FindAsync(id);
        if (data != null)
        {
            model.CopyPropertiesTo(data);
            entities.Update(data);
            await _context.SaveChangesAsync();
            return _mapper.Map<TViewModel>(model);
        }
        return null;
    }

    public async Task<TViewModel> DeleteAsync(int id)
    {
        var entity = await entities.FindAsync(id);
        if (entity != null)
        {
            entities.Remove(entity);
            await _context.SaveChangesAsync();
        }
        return _mapper.Map<TViewModel>(entity);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}