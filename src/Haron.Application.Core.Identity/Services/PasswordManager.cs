using Haron.Application.Core.Identity.Options;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;

namespace Haron.Application.Core.Identity.Services
{
    public class PasswordManager
    {
        private readonly ICollection<Func<string, bool>> _requirments;

        public PasswordManager(PasswordOption passwordOption)
        {
            _requirments = Requirments(passwordOption);
        }

        public IReadOnlyCollection<Func<string, bool>> PasswordRequirment => (IReadOnlyCollection<Func<string, bool>>)_requirments;

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