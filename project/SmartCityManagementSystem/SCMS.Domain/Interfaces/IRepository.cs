using System.Collections.Generic;
using System.Linq;

namespace SCMS.Domain.Interfaces
{
    public interface IRepository<T>
    {
        void Save(T entity);
        List<T> GetAll();
        T FindById(string id);
        bool Exists(string id);
        void Delete(string id);
    }
}
