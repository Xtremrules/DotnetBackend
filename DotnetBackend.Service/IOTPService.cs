using DotnetBackend.Core.DTO;
using DotnetBackend.Core.Entities;

namespace DotnetBackend.Service
{
    public interface IOTPService
    {
        Task<bool> SendOtp(OTPRequest oTPRequest);
        Task<bool> ValidateOtp(OTPValidateRequest oTPValidateRequest);
    }
}
