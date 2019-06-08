using System.Threading.Tasks;
using MASGlobal.Employees.Rest.Entities;

namespace MASGlobal.Employees.Rest.Contracts
{
    public interface IRestClient
    {
        Task<TResult> ExecuteGetResultAsync<TResult>(RestClientRequest requestInfo);

        Task<TResult> ExecutePostResultAsync<TResult>(RestClientRequest requestInfo);
    }
}