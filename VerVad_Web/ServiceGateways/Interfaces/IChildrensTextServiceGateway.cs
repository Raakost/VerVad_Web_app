using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceGateways.Interfaces
{
    public interface IChildrensTextServiceGateway<T, TK>
    {
        T Create(T t);
        T Read(TK id);
        T Update(T t);
        bool Delete(TK id);
        List<T> GetTextsFromGlobalGoal(int gg_id);

    }
}
