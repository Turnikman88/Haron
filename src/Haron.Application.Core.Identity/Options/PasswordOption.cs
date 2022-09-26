namespace Haron.Application.Core.Identity.Options
{
    internal class PasswordOption
    {
        private readonly string _specialSymbols = string.Empty;

        public PasswordOption()
        {
            MinimalLength = 6;
            _specialSymbols = " !\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";
        }

        public bool RequiredDigit { get; set; }
        public bool RequiredUppercase { get; set; }
        public bool RequiredLowercase { get; set; }
        public bool RequiredSpecialSymbols { get; set; }
        public int MinimalLength { get; set; }

        public bool CheckForSpecialSymbols(string pass)
        {
            foreach (var letter in pass)
            {
                if (_specialSymbols.Contains(letter))
                {
                    return true;
                }
            }

            return false;
        }
    }
}