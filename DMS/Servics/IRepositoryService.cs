namespace DMS.Servics;

public interface IRepositoryService<TEntity,IModel> where TEntity : class,new() where IModel : class
{
    Task<IEnumerable<IModel>> GetAllAsync(CancellationToken cancellationToken);
    Task<IModel>InsetAsyn(IModel model,CancellationToken cancellationToken);
    Task<IModel>UpdateAsyn(int id, IModel model, CancellationToken cancellationToken);
    Task<IModel> DelteAsyn(int id, CancellationToken cancellationToken);
    Task<IModel> GetByIdAsyn(int id,CancellationToken cancellationToken);
}
