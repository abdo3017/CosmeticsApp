using MyApp.Domain.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Service
{
    public interface IBaseService : IDisposable
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
