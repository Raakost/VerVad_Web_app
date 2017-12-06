﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceGateways.Interfaces
{
    public interface ILanguageServiceGateway<T>
    {
        List<T> ReadAll();
    }
}
