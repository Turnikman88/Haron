using System.Text;

namespace Haron.Application.Core.Identity.Options
{
    internal class UserOption
    {
        private readonly StringBuilder _allowedUserNameCharacters;

        public UserOption()
        {
            _allowedUserNameCharacters = new StringBuilder("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+");
        }

        public bool RequireUniqueEmail { get; set; }
        public string? AllowedUserNameCharacters
        {
            get
            {
                return _allowedUserNameCharacters.ToString();
            }
            set
            {
                if (value is not null)
                {
                    value = value.Trim();
                    foreach (var chr in value)
                    {
                        string chrToString = chr.ToString();
                        if (_allowedUserNameCharacters.ToString().Contains(chrToString))
                        {
                            continue;
                        }
                        _allowedUserNameCharacters.Append(chrToString);
                    }
                }
            }
        }
    }
}