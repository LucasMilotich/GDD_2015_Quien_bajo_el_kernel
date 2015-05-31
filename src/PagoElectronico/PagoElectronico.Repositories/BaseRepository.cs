using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PagoElectronico.Repositories
{
    public abstract class BaseRepository<T>
    {
        public abstract IEnumerable<T> GetAll();

        public abstract T Get(int id);

        public abstract int Insert(T entity);

        public abstract void Update(T entity);

        public abstract void Delete(T entity);
    }
}
