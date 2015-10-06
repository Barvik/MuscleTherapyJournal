using System;
using System.Security.Cryptography;
using System.Text;
using MuscleTherapyJournal.Common.Security.Interface;

namespace MuscleTherapyJournal.Common.Security
{
    public class MuscleTherapyPassword : IMuscleTherapyPassword
    {
        private readonly RNGCryptoServiceProvider _randomCryptoService;
        private readonly SHA512Managed _algorithmSha512Managed;
        private readonly UnicodeEncoding _encoder;

        public MuscleTherapyPassword()
        {
            _randomCryptoService = new RNGCryptoServiceProvider();
            _algorithmSha512Managed = new SHA512Managed();
            _encoder = new UnicodeEncoding();
        }

        public string GenerateSalt(int size)
        {
            var tempBuffer = new byte[size];
            _randomCryptoService.GetBytes(tempBuffer);

            return Convert.ToBase64String(tempBuffer);
        }

        public string GenerateHashedPassword(string pwd, string salt)
        {
            var data = _encoder.GetBytes(pwd + salt);
            var hashedData = _algorithmSha512Managed.ComputeHash(data);
            return _encoder.GetString(hashedData);
        }
    }
}
