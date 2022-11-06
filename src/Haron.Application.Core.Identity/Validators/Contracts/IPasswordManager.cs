using Haron.Application.Core.Identity.ValidationModels;

namespace Haron.Application.Core.Identity.Validators.Contracts
{
    public interface IPasswordManager
    {
        ValidationModel ValidationPassword(string password);

        string HashPassoword(string pass);
    }
}