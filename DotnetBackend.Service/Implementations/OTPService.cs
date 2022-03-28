using DotnetBackend.Core.DTO;
using DotnetBackend.Core.Entities;
using DotnetBackend.Data.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBackend.Service.Implementations
{
    public class OTPService : IOTPService
    {

        private readonly IRepository<OTP> otpRepository;
        //private readonly ILogger<OTPService> logger;

        public OTPService(IRepository<OTP> otpRepository)
        {
            this.otpRepository = otpRepository;
        }

        public async Task<bool> SendOtp(OTPRequest oTPRequest)
        {
            var code = await GenerateOTPCode(oTPRequest.PhoneNumber);

            var sentCode = await sendOTP(code, oTPRequest.PhoneNumber);

            var otp = new OTP()
            {
                Code = code,
                CustomerId = oTPRequest.CustomerId
            };

            await otpRepository.Insert(otp);

            return true;
        }

        public async Task<bool> ValidateOtp(OTPValidateRequest oTPValidateRequest)
        {
            var otp = await otpRepository.GetSingleWhere(x => string.Equals(x.Code, oTPValidateRequest.code, StringComparison.OrdinalIgnoreCase)
            && x.CustomerId == oTPValidateRequest.CustomerId);

            if(otp == null)
            {
                throw new ApplicationException("InValid OTP");
            }

            otp.Status = Core.Status.USED;

            await otpRepository.Update(otp, false);

            return true;
        }

        private async Task<string> GenerateOTPCode(string phoneNumber)
        {
            return await Task<string>.Factory.StartNew(() =>
            {
                //int studCount = DbContext.Candidates.Count(x => x.RegNo.Contains(RegnoPrefix));
                //string studentCount = formartNumber(++studCount);
                //string regno = RegnoPrefix + "/" + studentCount;
                return "000000";
            });
        }

        private async Task<bool> sendOTP(string code, string phoneNumber)
        {
            return await Task<bool>.Factory.StartNew(() =>
            {
                //int studCount = DbContext.Candidates.Count(x => x.RegNo.Contains(RegnoPrefix));
                //string studentCount = formartNumber(++studCount);
                //string regno = RegnoPrefix + "/" + studentCount;
                return true;
            });
        }
    }
}
