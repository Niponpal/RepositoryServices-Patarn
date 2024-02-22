
using AutoMapper;
using DMS.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace DMS.Servics
{
    public class RepositoryService<TEntity, IModel> : IRepositoryService<TEntity, IModel> where TEntity : class ,new() where IModel : class
       
    {
        private readonly IMapper mapper;
        private readonly DocterDb docterDb;

        public RepositoryService(IMapper mapper, DocterDb docterDb)
        {
            this.mapper = mapper;
            this.docterDb = docterDb;
            _dbSet=docterDb.Set<TEntity>();
            
        }

        private DbSet<TEntity> _dbSet { get; }

        public async Task<IModel> InsetAsyn(IModel model, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<IModel, TEntity>(model);
            _dbSet.Add(entity);
            await docterDb.SaveChangesAsync(cancellationToken);
            var insertmodel = mapper.Map<TEntity, IModel>(entity);
            return insertmodel;
        }



        public async Task<IModel> DelteAsyn(int id, CancellationToken cancellationToken)
        {
            var entitys = await _dbSet.FindAsync(id);
           
            if (entitys == null) return null;
            mapper.Map<TEntity, IModel>(entitys);
            _dbSet.Remove(entitys);
            await docterDb.SaveChangesAsync(cancellationToken);
            var DeletedModle=mapper.Map<TEntity, IModel>(entitys);
            return DeletedModle;
           
        }

       
        public async Task<IModel> GetByIdAsyn(int id, CancellationToken cancellationToken)
        {
            var entity=await _dbSet.FindAsync(id);
            if (entity == null) return null;
            var modleId=mapper.Map<TEntity,IModel>(entity);
            return modleId;
        }

        public async Task<IModel> UpdateAsyn(int id, IModel model, CancellationToken cancellationToken)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null) return null;
            mapper.Map(entity, model);
            await docterDb.SaveChangesAsync(cancellationToken);
            var UpdateModell = mapper.Map<TEntity, IModel>(entity);
            return UpdateModell;
        }

        async Task<IEnumerable<IModel>> IRepositoryService<TEntity, IModel>.GetAllAsync(CancellationToken cancellationToken)
        {
            var entitys = await _dbSet.ToListAsync(cancellationToken);
            if (entitys == null) return null;
            var data = mapper.Map<IEnumerable<IModel>>(entitys);
            return data;

        }

        
    }
}
