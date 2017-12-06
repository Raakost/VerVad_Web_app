using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceGateways.Interfaces
{
    public interface IFrontPageServiceGateway<T, TK>
    {
        T Read(TK id);
        T Update(T t);
    }
}
