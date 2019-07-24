using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeepoExamProject.BusinessLayer
{
    public interface IBusinessLayer <TEntity> where TEntity : class
    {
        IQueryable<TEntity> Search(string sortby, string order);
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetAsync(int Id);
        void Post(TEntity entity);
        Task Delete(int Id);
        Task Update(TEntity entity);
        Task SaveAsync();
    }
}
