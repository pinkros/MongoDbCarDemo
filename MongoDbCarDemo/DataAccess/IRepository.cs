using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IRepository<T>
    {
        void Add(T item);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetByMake(string make);
        IEnumerable<T> GetByModel(string model);
        IEnumerable<T> GetByColor(string color);
        void UpdateMake(object id, string make);
        void UpdateModel(object id, string model);
        void UpdateColor(object id, string color);
        void UpdateHorsePower(object id, int horsePower);
        void Replace(object id, T item);
        void Delete(object id);
    }
}
