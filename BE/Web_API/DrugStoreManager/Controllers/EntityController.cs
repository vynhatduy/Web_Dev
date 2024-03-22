using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DrugStoreManager.Controllers
{
    public class EntityController<TEntity> where TEntity: class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public EntityController(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        #region Select (Get)
        /// <summary>
        /// Get all => return to list or array Entity, same ./api/Controller/GetAll/
        /// Get By Id => return Entity if found, same ./api/Controller/Get/1
        /// Get By String => return Entity if found with some requirements such as username or address... same ./api/Controller/Get/Vy Nhat Duy
        /// </summary>
        /// <returns></returns>

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet.AsQueryable();
        }
        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }
        public List<TEntity> GetByString(string properties, string value)
        {
            /*
                        var ds = new List<TEntity>();
                        for (int i = 0; i < this.GetAll().Count() - 1; i++)
                        {
                            ds.Add(_dbSet.Find($"{properties}.contains(\"{value}\")"));
                        }
                        return ds;
            */


            // tạo tham số
            var parameter = Expression.Parameter(typeof(TEntity), "entity");
            // tạo biểu thức điều kiện
            var property = Expression.Property(parameter, properties);
            var constant = Expression.Constant(value);
            var containsmethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            var containscall = Expression.Call(property, containsmethod, constant);
            // biểu thức hoàn chỉnh 
            var lamda = Expression.Lambda<Func<TEntity, bool>>(containscall, parameter);
            return _dbSet.Where(lamda).ToList();
        }

        #endregion
        #region Post (Create)
        /// <summary>
        /// Create => return ok if data entity if vaild, same ./api/Controller/Create/
        /// </summary>
        /// <returns></returns>
        public String Create(TEntity entity)
        {
            try
            {
                _dbSet.Add(entity);
                _context.SaveChanges();
                return $"Adding successful obj";
            }
            catch (Exception e)
            {
                return "Adding fail obj with error: " + e.ToString();
            }
        }
        #endregion

        #region 1:Put; 2:patch (Update)
        /// <summary>
        /// UpdateEntity same ./api/Controller/Update
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// 
        public String UpdateAllEntity(TEntity entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
                return "Update successful";
            }
            catch (Exception e)
            {
                return "Update fail with error: " + e.ToString();
            }
        }

        public String Update(TEntity entity, params string[] propertiesUpdate)
        {
            try
            {
                _dbSet.Attach(entity);
                foreach (var property in propertiesUpdate)
                {
                    _context.Entry(entity).Property(property).IsModified = true;
                }
                _context.SaveChanges();
                return "Update successful";
            }
            catch (Exception e)
            {
                return "Update fail with error :" + e;
            }
        }
        #endregion

        #region Delete
        public string Delete(TEntity entity)
        {
            try
            {
                _dbSet.Remove(entity);
                _context.SaveChanges();
                return "Remove successful";
            }
            catch (Exception e)
            {
                return "Remove successful";
            }

        }
        #endregion
    }
}
