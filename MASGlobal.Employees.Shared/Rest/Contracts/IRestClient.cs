using System.Threading.Tasks;
using MASGlobal.Employees.Shared.Rest.Entities;

namespace MASGlobal.Employees.Shared.Rest.Contracts
{
    public interface IRestClient
    {
        Task<TResult> ExecuteGetResultAsync<TResult>(RestClientRequest requestInfo);

        Task<TResult> ExecutePostResultAsync<TResult>(RestClientRequest requestInfo);
    }
}