using DotnetBackend.Core.DTO;
using DotnetBackend.Core.Entities;
using DotnetBackend.Data.Repositories;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DotnetBackend.Service.Implementations
{
    public class OTPService : IOTPService
    {

        private readonly IRepository<OTP> otpRepository;
        private readonly ILogger<OTPService> logger;
        private readonly TOKEN_EXPIRATION TOKEN_EXPIRATION;

        public OTPService(IRepository<OTP> otpRepository, ILogger<OTPService> logger, IOptions<TOKEN_EXPIRATION> tOKEN_EXPIRATION)
        {
            this.otpRepository = otpRepository;
            this.logger = logger;
            TOKEN_EXPIRATION = tOKEN_EXPIRATION.Value;
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
            var otp = await otpRepository.GetSingleWhere(x => x.Code.Equals(oTPValidateRequest.code)
            && x.CustomerId == oTPValidateRequest.CustomerId && x.Status == Core.Status.UNUSED);

            if(otp == null)
            {
                throw new ApplicationException("InValid OTP");
            }
            //if(otp.Status == Core.Status.USED)
            //{
            //    throw new ApplicationException("This OTP have been used");
            //}

            var validity = tokenValidity(otp.CreatedDate);

            if (!validity)
            {
                throw new ApplicationException("This token have expired");
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

        private bool tokenValidity(DateTimeOffset tokenTime)
        {
            bool result = false;

            var timeEx = int.Parse(TOKEN_EXPIRATION.TIME_IN_MIN);

            DateTimeOffset dateTime = DateTimeOffset.Now;

            tokenTime = tokenTime.AddMinutes(timeEx);

            if(tokenTime >= dateTime)
            {
                result = true;
            }

            return result;
        }
    }
}
