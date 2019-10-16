using System;
using System.Collections.Generic;
using System.Text;

namespace Renting.Microservice.Domain
{
    public interface IConfigProvider
    {
        string GetVal(string key);
    }
}
