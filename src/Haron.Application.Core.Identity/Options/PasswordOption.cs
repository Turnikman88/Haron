namespace Haron.Application.Core.Identity.Options
{
    public class PasswordOption
    {
        private readonly string _specialSymbols = string.Empty;
        private int _minimalLength;

        public PasswordOption()
        {
            _minimalLength = 6;
            _specialSymbols = " !\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";
        }

        public string Salt { get; set; }
        public bool RequiredDigit { get; set; }
        public bool RequiredUppercase { get; set; }
        public bool RequiredLowercase { get; set; }
        public bool RequiredSpecialSymbols { get; set; }
        public int MinimalLength
        {
            get
            {
                return _minimalLength;
            }
            set
            {
                _minimalLength = value;
            }
        }

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