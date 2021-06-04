using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapes.API.Repository
{
    public interface IRepository<T> where T: class
    {
        public IEnumerable<T> GetAll();

        public T Update(Guid id, T item);

        public bool Delete(Guid id);

        public T Add(T item);

        public T GetById(Guid id);

        public T GetByName(string name);
    }
}
