using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceGateways.Interfaces
{
    public interface IChildrensServiceGateway<T, TK>
    {
        T Create(T t);
        T Read(TK id);
        List<T> ReadAll();
        T Update(T t);
        bool Delete(TK id);
        List<T> GetAllInstances(int gg_id);
    }
}
