using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AutoPartsShop.Data.Base
{
    public interface IEntityBaseRepository<T> where T: class, IEntityBase, new ()
    {
        Task<IEnumerable<T>> GetAllAsync(); //za da gi zeme site brandovi od bazata
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetByIdAsync(int id);//za da vrati samo eden brend
        Task AddAsync(T entity);//za da dodademe podatoci vo bazata i ke bide void zatoa sto na userot ne mu vrakja nisto
        Task UpdateAsync(int id, T entity);//ja update bazata i mu ja vrakjame na korisnikot update bazata
        Task DeleteAsync(int id);//brisenje
    }
}
