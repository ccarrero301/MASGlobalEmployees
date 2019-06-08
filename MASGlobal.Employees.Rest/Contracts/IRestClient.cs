using System.Threading.Tasks;
using MASGlobal.Employees.Rest.Entities;

namespace MASGlobal.Employees.Rest.Contracts
{
    internal interface IRestClient
    {
        Task<TResult> ExecutePostResultAsync<TResult>(RestClientRequest requestInfo);
    }
}