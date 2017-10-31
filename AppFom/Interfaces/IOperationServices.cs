using System;
using System.Threading.Tasks;
using AppFom.Models;

namespace AppFom.Interfaces
{
    public interface IOperationServices
    {

        Task<OperResult<bool>> CheckLogin<T>(T generic);

    }
}
