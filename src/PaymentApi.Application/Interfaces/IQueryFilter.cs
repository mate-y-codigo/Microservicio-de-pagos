using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApi.Application.Interfaces
{
    public interface IQueryFilter<T, TRequest>
    {
        IQueryable<T> Aplly(IQueryable<T> query, TRequest request);
    }
}
