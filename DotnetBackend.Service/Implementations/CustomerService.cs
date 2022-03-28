using DotnetBackend.Core.DTO;
using DotnetBackend.Data.Repositories;

namespace DotnetBackend.Service.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IOTPService otpService;

        public CustomerService(ICustomerRepository customerRepository, IOTPService otpService)
        {
            this.customerRepository = customerRepository;
            this.otpService = otpService;
        }

        public async Task<CustomerDTO> ActivateCustomer(OTPValidateRequest oTPValidateRequest)
        {
            bool result = await otpService.ValidateOtp(oTPValidateRequest);

            if (!result)
            {
                throw new ApplicationException("Could not Validate OTP");
            }

            var customer = await customerRepository.GetById(oTPValidateRequest.CustomerId);

            customer.Status = Core.Status.ACTIVE;

            await customerRepository.Update(customer, true);

            var @return = new CustomerDTO()
            {
                CreatedDate = customer.CreatedDate,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Id = customer.Id,
                IsDeleted = customer.IsDeleted,
                MiddleName = customer.MiddleName,
                PhoneNumber = customer.PhoneNumber,
                Status = customer.Status,
                LGAId = customer.LGAId
            };
            return @return;
        }

        public async Task<CustomerDTO> CreateCustomer(Customer customerVM)
        {

            //string query = "SELECT TOP 1 * FROM Customer WHERE PhoneNumber = {0}";
            //customerRepository.
            var customer = await customerRepository.GetSingleWhere(x => x.PhoneNumber.Equals(customerVM.PhoneNumber));

            if(customer != null)
            {
                throw new ApplicationException("User already exist");
            }

            customer = new Core.Entities.Customer()
            {
                FirstName = customerVM.FirstName,
                LastName = customerVM.LastName,
                MiddleName = customerVM.MiddleName,
                PhoneNumber = customerVM.PhoneNumber,
                LGAId = customerVM.LGAId
            };

            await customerRepository.Insert(customer, true);

            customer = await customerRepository.GetSingleWhere(x => x.PhoneNumber.Equals(customerVM.PhoneNumber));

            if(customer != null)
            {
                var otpRequest = new OTPRequest() { CustomerId = customer.Id, PhoneNumber = customer.PhoneNumber };

                bool otpResult = await otpService.SendOtp(otpRequest);

                if (!otpResult)
                {
                    throw new ApplicationException("Could not send OTP");
                }

                var @return = new CustomerDTO()
                {
                    CreatedDate = customer.CreatedDate,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Id = customer.Id,
                    IsDeleted = customer.IsDeleted,
                    MiddleName = customer.MiddleName,
                    PhoneNumber = customer.PhoneNumber,
                    LGAId = customer.LGAId,
                    Status = customer.Status
                };
                return @return;
            } else
            {
                throw new ApplicationException("OTP: Error Occured");
            }
        }

        public async Task<IEnumerable<CustomerDTO>> GetActiveCustomers()
        {
            var result = await customerRepository.GetActiveCustomers();

            var @return = result.Select(x => new CustomerDTO()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                CreatedDate = x.CreatedDate,
                IsDeleted = x.IsDeleted,
                MiddleName = x.MiddleName,
                PhoneNumber = x.PhoneNumber,
                Status = x.Status,
                LGAId = x.LGAId
            });

            return @return;
        }

        public IEnumerable<CustomerDTO> GetAllCustomers()
        {
            return customerRepository.GetAll().Select(x => new CustomerDTO()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                CreatedDate = x.CreatedDate,
                IsDeleted = x.IsDeleted,
                MiddleName = x.MiddleName,
                PhoneNumber = x.PhoneNumber,
                Status = x.Status,
                LGAId = x.LGAId
            });
        }

        public async Task<CustomerDTO> GetCustomerByIdAndPhoneNumber(OTPRequest otpRequest)
        {
            var customer = await customerRepository.GetSingleWhere(x => x.Id == otpRequest.CustomerId &&
            x.PhoneNumber.Equals(otpRequest.PhoneNumber));

            if(customer == null)
            {
                throw new ApplicationException("Customer not found");
            }

            var customerDto = new CustomerDTO()
            {
                CreatedDate = customer.CreatedDate,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                IsDeleted = customer.IsDeleted,
                Id = customer.Id,
                MiddleName = customer.MiddleName,
                PhoneNumber = customer.PhoneNumber,
                Status = customer.Status
            };

            return customerDto;
        }

        public async Task<string> ResendOTP(OTPRequest otpRequest)
        {
            var customerDto = await GetCustomerByIdAndPhoneNumber(otpRequest);

            if (customerDto == null)
            {
                throw new ApplicationException("Customer Not Found");
            }

            var result = await otpService.SendOtp(otpRequest);

            if (!result)
            {
                throw new ApplicationException("Error Resending OTP");
            }

            return "OTP Resent successfully";
        }
    }
}
