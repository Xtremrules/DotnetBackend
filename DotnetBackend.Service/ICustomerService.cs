using DotnetBackend.Core.DTO;

namespace DotnetBackend.Service
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDTO>> GetActiveCustomers();
        IEnumerable<CustomerDTO> GetAllCustomers();

        Task<CustomerDTO> GetCustomerByIdAndPhoneNumber(OTPRequest otpRequest);

        Task<CustomerDTO> CreateCustomer(Customer customer);

        Task<CustomerDTO> ActivateCustomer(OTPValidateRequest oTPValidateRequest);

        Task<string> ResendOTP(OTPRequest otpRequest);
    }
}
