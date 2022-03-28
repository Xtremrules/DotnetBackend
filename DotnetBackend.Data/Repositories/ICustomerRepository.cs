using DotnetBackend.Core.Entities;

namespace DotnetBackend.Data.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        IEnumerable<Customer> GetActiveCustomers();
        IEnumerable<Customer> GetDeletedCustomers();
    }
}
