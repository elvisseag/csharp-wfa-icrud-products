using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICRUD_Productos.Service
{
    public interface ICrudDao<T>
    {
        //definir las firmas
        void create(T t);
        void update(T t);
        void delete(T t);
        T findForId(int t);
        List<T> readAll();
    }
}
