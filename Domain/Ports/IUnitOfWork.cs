using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dtos;

namespace Domain.Ports
{
    public interface IUnitOfWork
    {
        Task<Response<bool>> CommitAsync();
    }
}