using Haron.Application.Core.Identity.Options;
using Haron.Application.Core.Identity.ValidationModels;
using Haron.Application.Core.Identity.Validators.Contracts;
using System.Security.Cryptography;
using System.Text;

namespace Haron.Application.Core.Identity.Validators
{
    public class PasswordManager : IPasswordManager
    {
        private readonly ICollection<Func<string, bool>> _requirments;
        private readonly string _salt;

        public PasswordManager(PasswordOption passwordOption)
        {
            _requirments = Requirments(passwordOption);
            _salt = passwordOption.Salt;
        }

        public IReadOnlyCollection<Func<string, bool>> PasswordRequirment => (IReadOnlyCollection<Func<string, bool>>)_requirments;

        public ValidationModel ValidationPassword(string password)
        {
            ValidationModel result = new ValidationModel();
            bool isValid = _requirments.All(x => x(password));
            if (!isValid)
            {
                result.Message = "Passoword is invalid";
            }
            return result;
        }

        public string HashPassoword(string pass)
        {
            if (string.IsNullOrWhiteSpace(pass))
            {
                return string.Empty;
            }

            using (var sha = SHA256.Create())
            {
                string hash = GetHash(sha, pass);
                return hash;
            }
        }
        private string GetHash(HashAlgorithm hashAlgorithm, string input)
        {
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input + _salt));
            var sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("x2"));
            }
            return sb.ToString();
        }

        private ICollection<Func<string, bool>> Requirments(PasswordOption passwordOption)
        {
            List<Func<string, bool>> requirments = new();
            if (passwordOption is null)
            {
                throw new ArgumentNullException($"{nameof(PasswordOption)} is null");
            }

            Func<string, bool> minimalLengthRequirement = x => x.Length >= passwordOption.MinimalLength;
            requirments.Add(minimalLengthRequirement);

            if (passwordOption.RequiredDigit)
            {
                Func<string, bool> requirment = x => x.Any(chr => char.IsDigit(chr));
                requirments.Add(requirment);
            }
            else if (passwordOption.RequiredUppercase)
            {
                Func<string, bool> requirment = x => x.Any(chr => char.IsLetter(chr) && char.IsUpper(chr));
                requirments.Add(requirment);
            }
            else if (passwordOption.RequiredLowercase)
            {
                Func<string, bool> requirment = x => x.Any(chr => char.IsLetter(chr) && char.IsUpper(chr));
                requirments.Add(requirment);
            }
            else if (passwordOption.RequiredSpecialSymbols)
            {
                Func<string, bool> requirment = x => passwordOption.CheckForSpecialSymbols(x);
                requirments.Add(requirment);
            }

            return requirments;
        }
    }
}