using DotnetBackend.Core.Entities;

namespace DotnetBackend.Data.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<IEnumerable<Customer>> GetActiveCustomers();
        Task<IEnumerable<Customer>> GetDeletedCustomers();
    }
}
