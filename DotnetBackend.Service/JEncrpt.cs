namespace DotnetBackend.Service
{
    internal static class JEncrpt
    {
        public static string GetOTP(int len)
        {
            string numbers = "0123456789875643210";

            Random random = new Random();

            char[] otp = new char[len];

            for (int i = 0; i < len; i++)
            {
                int index = random.Next(numbers.Length);
                otp[i] = numbers[index];
            }
            return new string(otp);
        }
    }
}
